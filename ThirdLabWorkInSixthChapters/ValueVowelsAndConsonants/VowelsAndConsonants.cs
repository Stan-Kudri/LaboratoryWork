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
        private readonly string _path;
        private char[] _charOffer;

        public VowelsAndConsonants(char[] charOffer)
        {
            _charOffer = charOffer;
        }

        public VowelsAndConsonants(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Файла не существует!!");
            _path = path;
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
            for (int i = 0; i < _charOffer.Length; i++)
            {
                if (vowelsChar.Any(x => x == _charOffer[i]))
                {
                    valueVowels++;
                }
                if (consonantsChar.Any(x => x == _charOffer[i]))
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
                _charOffer = str.ReadToEnd().ToCharArray();
                return str.ReadToEnd();
            }
        }

        private static char[] ReadFileContent(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Файла не существует!!");
            return new StreamReader(path).ReadToEnd().ToCharArray();
        }
    }
}
