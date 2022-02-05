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
            _firstMatrix = firstMatrix;
            _secondMatrix = secondMatrix;
            _multiplicationMatrix = new LinkedList<LinkedList<int>>();
        }

        public void Multiplication()
        {
            if (_firstMatrix.GetLength(1) + 1 != _secondMatrix.GetLength(0) + 1)
                throw new ArgumentException("Matrices can not be multiplied!");
            LinkedList<int> list = new();
            for (int i = 0; i < _firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _secondMatrix.GetLength(1); j++)
                {
                    var valueCell = 0;
                    for (int k = 0; k < _secondMatrix.GetLength(0); k++)
                    {
                        valueCell += _firstMatrix[i, k] * _secondMatrix[k, j];
                    }
                    list.AddLast(valueCell);
                }
                _multiplicationMatrix.AddLast(new LinkedList<int>(list));
                list.Clear();

            }
        }

        public void Print()
        {
            foreach (var item in _multiplicationMatrix)
            {
                Console.WriteLine($"[{String.Join("; ", item.ToArray())}]");

            }
            Console.WriteLine();
        }

        public void Run()
        {

        }
    }
}
