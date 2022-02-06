/*Упражнение 6.1 Написать программу, которая вычисляет число гласных 
и согласных букв в файле. Имя файла передавать как аргумент в функцию 
Main. Содержимое текстового файла заносится в массив символов. Количество 
гласных и согласных букв определяется проходом по массиву. Предусмотреть 
метод, входным параметром которого является массив символов. Метод 
вычисляет количество гласных и согласных букв. 

Домашнее задание 6.1 Упражнение 6.1 выполнить с помощью коллекции 
List<T>.
*/

namespace ThirdLabWorkInSixthChapters.ValueVowelsAndConsonants
{
    public class VowelsAndConsonantsList
    {
        private readonly List<char> _analyzeCharacters;
        private static readonly char[] _vowelsChar = { 'а', 'А', 'и', 'И', 'е', 'Е', 'ё', 'Ё', 'о', 'О', 'у', 'У', 'ы', 'Ы', 'э', 'Э', 'ю', 'Ю', 'я', 'Я' };
        private static readonly char[] _consonantsChar = { 'б', 'Б', 'в', 'В', 'г', 'Г', 'д', 'Д', 'ж', 'Ж', 'з', 'З', 'й', 'Й', 'к', 'К', 'л', 'Л', 'м', 'М', 'н', 'Н', 'п', 'П', 'р', 'Р', 'с', 'С', 'т', 'Т', 'ф', 'Ф', 'х', 'Х', 'ц', 'Ц', 'ч', 'Ч', 'ш', 'Ш', 'щ', 'Щ' };

        public VowelsAndConsonantsList(char[] analyzeCharacters)
        {
            _analyzeCharacters = new List<char>(analyzeCharacters);
        }

        public VowelsAndConsonantsList(string path) : this(FileDataLine(path))
        {
            if (!File.Exists(path))
                throw new Exception("Файла не существует!!");
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

        public (int vowels, int consonants) CountValue() => CountValue(_analyzeCharacters);

        private static char[] FileDataLine(string path)
        {
            if (path == null)
                throw new Exception("Путь не установлен");
            using (StreamReader str = new StreamReader(path))
            {
                return str.ReadToEnd().ToCharArray();
            }
        }
        public static void Run()
        {
            var vowelsAndConsonants = new VowelsAndConsonants(@"C:\Text.txt");
            var typel = vowelsAndConsonants.CountValue();
            Console.WriteLine($"vowels = {typel.vowels}; consonants = {typel.consonants}");
        }
    }
}
