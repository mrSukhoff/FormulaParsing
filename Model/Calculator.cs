using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaParsing.Model
{
    class Calculator
    {
        /// <summary>
        /// Метод рекурсивно вычисляет значение всех узлов дерева
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="var"></param>
        static internal double Calculate(Node startNode, double var)
        {
            double leftExp = 0;
            double rightExp = 0;

            //если это лист, возвращаем значение
            if (startNode.Exp != null) return (double)startNode.Exp;

            //иначе вычисляем левую..
            if (startNode.LeftChild != null)
            {
                Calculate(startNode.LeftChild,var);
                leftExp = (double)startNode.LeftChild.Exp;
            }
            
            //и правую ветви
            if (startNode.RightChild != null)
            {
                Calculate(startNode.RightChild,var);
                rightExp = (double)startNode.RightChild.Exp;
            }

            //и вычисляем значение этого узла
            switch (startNode.Token)
            {
                case Token.plus:
                    startNode.Exp = leftExp + rightExp;
                    break;
                case Token.minus:
                    startNode.Exp = leftExp - rightExp;
                    break;
                case Token.mul:
                    startNode.Exp = leftExp * rightExp;
                    break;
                case Token.div:
                    startNode.Exp = leftExp / rightExp;
                    break;
                case Token.pow:
                    startNode.Exp = Math.Pow(leftExp, rightExp);
                    break;
                case Token.var:
                    startNode.Exp = var;
                    break;
                default: throw new Exception("Что-то пошло не так!");
            }
            return (double)startNode.Exp;
        }
    }
}
