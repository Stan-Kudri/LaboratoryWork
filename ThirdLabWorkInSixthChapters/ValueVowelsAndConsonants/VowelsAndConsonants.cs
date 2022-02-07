namespace ThirdLabWorkInSixthChapters.ValueVowelsAndConsonants
{
    public class VowelsAndConsonants
    {
        protected static readonly char[] _vowelsChar = { 'а', 'А', 'и', 'И', 'е', 'Е', 'ё', 'Ё', 'о', 'О', 'у', 'У', 'ы', 'Ы', 'э', 'Э', 'ю', 'Ю', 'я', 'Я' };
        protected static readonly char[] _consonantsChar = { 'б', 'Б', 'в', 'В', 'г', 'Г', 'д', 'Д', 'ж', 'Ж', 'з', 'З', 'й', 'Й', 'к', 'К', 'л', 'Л', 'м', 'М', 'н', 'Н', 'п', 'П', 'р', 'Р', 'с', 'С', 'т', 'Т', 'ф', 'Ф', 'х', 'Х', 'ц', 'Ц', 'ч', 'Ч', 'ш', 'Ш', 'щ', 'Щ' };

        public VowelsAndConsonants(char[] analyzeCharacters)
        {
            if (analyzeCharacters == null)
                throw new ArgumentNullException(nameof(analyzeCharacters));
        }

        public VowelsAndConsonants(string path) : this(ReadFileContent(path))
        {
        }

        protected static char[] ReadFileContent(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Файла не существует!!");
            using (StreamReader streamReader = new StreamReader(path))
            {
                return streamReader.ReadToEnd().ToCharArray();
            }
        }

        public (int vowels, int consonants) CountValue(List<char> listChar)
        {
            int valueVowels = 0;
            int valueConsonants = 0;
            foreach (char letter in listChar)
            {
                if (_vowelsChar.Any(x => char.ToLower(x) == letter))
                {
                    valueVowels++;
                }
                else if (_consonantsChar.Any(x => char.ToLower(x) == letter))
                {
                    valueConsonants++;
                }
            }
            return (valueVowels, valueConsonants);
        }
    }
}
