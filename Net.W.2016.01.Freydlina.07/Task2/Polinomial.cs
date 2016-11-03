using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Represents polinomial with one variable, operations with polinomial
    /// </summary>
    public class Polinomial
    {
        public double[] Coefficients { get; } = {};
        /// <summary>
        /// Default constructor. Creates empty array of coefficients
        /// </summary>
        public Polinomial()
        {}

        /// <summary>
        /// Creates polinomial with custom coefficients
        /// </summary>
        /// <param name="coefficients"></param>
        public Polinomial(params double[] coefficients)
        {
            if (coefficients == null || coefficients.Length == 0)
            {
                throw new ArgumentException();
            }

            Coefficients = coefficients;
        }

        /// <summary>
        /// Compares this polinomial with another polinomial
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Generates expression by coefficients
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Coefficients.Length == 0)
            {
                return "";
            }
            if (Coefficients == null)
            {
                return null;
            }
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

        public static Polinomial operator +(Polinomial lhs, Polinomial rhs)
        {
            if (lhs == null || rhs == null)
            {
                throw new ArgumentNullException();
            }

            double[] coefficients = {};
            double[] arrayToAdd;
            if (lhs.Coefficients.Length > rhs.Coefficients.Length)
            {
                coefficients = (double[])lhs.Coefficients.Clone();
                arrayToAdd = rhs.Coefficients;
            }
            else
            {
                coefficients = (double[])rhs.Coefficients.Clone();
                arrayToAdd = lhs.Coefficients;
            }
            
            for (int i = 0; i < arrayToAdd.Length; i++)
            {
                coefficients[i] += arrayToAdd[i];
            }

            return new Polinomial(coefficients);
        }

        public static Polinomial operator -(Polinomial lhs, Polinomial rhs)
        {
            if (lhs == null || rhs == null)
            {
                throw new ArgumentNullException();
            }

            int maxArrayLenght = lhs.Coefficients.Length > rhs.Coefficients.Length
                ? lhs.Coefficients.Length
                : rhs.Coefficients.Length;

            double[] coefficients = new double[maxArrayLenght];
            for (int i = 0; i < lhs.Coefficients.Length; i++)
            {
                coefficients[i] = lhs.Coefficients[i];
            }

            for (int i = 0; i < rhs.Coefficients.Length; i++)
            {
                coefficients[i] -= rhs.Coefficients[i];
            }

            return new Polinomial(coefficients);
        }

        public static Polinomial operator *(double coefficient, Polinomial polinomial)
        {
            if (polinomial == null)
            {
                throw new ArgumentNullException();
            }
           
            double[] coefficients = (double[])polinomial.Coefficients.Clone();

            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] *= coefficient;
            }

            return new Polinomial(coefficients);
        }

        public static Polinomial operator *(Polinomial polinomial, double coefficient)
        {
            return coefficient * polinomial;
        }

        public static Polinomial operator /( Polinomial polinomial, double coefficient)
        {
            if (polinomial == null)
            {
                throw new ArgumentNullException();
            }

            if (coefficient == 0)
            {
                throw new ArgumentException();
            }

            double[] coefficients = (double[])polinomial.Coefficients.Clone();

            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] /= coefficient;
            }

            return new Polinomial(coefficients);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
