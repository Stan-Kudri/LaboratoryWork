/*Упражнение 6.1 Написать программу, которая вычисляет число гласных 
и согласных букв в файле. Имя файла передавать как аргумент в функцию 
Main. Содержимое текстового файла заносится в массив символов. Количество 
гласных и согласных букв определяется проходом по массиву. Предусмотреть 
метод, входным параметром которого является массив символов. Метод 
вычисляет количество гласных и согласных букв. 
*/

namespace ThirdLabWorkInSixthChapters.ValueVowelsAndConsonants
{
    public class VowelsAndConsonants
    {
        private readonly char[] _analyzeCharacters;
        private static readonly char[] _vowelsChar = { 'а', 'А', 'и', 'И', 'е', 'Е', 'ё', 'Ё', 'о', 'О', 'у', 'У', 'ы', 'Ы', 'э', 'Э', 'ю', 'Ю', 'я', 'Я' };
        private static readonly char[] _consonantsChar = { 'б', 'Б', 'в', 'В', 'г', 'Г', 'д', 'Д', 'ж', 'Ж', 'з', 'З', 'й', 'Й', 'к', 'К', 'л', 'Л', 'м', 'М', 'н', 'Н', 'п', 'П', 'р', 'Р', 'с', 'С', 'т', 'Т', 'ф', 'Ф', 'х', 'Х', 'ц', 'Ц', 'ч', 'Ч', 'ш', 'Ш', 'щ', 'Щ' };

        public VowelsAndConsonants(char[] _analyzeCharacters)
        {
            this._analyzeCharacters = _analyzeCharacters ?? throw new ArgumentNullException(nameof(_analyzeCharacters));
        }

        public VowelsAndConsonants(string path) : this(ReadFileContent(path))
        {
        }

        private static char[] ReadFileContent(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Файла не существует!!");
            using (StreamReader streamReader = new StreamReader(path))
            {
                return streamReader.ReadToEnd().ToCharArray();
            }
        }

        public (int vowels, int consonants) CountValue(char[] arrayChar)
        {
            int valueVowels = 0;
            int valueConsonants = 0;
            for (int i = 0; i < arrayChar.Length; i++)
            {
                if (_vowelsChar.Any(x => x == arrayChar[i]))
                    valueVowels++;
                else if (_consonantsChar.Any(x => x == arrayChar[i]))
                    valueConsonants++;
            }
            return (valueVowels, valueConsonants);
        }

        public (int vowels, int consonants) CountValue() => CountValue(_analyzeCharacters);

        public static void Run()
        {
            var vowelsAndConsonants = new VowelsAndConsonants(@"C:\Text.txt");
            var typel = vowelsAndConsonants.CountValue();
            Console.WriteLine($"vowels = {typel.vowels}; consonants = {typel.consonants}");
        }
    }
}
