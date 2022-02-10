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
    public class ThermometerArray : Thermometer
    {
        private readonly int[,] _calendarTemperature;

        public ThermometerArray(int[,] calendarTemperature)
        {
            ValidateSizeCalendar(calendarTemperature);
            _calendarTemperature = calendarTemperature;
        }

        public ThermometerArray(int minTemperature, int maxTemperature) : this(CreateRandom(minTemperature, maxTemperature))
        {
        }

        public ThermometerArray() : this(-25, 35)
        {
        }

        public override int[] MonthlyAverage()
        {
            var monthlyTemperature = new int[_calendarTemperature.GetLength(0)];
            for (var i = 0; i < _calendarTemperature.GetLength(0); i++)
            {
                monthlyTemperature[i] = 0;
                for (var j = 0; j < _calendarTemperature.GetLength(1); j++)
                {
                    monthlyTemperature[i] += _calendarTemperature[i, j];
                }
                monthlyTemperature[i] = monthlyTemperature[i] / _calendarTemperature.GetLength(1);
            }
            return monthlyTemperature;
        }

        public override int YearAverage()
        {
            var yearTemperaturee = 0;
            for (var i = 0; i < _calendarTemperature.GetLength(0); i++)
            {
                for (var j = 0; j < _calendarTemperature.GetLength(1); j++)
                {
                    yearTemperaturee += _calendarTemperature[i, j];
                }
            }
            return yearTemperaturee / (_calendarTemperature.GetLength(0) * _calendarTemperature.GetLength(1));
        }

        public override void PrintTemperatures()
        {
            for (int i = 0; i < _calendarTemperature.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < _calendarTemperature.GetLength(1); j++)
                {
                    if (j == _calendarTemperature.GetLength(1) - 1)
                        Console.Write("{0}", _calendarTemperature[i, j]);
                    else
                        Console.Write("{0},", _calendarTemperature[i, j]);
                }
                Console.WriteLine("]");
            }
            Console.WriteLine();
        }

        public static void Run()
        {
            var thermometer = new ThermometerArray();
            thermometer.PrintTemperatures();
            Console.WriteLine($"Средняя температура за год: {thermometer.YearAverage()}");
            Console.WriteLine();
            var mothValue = thermometer.MonthlyAverage();
            PrintAverageMonth(mothValue);
            Console.WriteLine();
        }
    }
}
