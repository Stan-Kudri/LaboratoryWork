/*Упражнение 6.2 Написать программу, реализующую умножению двух 
матриц, заданных в виде двумерного массива. В программе предусмотреть два 
метода: метод печати матрицы, метод умножения матриц (на вход две матрицы,
возвращаемое значение – матрица).
*/

namespace ThirdLabWorkInSixthChapters
{
    public class MatrixMultiplicationArray
    {
        private readonly int[,] _firstMatrix;
        private readonly int[,] _secondMatrix;
        private int[,] _multiplicationMatrix;

        public MatrixMultiplicationArray(int[,] firstMatrix, int[,] secondMatrix)
        {
            _firstMatrix = firstMatrix;
            _secondMatrix = secondMatrix;
            _multiplicationMatrix = new int[_firstMatrix.GetLength(0), _secondMatrix.GetLength(1)];
        }

        public void Multiplication()
        {
            if (_firstMatrix.GetLength(1) + 1 != _secondMatrix.GetLength(0) + 1)
                throw new ArgumentException("Matrices can not be multiplied!");
            for (int i = 0; i < _firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _secondMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < _secondMatrix.GetLength(0); k++)
                    {
                        _multiplicationMatrix[i, j] += _firstMatrix[i, k] * _secondMatrix[k, j];
                    }
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < _multiplicationMatrix.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < _multiplicationMatrix.GetLength(1); j++)
                {
                    if (j == _multiplicationMatrix.GetLength(1) - 1)
                        Console.Write("{0}", _multiplicationMatrix[i, j]);
                    else
                        Console.Write("{0},", _multiplicationMatrix[i, j]);
                }
                Console.WriteLine("]");
            }
            Console.WriteLine();
        }
    }
}
