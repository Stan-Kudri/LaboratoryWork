namespace ThirdLabWorkInSixthChapters.Thermometer
{
    public class Thermometer
    {
        private readonly int[,] _temperature;

        public int[,] Temperature
        {
            get { return _temperature; }
        }

        public Thermometer()
        {
            Random random = new Random();
            _temperature = new int[12, 30];
            for (var i = 0; i < _temperature.GetLength(0); i++)
            {
                for (var j = 0; j < _temperature.GetLength(1); j++)
                {
                    _temperature[i, j] = random.Next(-25, 35);
                }
            }
        }

        public int[] MonthlyAverageTemperature()
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

        public int YearAverageTemperaturee()
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

        public void PrintAverageTemperatures(int[] averageTemperatures)
        {
            Array.Sort(averageTemperatures);
            for (var i = 0; i < averageTemperatures.Length; i++)
            {
                Console.Write($"{averageTemperatures[i]};");
            }
        }

        public static void Run()
        {
            var thermometer = new Thermometer();
            Console.WriteLine(thermometer.YearAverageTemperaturee());
            var mothValue = thermometer.MonthlyAverageTemperature();
            thermometer.PrintAverageTemperatures(mothValue);
        }
    }
}
