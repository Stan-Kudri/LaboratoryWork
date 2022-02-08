/*Упражнение 6.2 Написать программу, реализующую умножению двух 
матриц, заданных в виде двумерного массива. В программе предусмотреть два 
метода: метод печати матрицы, метод умножения матриц (на вход две матрицы,
возвращаемое значение – матрица).

Домашнее задание 6.2 Упражнение 6.2 выполнить с помощью коллекций
LinkedList<LinkedList<T>>.
*/

namespace ThirdLabWorkInSixthChapters.Matrix
{
    public class MatrixMultiplicationLinkedList : Matrix
    {
        private LinkedList<LinkedList<int>> _multiplicationMatrix;

        public MatrixMultiplicationLinkedList(int[,] firstMatrix, int[,] secondMatrix) : base(firstMatrix, secondMatrix)
        {
            _multiplicationMatrix = new LinkedList<LinkedList<int>>();
        }

        public override void Multiplication()
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

        public override void Print()
        {
            var strRows = _multiplicationMatrix.Select(row => "[" + string.Join(", ", row) + "]");
            Console.WriteLine(string.Join(Environment.NewLine, strRows));
        }

        public static void Run()
        {
            var first = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var second = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            var multiplyMatrix = new MatrixMultiplicationLinkedList(first, second);
            MatrixMultiplicationLinkedList.PrintArray(first);
            MatrixMultiplicationLinkedList.PrintArray(second);
            multiplyMatrix.Multiplication();
            multiplyMatrix.Print();
        }
    }
}
