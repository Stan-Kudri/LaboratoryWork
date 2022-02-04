namespace ThirdLabWorkInSixthChapters.ValueVowelsAndConsonants
{
    public class VowelsAndConsonants
    {
        private readonly string _path;
        private char[] array;

        public char[] Array
        {
            get { return array; }
            set { array = value; }
        }

        public VowelsAndConsonants()
        {
        }

        public VowelsAndConsonants(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Файла не существует!!");
            _path = path;
            RecordingCharFrom();
        }

        public (int vowels, int consonants) CountValue(char[] arrayChar)
        {
            char[] vowelsChar = new char[] { 'а', 'и', 'е', 'ё', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            char[] consonantsChar = new char[] { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
            int valueVowels = 0;
            int valueConsonants = 0;
            for (int i = 0; i < arrayChar.Length; i++)
            {
                if (vowelsChar.Any(x => x == arrayChar[i]))
                    valueVowels++;
                if (consonantsChar.Any(x => x == arrayChar[i]))
                    valueConsonants++;
            }
            return (valueVowels, valueConsonants);
        }

        public (int vowels, int consonants) CountValue()
        {
            char[] vowelsChar = new char[] { 'а', 'и', 'е', 'ё', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            char[] consonantsChar = new char[] { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
            int valueVowels = 0;
            int valueConsonants = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (vowelsChar.Any(x => x == array[i]))
                {
                    valueVowels++;
                }
                if (consonantsChar.Any(x => x == array[i]))
                {
                    valueConsonants++;
                }
            }
            return (valueVowels, valueConsonants);
        }

        private string FileDataLine()
        {
            if (_path == null)
                throw new Exception("Путь не установлен");
            using (StreamReader str = new StreamReader(_path))
            {
                return str.ReadToEnd();
            }
        }

        private void RecordingCharFrom() => array = FileDataLine().ToCharArray();
    }
}
