namespace ThirdLabWorkInSixthChapters.Thermometer
{
    public class ThermometerDictionary
    {
        private readonly Dictionary<string, int[]> _temperature;
        private readonly string[] month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public ThermometerDictionary()
        {
            Random random = new Random();
            _temperature = new Dictionary<string, int[]>();
            int[] dayTemperature = new int[30];
            for (var i = 0; i < month.Length; i++)
            {
                for (var j = 0; j < dayTemperature.Length; j++)
                {
                    dayTemperature[j] = random.Next(-25, 25);
                }
                _temperature.Add(month[i], dayTemperature);
                dayTemperature = new int[dayTemperature.Length];
            }
        }

        public int[] MonthlyAverageTemperature()
        {
            Dictionary<string, int> monthTemperature = new Dictionary<string, int>();
            foreach (var month in _temperature.Keys)
            {
                var value = (int)_temperature[month].Average();
                monthTemperature.Add(month, value);
            }
            return monthTemperature.Values.ToArray();
        }

        public int YearAverageTemperaturee() => (int)_temperature.Values.ToArray().Average(x => x.Average());

        public void Print()
        {
            foreach (var month in _temperature.Keys)
            {
                Console.WriteLine($"{month} : {String.Join("; ", _temperature[month])}");
            }
        }
    }
}
