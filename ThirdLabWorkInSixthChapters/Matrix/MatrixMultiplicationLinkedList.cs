/*Упражнение 6.2 Написать программу, реализующую умножению двух 
матриц, заданных в виде двумерного массива. В программе предусмотреть два 
метода: метод печати матрицы, метод умножения матриц (на вход две матрицы,
возвращаемое значение – матрица).

Домашнее задание 6.2 Упражнение 6.2 выполнить с помощью коллекций
LinkedList<LinkedList<T>>.
*/

namespace ThirdLabWorkInSixthChapters.Matrix
{
    public class MatrixMultiplicationLinkedList
    {
        private readonly int[,] _firstMatrix;
        private readonly int[,] _secondMatrix;
        private LinkedList<LinkedList<int>> _multiplicationMatrix;

        public MatrixMultiplicationLinkedList(int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) + 1 != secondMatrix.GetLength(0) + 1)
                throw new ArgumentException("Матрицы таких размерностей не перемножить!");
            _firstMatrix = firstMatrix;
            _secondMatrix = secondMatrix;
            _multiplicationMatrix = new LinkedList<LinkedList<int>>();
        }

        public void Multiplication()
        {
            for (int i = 0; i < _firstMatrix.GetLength(0); i++)
            {
                LinkedList<int> line = new();
                for (int j = 0; j < _secondMatrix.GetLength(1); j++)
                {
                    var product = 0;
                    for (int k = 0; k < _secondMatrix.GetLength(0); k++)
                    {
                        product += _firstMatrix[i, k] * _secondMatrix[k, j];
                    }
                    line.AddLast(product);
                }
                _multiplicationMatrix.AddLast(line);
            }
        }

        public void PrintArray(int[,] matrix)
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
            var strRows = _multiplicationMatrix.Select(row => "[" + string.Join(", ", row) + "]");
            Console.WriteLine(string.Join(Environment.NewLine, strRows));
        }

        public static void Run()
        {
            var first = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var second = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            var multiplyMatrix = new MatrixMultiplicationLinkedList(first, second);
            multiplyMatrix.PrintArray(first);
            multiplyMatrix.PrintArray(second);
            multiplyMatrix.Multiplication();
            multiplyMatrix.Print();
        }
    }
}
