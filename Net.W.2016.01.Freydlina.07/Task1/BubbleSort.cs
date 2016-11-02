using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class BubbleSort
    {
        /// <summary>
        /// Sorts jugged array by Bubble Algorithm with come comparator
        /// </summary>
        /// <param name="arr">jugged array</param>
        /// <param name="comparator">implements comparation way</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SortJuggedArray(int[][] arr, ICustomComparator comparator)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (comparator.CompareArrays(arr[i],arr[j]) <= 0) continue;
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }
}
