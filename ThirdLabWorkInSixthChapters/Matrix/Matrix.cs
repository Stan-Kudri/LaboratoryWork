namespace ThirdLabWorkInSixthChapters.Matrix
{
    public abstract class Matrix
    {
        protected readonly int[,] _firstMatrix;
        protected readonly int[,] _secondMatrix;

        public Matrix(int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) + 1 != secondMatrix.GetLength(0) + 1)
                throw new ArgumentException("Матрицы таких размерностей не перемножить!");
            _firstMatrix = firstMatrix;
            _secondMatrix = secondMatrix;
        }

        public abstract void Print();
        public abstract void Multiplication();

        protected static void PrintArray(int[,] matrix)
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

    }
}
