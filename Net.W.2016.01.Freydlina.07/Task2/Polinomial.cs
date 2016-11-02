using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Polinomial
    {
        public double[] Coefficients { get; private set; } = {};

        public Polinomial()
        {}

        public Polinomial(params double[] coefficients)
        {
            if (coefficients == null || coefficients.Length == 0)
            {
                throw new ArgumentException();
            }

            Coefficients = coefficients;
        }

        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (o.GetType() != this.GetType())
            {
                return false;
            }
            return Coefficients.Length == ((Polinomial) o).Coefficients.Length && Coefficients.SequenceEqual(((Polinomial) o).Coefficients);
        }

        public override string ToString()
        {
            string str = Coefficients[0] != 0 ? Coefficients[0].ToString() : string.Empty;
            for (int i = 1; i < Coefficients.Length; i++)
            {
                if (Coefficients[i] == 0)
                {
                    continue;
                }
                if (Coefficients[i] > 0 && !string.IsNullOrEmpty(str))
                {
                    str += "+";
                }
                str += $"{Coefficients[i]}x";
                if (i >= 2)
                {
                    str += $"^{i}";
                }
            }
            return str;
        }

        public static Polinomial operator+(Polinomial lhs, Polinomial rhs)
        {
            double[] coefficients = {};
            double[] arrayToAdd;
            if (lhs.Coefficients.Length > rhs.Coefficients.Length)
            {
                lhs.Coefficients.CopyTo(coefficients, 0);
                arrayToAdd = rhs.Coefficients;
            }
            else
            {
                rhs.Coefficients.CopyTo(coefficients, 0);
                arrayToAdd = lhs.Coefficients;
            }
            
            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] += arrayToAdd[i];
            }

            return new Polinomial(coefficients);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
