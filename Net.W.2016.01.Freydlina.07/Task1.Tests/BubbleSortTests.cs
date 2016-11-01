using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        #region Test method: public static void SortJuggedArrayByMax(int[][] arr)
        public static IEnumerable<TestCaseData> TestCasesForSortJuggedArray
        {
            get
            {
                int[][] arr =
                {
                    new int[] {3, 4},
                    new int[] {2, 3, 3, 2},
                    new int[] {1, 2, 5},
                };
                int[][] arrRet =
                {
                    new int[] {2, 3, 3, 2},
                    new int[] {3, 4},
                    new int[] {1, 2, 5},
                };
                yield return new TestCaseData(arr, new ComparatorByAscendingMax()).Returns(arrRet);

                arr = new int[3][];
                arr[0] = new int[] { 3, 4 };
                arr[1] = new int[] { 2, 3, 3, 2 };
                arr[2] = new int[] { 1, 2, 5 };
                arrRet = new int[3][];
                arrRet[0] = new int[] { 1, 2, 5 };
                arrRet[1] = new int[] { 3, 4 };
                arrRet[2] = new int[] { 2, 3, 3, 2 };
                yield return new TestCaseData(arr, new ComparatorByDescendingMax()).Returns(arrRet);

                arr = new int[3][];
                arr[0] = new int[] { 3, 4 };
                arr[1] = new int[] { 2, 3, 3, 2 };
                arr[2] = new int[] { 1, 2, 5 };
                arrRet = new int[3][];
                arrRet[0] = new int[] {3, 4};
                arrRet[1] = new int[] {1, 2, 5};
                arrRet[2] = new int[] {2, 3, 3, 2};
                yield return new TestCaseData(arr, new ComparatorByAscendingSum()).Returns(arrRet);

                arr = new int[3][];
                arr[0] = new int[] { 3, 4 };
                arr[1] = new int[] { 2, 3, 3, 2 };
                arr[2] = new int[] { 1, 2, 5 };
                arrRet = new int[3][];
                arrRet[0] = new int[] { 2, 3, 3, 2 };
                arrRet[1] = new int[] { 1, 2, 5 };
                arrRet[2] = new int[] { 3, 4 };
                yield return new TestCaseData(arr, new ComparatorByDescendingSum()).Returns(arrRet);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForSortJuggedArray))]
        public int[][] TestSortJuggedArray(int[][] arr, ICustomComparator comparator)
        {
            BubbleSort.SortJuggedArray(arr, comparator);
            return arr;

        }

        public static IEnumerable<TestCaseData> TestCasesForSortJuggedArrayThrows
        {
            get
            {
                yield return new TestCaseData(new int[3][], null);
                yield return new TestCaseData(null, null);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForSortJuggedArrayThrows))]
        public void TestSortJuggedArrayThrows(int[][] arr, ICustomComparator comparator)
        {
            Assert.That(() => BubbleSort.SortJuggedArray(arr, comparator), Throws.TypeOf<ArgumentNullException>());

        }
        #endregion
    }
}
