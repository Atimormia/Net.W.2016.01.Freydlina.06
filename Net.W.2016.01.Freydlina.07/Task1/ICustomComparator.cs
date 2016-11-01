using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface ICustomComparator
    {
        int CompareArrays(int[] a, int[] b);
    }
}
