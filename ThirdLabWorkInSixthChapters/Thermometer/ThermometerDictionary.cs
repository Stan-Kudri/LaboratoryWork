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
        private readonly string[] _month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public ThermometerDictionary()
        {
            Random random = new Random();
            _temperature = new Dictionary<string, int[]>();
            int[] dayTemperature = new int[30];
            for (var i = 0; i < _month.Length; i++)
            {
                for (var j = 0; j < dayTemperature.Length; j++)
                {
                    dayTemperature[j] = random.Next(-25, 25);
                }
                _temperature.Add(_month[i], dayTemperature);
                dayTemperature = new int[dayTemperature.Length];
            }
        }

        public Dictionary<string, int> MonthlyAverageTemperature()
        {
            Dictionary<string, int> monthTemperature = new Dictionary<string, int>();
            foreach (var month in _temperature.Keys)
            {
                var value = (int)_temperature[month].Average();
                monthTemperature.Add(month, value);
            }
            return monthTemperature;
        }

        public int YearAverageTemperaturee() => (int)_temperature.Values.ToArray().Average(x => x.Average());

        public void PrintTemperatures()
        {
            foreach (var month in _temperature.Keys)
            {
                Console.WriteLine($"{month} : {String.Join("; ", _temperature[month])}");
            }
        }

        public void PrintAverageTemperatures(Dictionary<string, int> avarageMonth)
        {
            foreach (var month in avarageMonth.Keys)
            {
                Console.WriteLine($"{month} в среднем была температура {avarageMonth[month]}");
            }
        }

        public static void Run()
        {
            var thermometer = new ThermometerDictionary();
            Console.WriteLine(thermometer.YearAverageTemperaturee());
            thermometer.PrintTemperatures();
            var mothValue = thermometer.MonthlyAverageTemperature();
            thermometer.PrintAverageTemperatures(mothValue);

        }
    }
}
