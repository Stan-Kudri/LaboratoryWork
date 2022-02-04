/*Упражнение 6.1 Написать программу, которая вычисляет число гласных 
и согласных букв в файле. Имя файла передавать как аргумент в функцию 
Main. Содержимое текстового файла заносится в массив символов. Количество 
гласных и согласных букв определяется проходом по массиву. Предусмотреть 
метод, входным параметром которого является массив символов. Метод 
вычисляет количество гласных и согласных букв. 

Упражнение 6.2 Написать программу, реализующую умножению двух 
матриц, заданных в виде двумерного массива. В программе предусмотреть два 
метода: метод печати матрицы, метод умножения матриц (на вход две матрицы,
возвращаемое значение – матрица).

Упражнение 6.3 Написать программу, вычисляющую среднюю 
температуру за год. Создать двумерный рандомный массив temperature[12,30], в
котором будет храниться температура для каждого дня месяца (предполагается,
что в каждом месяце 30 дней). Сгенерировать значения температур случайным 
образом. Для каждого месяца распечатать среднюю температуру. Для этого 
написать метод, который по массиву temperature [12,30] для каждого месяца 
вычисляет среднюю температуру в нем, и в качестве результата возвращает 
массив средних температур. Полученный массив средних температур 
отсортировать по возрастанию.

Домашнее задание 6.1 Упражнение 6.1 выполнить с помощью коллекции 
List<T>.

Домашнее задание 6.2 Упражнение 6.2 выполнить с помощью коллекций
LinkedList<LinkedList<T>>.

Домашнее задание 6.3 Написать программу для упражнения 6.3,
использовав класс Dictionary<TKey, TValue>. В качестве ключей выбрать 
строки – названия месяцев, а в качестве значений – массив значений 
температур по дням*/


using ThirdLabWorkInSixthChapters;
using ThirdLabWorkInSixthChapters.Matrix;

var first = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
var second = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
Print(first);
Print(second);
var multiply = new MatrixMultiplicationLinkedList(first, second);
var mmmm = new MatrixMultiplicationArray(first, second);
multiply.Multiplication();
multiply.Print();
mmmm.Multiplication();
mmmm.Print();

/* var themp = new ThermometerDictionary();
Console.WriteLine(themp.YearAverageTemperaturee());
var moth = themp.MonthlyAverageTemperature();
themp.Print();
PrintAverageTemperatures(moth);
Console.ReadLine();

var programm = new VowelsAndConsonants(@"C:\Text.txt");
var value = programm.CountValue();
Console.WriteLine($"vowels = {value.vowels}; consonants = {value.consonants}");

var first = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
var second = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
Print(first);
Print(second);
var multiply = new MatrixMultiplicationArray(first, second);
multiply.Print();
*/

void Print(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j == array.GetLength(1) - 1)
                Console.Write("{0}", array[i, j]);
            else
                Console.Write("{0},", array[i, j]);
        }
        Console.WriteLine("]");
    }
    Console.WriteLine();
}

void PrintAverageTemperatures(int[] averageTemperatures)
{
    Array.Sort(averageTemperatures);
    for (var i = 0; i < averageTemperatures.Length; i++)
    {
        Console.Write($"{averageTemperatures[i]};");
    }
}