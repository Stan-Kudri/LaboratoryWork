namespace ThirdLabWorkInSixthChapters.Thermometer
{
    public abstract class Thermometer
    {
        protected static int[,] CreateRandom(int minTemperature, int maxTemperature)
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

        protected static void PrintAverageMonth(int[] averageTemperatures)
        {
            Console.WriteLine("Средняя темпрература по месяцам :{0};", String.Join(",", averageTemperatures));
        }

        protected static void ValidateSizeCalendar(int[,] calendarTemperature)
        {
            if (calendarTemperature == null)
                throw new ArgumentNullException(nameof(calendarTemperature));
            if (calendarTemperature.GetLength(0) != 12 && calendarTemperature.GetLength(1) != 30)
                throw new ArgumentException("Массив имеет не верную размерность, необходим 12х30!");
        }

        public abstract int[] MonthlyAverage();

        public abstract int YearAverage();

        public abstract void PrintTemperatures();
    }
}
