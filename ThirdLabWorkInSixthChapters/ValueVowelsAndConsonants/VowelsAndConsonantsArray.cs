/*Упражнение 6.1 Написать программу, которая вычисляет число гласных 
и согласных букв в файле. Имя файла передавать как аргумент в функцию 
Main. Содержимое текстового файла заносится в массив символов. Количество 
гласных и согласных букв определяется проходом по массиву. Предусмотреть 
метод, входным параметром которого является массив символов. Метод 
вычисляет количество гласных и согласных букв. 
*/

namespace ThirdLabWorkInSixthChapters.ValueVowelsAndConsonants
{
    public class VowelsAndConsonantsArray : VowelsAndConsonants
    {
        private readonly char[] _analyzeCharacters;

        public VowelsAndConsonantsArray(char[] analyzeCharacters) : base(analyzeCharacters)
        {
            _analyzeCharacters = analyzeCharacters;
        }

        public VowelsAndConsonantsArray(string path) : this(ReadFileContent(path))
        {
        }

        public (int vowels, int consonants) CountValue(char[] arrayChar)
        {
            return CountValue(new List<char>(arrayChar));
        }

        public (int vowels, int consonants) CountValue() => CountValue(_analyzeCharacters);

        public static void Run()
        {
            var vowelsAndConsonants = new VowelsAndConsonantsArray(@"C:\Text.txt");
            var typel = vowelsAndConsonants.CountValue();
            Console.WriteLine($"vowels = {typel.vowels}; consonants = {typel.consonants}");
        }
    }
}
