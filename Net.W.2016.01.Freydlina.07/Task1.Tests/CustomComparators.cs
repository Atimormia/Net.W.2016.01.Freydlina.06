using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    class ComparatorByAscendingMax : ICustomComparator
    {
        public int CompareArrays(int[] a, int[] b)
        {
            return a.Max() - b.Max();
        }
    }

    class ComparatorByAscendingSum : ICustomComparator
    {
        public int CompareArrays(int[] a, int[] b)
        {
            return a.Sum() - b.Sum();
        }
    }
    class ComparatorByDescendingMax : ICustomComparator
    {
        public int CompareArrays(int[] a, int[] b)
        {
            return b.Max() - a.Max();
        }
    }
    class ComparatorByDescendingSum : ICustomComparator
    {
        public int CompareArrays(int[] a, int[] b)
        {
            return b.Sum() - a.Sum();
        }
    }
}
