using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLabWorkInSixthChapters
{
    public class MatrixMultiplication
    {
        private readonly int[,] _firstMatrix;
        private readonly int[,] _secondMatrix;
        private int[,] multiplicationMatrix;

        public MatrixMultiplication(int[,] firstMatrix, int[,] secondMatrix)
        {
            _firstMatrix = firstMatrix;
            _secondMatrix = secondMatrix;
            multiplicationMatrix = new int [_firstMatrix.GetLength(0), _secondMatrix.GetLength(1)];
        }

        public void Multiplication()
        {
            if (_firstMatrix.GetLength(1)+1 != _secondMatrix.GetLength(0)+1)
                throw new ArgumentException("Matrices can not be multiplied!");
            for(int i = 0; i < _firstMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < _secondMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < _secondMatrix.GetLength(0); k++)
                    {
                        multiplicationMatrix[i, j] += _firstMatrix[i, k] * _secondMatrix[k,j];
                    }
                }
            }
        }

        public void Print()
        {            
            for(int i = 0; i < multiplicationMatrix.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < multiplicationMatrix.GetLength(1); j++)
                {
                    if (j == multiplicationMatrix.GetLength(1) - 1)
                        Console.Write("{0}", multiplicationMatrix[i, j]);
                    else
                        Console.Write("{0},", multiplicationMatrix[i, j]);
                }
                Console.WriteLine("]");
            }
            Console.WriteLine();
        }
    }
}
