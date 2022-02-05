/*
Упражнение 6.3 Написать программу, вычисляющую среднюю 
температуру за год. Создать двумерный рандомный массив temperature[12,30], в
котором будет храниться температура для каждого дня месяца (предполагается,
что в каждом месяце 30 дней). Сгенерировать значения температур случайным 
образом. Для каждого месяца распечатать среднюю температуру. Для этого 
написать метод, который по массиву temperature [12,30] для каждого месяца 
вычисляет среднюю температуру в нем, и в качестве результата возвращает 
массив средних температур. Полученный массив средних температур 
отсортировать по возрастанию.
*/

namespace ThirdLabWorkInSixthChapters.Thermometer
{
    public class Thermometer
    {
        private readonly int[,] _temperature;

        public int[,] Temperature => _temperature;

        public Thermometer(int[,] array)
        {
            if (array.GetLength(0) != 12 && array.GetLength(1) != 30)
                throw new ArgumentException("Массив имеет не верную размерность, необходим 12х30!");
            _temperature = array;
        }

        public Thermometer(int minTemperature, int maxTemperature) : this(CreateRandom(minTemperature, maxTemperature))
        {
        }

        public Thermometer() : this(-25, 35)
        {

        }

        private static int[,] CreateRandom(int minTemperature, int maxTemperature)
        {
            if (maxTemperature < minTemperature)
                throw new ArgumentException("Параметры температуры не верны");
            Random random = new Random();
            var temperature = new int[12, 30];
            for (var i = 0; i < temperature.GetLength(0); i++)
            {
                for (var j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = random.Next(minTemperature, maxTemperature);
                }
            }
            return temperature;
        }

        public int[] MonthlyAverage()
        {
            int[] monthlyTemperature = new int[_temperature.GetLength(0)];
            for (var i = 0; i < _temperature.GetLength(0); i++)
            {
                monthlyTemperature[i] = 0;
                for (var j = 0; j < _temperature.GetLength(1); j++)
                {
                    monthlyTemperature[i] += _temperature[i, j];
                }
                monthlyTemperature[i] = monthlyTemperature[i] / _temperature.GetLength(1);
            }
            return monthlyTemperature;
        }

        public int YearAverage()
        {
            var yearTemperaturee = 0;
            for (var i = 0; i < _temperature.GetLength(0); i++)
            {
                for (var j = 0; j < _temperature.GetLength(1); j++)
                {
                    yearTemperaturee += _temperature[i, j];
                }
            }
            return yearTemperaturee / (_temperature.GetLength(0) * _temperature.GetLength(1));
        }

        public void PrintAverageMonth(int[] averageTemperatures)
        {
            Console.WriteLine("Средняя темпрература по месяцам :{0};", String.Join(",", averageTemperatures));
        }

        public void PrintDayTemperature()
        {
            for (int i = 0; i < _temperature.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < _temperature.GetLength(1); j++)
                {
                    if (j == _temperature.GetLength(1) - 1)
                        Console.Write("{0}", _temperature[i, j]);
                    else
                        Console.Write("{0},", _temperature[i, j]);
                }
                Console.WriteLine("]");
            }
            Console.WriteLine();
        }

        public static void Run()
        {
            var thermometer = new Thermometer(-25, 35);
            thermometer.PrintDayTemperature();
            Console.WriteLine($"Средняя температура за год: {thermometer.YearAverage()}");
            Console.WriteLine();
            var mothValue = thermometer.MonthlyAverage();
            thermometer.PrintAverageMonth(mothValue);
            Console.WriteLine();
        }
    }
}
