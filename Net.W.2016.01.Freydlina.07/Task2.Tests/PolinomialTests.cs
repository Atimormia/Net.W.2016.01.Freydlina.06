using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class PolinomialTests
    {
        #region Test method: public Polinomial()

        public static IEnumerable<TestCaseData> TestCasesForPolinomialDefault
        {
            get
            {
                double[] coefficients = { };
                yield return new TestCaseData().Returns(coefficients);

            }
        }

        [Test, TestCaseSource(nameof(TestCasesForPolinomialDefault))]
        public double[] TestPolinomialDefault()
        {
            Polinomial polinomial = new Polinomial();
            return polinomial.Coefficients;

        }

        #endregion

        #region Test method: public Polinomial(params double[] coefficients)

        public static IEnumerable<TestCaseData> TestCasesForPolinomial
        {
            get
            {
                double[] coefficients = { 1, 0, 3, 4, 0, 5 };
                yield return new TestCaseData(coefficients).Returns(coefficients);
                coefficients = new double[] { 0 };
                yield return new TestCaseData(coefficients).Returns(coefficients);

            }
        }

        [Test, TestCaseSource(nameof(TestCasesForPolinomial))]
        public double[] TestPolinomial(double[] coefficients)
        {
            Polinomial polinomial = new Polinomial(coefficients);
            return polinomial.Coefficients;

        }

        public static IEnumerable<TestCaseData> TestCasesForPolinomialThrows
        {
            get
            {
                yield return new TestCaseData(new double[] {});
                yield return new TestCaseData(null);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForPolinomialThrows))]
        public void TestPolinomialThrows(double[] coefficients)
        {
            Assert.That(() => new Polinomial(coefficients), Throws.TypeOf<ArgumentException>());

        }
        #endregion

        #region Test method: public override bool Equals(object o)

        public static IEnumerable<TestCaseData> TestCasesForEquals
        {
            get
            {
                Polinomial polinomial = new Polinomial(1, 0, 3, 4, 0, 5);
                yield return new TestCaseData(polinomial,polinomial).Returns(true);
                Polinomial polinomial2 = new Polinomial(1, 0, 3, 4, 0, 5);
                yield return new TestCaseData(polinomial,polinomial2).Returns(true);
                yield return new TestCaseData(polinomial, null).Returns(false);
                polinomial2 = new Polinomial(1, 0, 3, 4, 0);
                yield return new TestCaseData(polinomial, polinomial2).Returns(false);
                yield return new TestCaseData(polinomial, new double[] { 1, 0, 3, 4, 0, 5 }).Returns(false);

            }
        }

        [Test, TestCaseSource(nameof(TestCasesForEquals))]
        public bool TestEquals(object obj1, object obj2)
        {
            return ((Polinomial)obj1).Equals(obj2 as Polinomial);
        }
        
        #endregion

        #region Test method: public override string ToString()
        public static IEnumerable<TestCaseData> TestCasesForToString
        {
            get
            {
                Polinomial polinomial = new Polinomial(1,0,3,4,0,5);
                yield return new TestCaseData(polinomial).Returns("1+3x^2+4x^3+5x^5");
                polinomial = new Polinomial(-1, 0, 3, -4, 0, 5);
                yield return new TestCaseData(polinomial).Returns("-1+3x^2-4x^3+5x^5");
                double[] coefs = {0, 1, 2, 0, 0, 0};
                polinomial = new Polinomial(coefs);
                yield return new TestCaseData(polinomial).Returns("1x+2x^2");
                polinomial = new Polinomial(0);
                yield return new TestCaseData(polinomial).Returns("");

            }
        }

        [Test, TestCaseSource(nameof(TestCasesForToString))]
        public string TestToString(Polinomial polinomial)
        {
            return polinomial.ToString();

        }
        #endregion

        #region Test method: public static Polinomial operator+(Polinomial lhs, Polinomial rhs)
        public static IEnumerable<TestCaseData> TestCasesForAdditing
        {
            get
            {
                yield return new TestCaseData(new Polinomial(1,2,3),new Polinomial(2,3,4,5)).Returns(new Polinomial(3,5,7,5));
                yield return new TestCaseData(new Polinomial(1, 2, 3), new Polinomial()).Returns(new Polinomial(1,2,3));
                

            }
        }

        [Test, TestCaseSource(nameof(TestCasesForAdditing))]
        public Polinomial TestAdditing(Polinomial polinomial1, Polinomial polinomial2)
        {
            return polinomial1 + polinomial2;

        }

        public static IEnumerable<TestCaseData> TestCasesForAdditingThrows
        {
            get
            {
                yield return new TestCaseData(new Polinomial(1, 2, 3), null);
                yield return new TestCaseData(null, new Polinomial(1, 2, 3));
                yield return new TestCaseData(null, null);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForAdditingThrows))]
        public void TestAdditingThrows(Polinomial polinomial1, Polinomial polinomial2)
        {
            Assert.That(() => polinomial1+polinomial2, Throws.TypeOf<ArgumentNullException>());

        }
        #endregion

        #region Test method: public static Polinomial operator-(Polinomial lhs, Polinomial rhs)
        public static IEnumerable<TestCaseData> TestCasesForSubtraction
        {
            get
            {
                yield return new TestCaseData(new Polinomial(2, 3, 4, 5), new Polinomial(1, 2, 3)).Returns(new Polinomial(1, 1, 1, 5));
                yield return new TestCaseData(new Polinomial(1, 2, 3), new Polinomial()).Returns(new Polinomial(1, 2, 3));
                yield return new TestCaseData(new Polinomial(), new Polinomial(1, 2, 3)).Returns(new Polinomial(-1, -2, -3));
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForSubtraction))]
        public Polinomial TestSubtraction(Polinomial polinomial1, Polinomial polinomial2)
        {
            return polinomial1 - polinomial2;

        }

        public static IEnumerable<TestCaseData> TestCasesForSubtractionThrows
        {
            get
            {
                yield return new TestCaseData(new Polinomial(1, 2, 3), null);
                yield return new TestCaseData(null, new Polinomial(1, 2, 3));
                yield return new TestCaseData(null, null);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForSubtractionThrows))]
        public void TestSubtractionThrows(Polinomial polinomial1, Polinomial polinomial2)
        {
            Assert.That(() => polinomial1 - polinomial2, Throws.TypeOf<ArgumentNullException>());

        }
        #endregion

        #region Test method: public static Polinomial operator*
        public static IEnumerable<TestCaseData> TestCasesForMultiplication
        {
            get
            {
                yield return new TestCaseData(2, new Polinomial(1, 2, 3)).Returns(new Polinomial(2, 4, 6));
                yield return new TestCaseData(-2, new Polinomial(1, 2, 3)).Returns(new Polinomial(-2, -4, -6));
                yield return new TestCaseData(0, new Polinomial(1, 2, 3)).Returns(new Polinomial(0, 0, 0));
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForMultiplication))]
        public Polinomial TestMultiplicationLeft(double coef, Polinomial polinomial)
        {
            return coef * polinomial;
        }

        [Test, TestCaseSource(nameof(TestCasesForMultiplication))]
        public Polinomial TestMultiplicationRight(double coef, Polinomial polinomial)
        {
            return polinomial*coef;
        }

        public static IEnumerable<TestCaseData> TestCasesForMultiplicationThrows
        {
            get
            {
                yield return new TestCaseData(0, null);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForMultiplicationThrows))]
        public void TestMultiplicationThrows(double coef, Polinomial polinomial)
        {
            Assert.That(() => coef * polinomial, Throws.TypeOf<ArgumentNullException>());

        }
        #endregion

        #region Test method: public static Polinomial operator/(Polinomial polinomial, double coefficient)
        public static IEnumerable<TestCaseData> TestCasesForDivision
        {
            get
            {
                yield return new TestCaseData(2, new Polinomial(1, 2, 3)).Returns(new Polinomial(0.5, 1, 1.5));
                yield return new TestCaseData(-2, new Polinomial(1, 2, 3)).Returns(new Polinomial(-0.5, -1, -1.5));
            }
        }
        
        [Test, TestCaseSource(nameof(TestCasesForDivision))]
        public Polinomial TestDivision(double coef, Polinomial polinomial)
        {
            return polinomial / coef;
        }

        public static IEnumerable<TestCaseData> TestCasesForDivisionThrows1
        {
            get
            {
                yield return new TestCaseData(1, null);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForDivisionThrows1))]
        public void TestDivisionThrows1(double coef, Polinomial polinomial)
        {
            Assert.That(() => polinomial/coef, Throws.TypeOf<ArgumentNullException>());

        }

        public static IEnumerable<TestCaseData> TestCasesForDivisionThrows2
        {
            get
            {
                yield return new TestCaseData(0, new Polinomial());
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForDivisionThrows2))]
        public void TestDivisionThrows2(double coef, Polinomial polinomial)
        {
            Assert.That(() => polinomial / coef, Throws.TypeOf<ArgumentException>());

        }
        #endregion
    }
}
