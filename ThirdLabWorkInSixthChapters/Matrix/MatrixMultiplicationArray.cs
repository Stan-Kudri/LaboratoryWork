/*Упражнение 6.2 Написать программу, реализующую умножению двух 
матриц, заданных в виде двумерного массива. В программе предусмотреть два 
метода: метод печати матрицы, метод умножения матриц (на вход две матрицы,
возвращаемое значение – матрица).
*/

namespace ThirdLabWorkInSixthChapters.Matrix
{
    public class MatrixMultiplicationArray : Matrix
    {
        private int[,] _multiplicationMatrix;

        public MatrixMultiplicationArray(int[,] firstMatrix, int[,] secondMatrix) : base(firstMatrix, secondMatrix)
        {
            _multiplicationMatrix = new int[_firstMatrix.GetLength(0), _secondMatrix.GetLength(1)];
        }

        public override void Multiplication()
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

        public void Print()
        {
            PrintArray(_multiplicationMatrix);
        }

        public static void Run()
        {
            var first = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var second = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            var multiplyMatrix = new MatrixMultiplicationArray(first, second);
            MatrixMultiplicationArray.PrintArray(first);
            MatrixMultiplicationArray.PrintArray(second);
            multiplyMatrix.Multiplication();
            multiplyMatrix.Print();
        }
    }
}
