using System;
using System.Collections.Generic;

namespace FormulaParsing.Model
{
    /// <summary>
    /// Класс получает строку, строит дерево,подставляет значение переменной
    /// и выччисляет значение выражения
    /// </summary>
    public class Parser
    {
        private string _expression;
        private double _variable;

        //заданная формула
        public string Expression
        {
            get => _expression;
            set
            {
                _expression = value;
                Parse();
            }
        }

        //значение переменной
        public double Variable
        {
            get => _variable;
            set
            {
                _variable = value;
                Parse();
            }
        }

        //результат вычислений
        public double? Meaninig { get; private set; }

        public Parser()
        {
        }

        void Parse()
        {
            List<string> expressionList;
            Node rootNode = null;
            try
            {
                expressionList = Analayzer.SplitTheString(_expression);
                rootNode = TreeBuilder.BuildTree(expressionList);
                Meaninig = Calculator.Calculate(rootNode, _variable);
            }
            catch(Exception ex)
            {
                //Nobody care
                Meaninig = null;
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// метод использовался для отладки
        /// выводит дерево на консоль
        /// </summary>
        /// <param name="node"></param>
        void ShowTree(Node node)
        {
            Console.WriteLine(node.Token.ToString());
            Console.WriteLine(node.Exp.ToString());
            Console.WriteLine("Left:");
            if (node.LeftChild != null) ShowTree(node.LeftChild);
            Console.WriteLine("Right:");
            if (node.RightChild != null) ShowTree(node.RightChild);
        }



    }
}

