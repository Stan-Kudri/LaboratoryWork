/*Упражнение 6.2 Написать программу, реализующую умножению двух 
матриц, заданных в виде двумерного массива. В программе предусмотреть два 
метода: метод печати матрицы, метод умножения матриц (на вход две матрицы,
возвращаемое значение – матрица).
*/

namespace ThirdLabWorkInSixthChapters.Matrix
{
    public class MatrixMultiplicationArray
    {
        private readonly int[,] _firstMatrix;
        private readonly int[,] _secondMatrix;
        private int[,] _multiplicationMatrix;

        public MatrixMultiplicationArray(int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) + 1 != secondMatrix.GetLength(0) + 1)
                throw new ArgumentException("Матрицы таких размерностей не перемножить!");
            _firstMatrix = firstMatrix;
            _secondMatrix = secondMatrix;
            _multiplicationMatrix = new int[_firstMatrix.GetLength(0), _secondMatrix.GetLength(1)];
        }

        public void Multiplication()
        {
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

        public void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                        Console.Write("{0}", matrix[i, j]);
                    else
                        Console.Write("{0},", matrix[i, j]);
                }
                Console.WriteLine("]");
            }
            Console.WriteLine();
        }

        public void Print()
        {
            Print(_multiplicationMatrix);
        }

        public static void Run()
        {
            var first = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var second = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            var multiplyMatrix = new MatrixMultiplicationArray(first, second);
            multiplyMatrix.Print(first);
            multiplyMatrix.Print(second);
            multiplyMatrix.Multiplication();
            multiplyMatrix.Print();
        }
    }
}
