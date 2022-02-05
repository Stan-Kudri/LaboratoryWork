﻿/*Упражнение 6.1 Написать программу, которая вычисляет число гласных 
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
        private readonly string _path;
        private List<char> _charOffer;

        public VowelsAndConsonantsList()
        {
        }

        public VowelsAndConsonantsList(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Файла не существует!!");
            _path = path;
            RecordingCharFrom();
        }

        public (int vowels, int consonants) CountValue(List<char> listChar)
        {
            char[] vowelsChar = new char[] { 'а', 'и', 'е', 'ё', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            char[] consonantsChar = new char[] { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
            int valueVowels = 0;
            int valueConsonants = 0;
            foreach (char letter in listChar)
            {
                if (vowelsChar.Any(x => x == letter))
                    valueVowels++;
                if (consonantsChar.Any(x => x == letter))
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
            foreach (char letter in _charOffer)
            {
                if (vowelsChar.Any(x => x == letter))
                    valueVowels++;
                if (consonantsChar.Any(x => x == letter))
                    valueConsonants++;
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

        private void RecordingCharFrom() => _charOffer = FileDataLine().ToList();
    }
}
