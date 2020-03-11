using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8
{
    public static class Matrix
    {
        static public int DotProduct(int[] v1, int[] v2)
        {
            if (v1.Length != v2.Length) 
            {
                return 0;
            }

            var sum = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                sum += v1[i] * v2[i];
            }

            return sum;
        }

        static public int[,] Transpose(int[,] matrix)
        {
            int[,] transposedArray = new int[matrix.GetLength(1), matrix.GetLength(0)];
            int row = 0;
            int column = 0;

            foreach (int element in matrix)
            {
                transposedArray[row++, column] = element;
                row = row == transposedArray.GetLength(0) ? 0 : row;
                column = row == 0 ? column + 1 : column;
            }

            return transposedArray;
        }

        static public int[,] GetIdentityMatrix(int size)
        {
            int[,] identityMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                identityMatrix[i,i] = 1;
            }

            return identityMatrix;
        }

        static public int[] GetRowOrNull(int[,] matrix, int row)
        {
            int[] array = new int[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                array[i] = matrix[row, i];
            }

            return array;
        }

        static public int[] GetColumnOrNull(int[,] matrix, int column)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                array[i] = matrix[i, column];
            }

            return array;
        }

        static public int[] MultiplyMatrixVectorOrNull(int[,] matrix, int[] vector)
        {
            if (vector.Length != matrix.GetLength(1))
            {
                return null;
            }

            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                array[i] = DotProduct(GetRowOrNull(matrix, i), vector);
            }

            return array;
        }

        static public int[] MultiplyVectorMatrixOrNull(int[] vector, int[,] matrix)
        {
            if (vector.Length != matrix.GetLength(0)) 
            {
                return null;
            }

            int[] array = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                array[i] = DotProduct(GetColumnOrNull(matrix, i), vector);
            }

            return array;
        }

        static public int[,] MultiplyOrNull(int[,] multiplicandMatrix, int[,] multiplierMatrix)
        {
            if (multiplicandMatrix.GetLength(1) != multiplierMatrix.GetLength(0))
            {
                return null;
            }

            int[,] array = new int[multiplicandMatrix.GetLength(0), multiplierMatrix.GetLength(1)];

            for (int i = 0; i < multiplicandMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < multiplierMatrix.GetLength(1); j++)
                {
                    array[i, j] = DotProduct(GetRowOrNull(multiplicandMatrix, i), GetColumnOrNull(multiplierMatrix, j));
                }
            }

            return array;
        }
    }
}