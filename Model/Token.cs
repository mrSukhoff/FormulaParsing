using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaParsing.Model
{
    /// <summary>
    /// список возможных значений узлов дерева
    /// </summary>
    public enum Token : byte { plus, minus, mul, div, pow, var, nul }
}
