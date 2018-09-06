using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaParsing.Model
{
    /// <summary>
    /// Узел синтаксического дерева
    /// </summary>
    class Node
    {
        public Node()
        {
            Token = Token.nul;
            LeftChild = RightChild = null;
            Exp = null;
        }

        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node Parent { get; set; }
        public Token Token { get; set; }
        public double? Exp{ get ; set; }


    }
}
