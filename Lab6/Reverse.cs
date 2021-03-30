using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLib;

namespace GraphLib
{
    public class Reverse<Type> : IComparer<Type> where Type : IComparable
    {
        public int Compare(Type x, Type y)
        {
            return y.CompareTo(x);
        }
    }
}
