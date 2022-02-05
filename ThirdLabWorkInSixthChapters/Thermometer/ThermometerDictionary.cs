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


Домашнее задание 6.3 Написать программу для упражнения 6.3,
использовав класс Dictionary<TKey, TValue>. В качестве ключей выбрать 
строки – названия месяцев, а в качестве значений – массив значений 
температур по дням*/

namespace ThirdLabWorkInSixthChapters.Thermometer
{
    public class ThermometerDictionary
    {
        private readonly Dictionary<string, int[]> _temperature;
        private static readonly string[] _month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public ThermometerDictionary(int[,] array)
        {
            if (array.GetLength(0) != 12 && array.GetLength(1) != 30)
                throw new ArgumentException("Массив имеет не верную размерность, необходим 12х30!");
            _temperature = new Dictionary<string, int[]>();
            int[] dayTemperature = new int[30];
            for (var i = 0; i < _month.Length; i++)
            {
                for (var j = 0; j < dayTemperature.Length; j++)
                {
                    dayTemperature[j] = array[i, j];
                }
                _temperature.Add(_month[i], dayTemperature);
                dayTemperature = new int[dayTemperature.Length];
            }
        }

        public ThermometerDictionary(int minTemperature, int maxTemperature) : this(CreateRandom(minTemperature, maxTemperature))
        {
        }

        public ThermometerDictionary() : this(-25, 35)
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
            var monthTemperature = new int[12];
            for (var i = 0; i < monthTemperature.Length; i++)
            {
                monthTemperature[i] = (int)_temperature.ElementAt(i).Value.Average();
            }
            return monthTemperature;
        }

        public int YearAverage() => (int)_temperature.Values.Average(x => x.Average());

        public void PrintTemperatures()
        {
            foreach (var month in _temperature.Keys)
            {
                Console.WriteLine($"{month} : {String.Join(";", _temperature[month])}");
            }
        }

        private static void PrintAverageMonth(int[] avarageMonth)
        {

            for (var i = 0; i < avarageMonth.Length; i++)
            {
                Console.WriteLine($"{_month[i]} в среднем была температура {avarageMonth[i]}");
            }
        }

        public static void Run()
        {
            var thermometer = new ThermometerDictionary();
            Console.WriteLine($"Средняя температура за год: {thermometer.YearAverage()}");
            Console.WriteLine();
            thermometer.PrintTemperatures();
            var mothValue = thermometer.MonthlyAverage();
            PrintAverageMonth(mothValue);
            Console.WriteLine();

        }
    }
}
