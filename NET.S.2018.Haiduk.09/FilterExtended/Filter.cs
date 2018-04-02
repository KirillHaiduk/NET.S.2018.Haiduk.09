using System;
using System.Collections.Generic;

namespace NET.S._2018.Haiduk._09
{
    public class Filter
    {
        /// <summary>
        /// Method which takes an array of integers and filters it so that only numbers containing the given digit remain on the output
        /// </summary>
        /// <param name="array">array that is necessary to filter</param>
        /// <param name="digit">filtering digit</param>
        /// <returns>Array of integers containing filtering digit</returns>
        public static int[] FilterDigit(int[] array, FilterFunction predicate)
        {            
            if (array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} is null.");
            }

            List<int> list = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate.Match(array[i]))
                {
                    list.Add(array[i]);
                }
            }

            if (list.Count == 0)
            {
                return null;
            }

            return list.ToArray();
        }
    }
}
