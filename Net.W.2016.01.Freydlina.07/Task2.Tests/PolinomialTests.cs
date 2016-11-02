using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}
