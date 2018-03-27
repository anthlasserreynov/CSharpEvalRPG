using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Helpers
{
    public static class GenericCollectionHelper
    {

        // Read Array and return i and j
        public static void ForEachWithIndexes<T>(this T[,] matrix, Action<int,int> action)
        {
            int lignes = matrix.GetLength(0);
            int colones = matrix.GetLength(1);

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colones; j++)
                {
                    action(i, j);
                }
            }
        }

        /// Read Array and call action with element
        public static void ForEachWithElement<T>(this T[,] matrix, Action<T> action)
        {
            int lignes = matrix.GetLength(0);
            int colones = matrix.GetLength(1);

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colones; j++)
                {
                    action(matrix[i, j]);
                }
            }
        }

        // Add or increment value
        public static void AddOrIncrement<T>(this Dictionary<T, int> dictionary, T key, int value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] += value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }
    }
}
