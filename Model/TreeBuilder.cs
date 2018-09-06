using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaParsing.Model
{
    class TreeBuilder
    {
        /// <summary>
        /// По списку строк метод строит синтаксическое дерево.
        /// </summary>
        /// <param name="list">Список лексем</param>
        /// <returns></returns>
        static internal Node BuildTree(List<string> list)
        {
            Dictionary<Token, byte> Priority = new Dictionary<Token, byte>();
            Priority.Add(Token.plus,  3);
            Priority.Add(Token.minus, 3);
            Priority.Add(Token.mul,   2);
            Priority.Add(Token.div,   2);
            Priority.Add(Token.pow,   1);

            Node currentNode = new Node();
            Node root = currentNode;

            foreach (string str in list)
            {
                //если левая скобка - добавляем левый узел
                //если узел корневой, то новый узел не добавляется
                if (str == "(")
                {
                    if (currentNode.Parent != null)
                    {
                        currentNode.LeftChild = new Node();
                        currentNode.LeftChild.Parent = currentNode;
                        currentNode = currentNode.LeftChild;
                    }
                    continue;
                }

                //если правая скобка - переходим по дереву вверх
                if (str == ")")
                {
                    currentNode = currentNode.Parent;
                    continue;
                }

                //если оператор ...
                if (str == "+" || str == "-" || str == "*" || str == "/" || str == "^")
                {
                    //определяем токен
                    Token token = Token.nul;
                    switch (str)
                    {
                        case "+":
                            token = Token.plus;
                            break;
                        case "-":
                            token = Token.minus;
                            break;
                        case "*":
                            token = Token.mul;
                            break;
                        case "/":
                            token = Token.div;
                            break;
                        case "^":
                            token = Token.pow;
                            break;
                    }

                    //поднимаемся по дереву до операции с меньшим приоритетом
                    while (currentNode.Parent!=null && Priority[currentNode.Parent.Token] < Priority[token])
                        currentNode = currentNode.Parent;
                   
                    
                    // создаем новый узел
                    Node newNode = new Node
                    {
                        Token = token,
                        LeftChild = currentNode //старый узел добавляем слева
                    };
                    //если у старого узла есть предок, мняем указатели  нем и на него
                    if (currentNode.Parent != null)
                    {
                        newNode.Parent = currentNode.Parent;
                        currentNode.Parent.RightChild = newNode;// всегда ли мы справа??
                    }
                    currentNode.Parent = newNode;//новый является предком старого
                    currentNode = newNode;      //новый делаем текущим

                    currentNode.RightChild = new Node(); //создаем правый узел
                    currentNode.RightChild.Parent = currentNode; 
                    currentNode = currentNode.RightChild; //и делаем правый текущим
                    continue;
                }

                //если переменная, то присваеваем её текущему узлу
                if (str == "x")
                {
                    currentNode.Token = Token.var;
                    continue;
                }

                //если число, то присваеваем его 
                if (Double.TryParse(str, out double doubleRes))
                {
                    currentNode.Exp = doubleRes;
                }
                else throw new Exception("Ошибка преобразования числа.");
            }

            return FindRoot(currentNode);
        }

        static private Node FindRoot(Node node)
        {
            while (node.Parent != null)
                node = node.Parent;
            return node;
        }
    }
}
