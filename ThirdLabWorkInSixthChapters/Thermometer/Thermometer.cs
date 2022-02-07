namespace ThirdLabWorkInSixthChapters.Thermometer
{
    public class Thermometer
    {
        public Thermometer(int[,] array)
        {
            if (array.GetLength(0) != 12 && array.GetLength(1) != 30)
                throw new ArgumentException("Массив имеет не верную размерность, необходим 12х30!");
        }

        public Thermometer(int minTemperature, int maxTemperature) : this(CreateRandom(minTemperature, maxTemperature))
        {
        }

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
    }
}
