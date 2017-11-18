using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lecture5HomeWork
{

    /// <summary>
    /// 1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при этом цифра не может быть первой.
    /// а) без использования регулярных выражений;
    /// б) ** с использованием регулярных выражений.
    /// </summary>
    public static class Task1CheckLogPass
    {
        public static bool CheckLogPass(string login)
        {
            bool flag = false;
            char[] log = login.ToCharArray();

            for (int i = 0; i < log.Length; i++)
            {
                if (!(login.Length > 2 && ((char.IsNumber(log[i])) || (char.IsLetter(log[i])))))
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }


        public static bool CheckLogPassWithReg(string login)
        {
            bool flag = false;
            var rule = @"\b([A-Za-z][A-Za-z0-9]{2,9})\b";
            flag = Regex.IsMatch(login, rule);
            return flag;
        }
    }

    /// <summary>
    /// 2. Разработать методы для решения следующих задач. Дано сообщение:
    ///а) Вывести только те слова сообщения, которые содержат не более чем n букв;
    ///б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
    ///в) Найти самое длинное слово сообщения;
    ///г) Найти все самые длинные слова сообщения.
    ///Постараться разработать класс MyString.
    /// </summary>
    public class Task2WorkWithWords
    {
        private string CurrentString { get; set; }

        public Task2WorkWithWords(string inputString)
        {
            CurrentString = inputString;
        }

        public string OutputWordsWithLengthLessThenNeed(int wordLength)
        {
            string str = String.Empty;
            string[] strArray = CurrentString.Split(' ');
            string rule = @"\b[A-Za-z]{1," + wordLength + "}\b";

            for (int i = 0; i < strArray.Length; i++)
            {
                if (Regex.IsMatch(strArray[i], rule))
                {
                    str += strArray[i] + " ";
                }
            }
            return str;
        }

        public string DelWorldWitchEndsWithNeedSymbol(char symbol)
        {
            string str = String.Empty;
            string[] strArray = CurrentString.Split(' ');
            string rule = @"\b[A-Za-z]+[" + symbol.ToString() + "]\b";

            for (int i = 0; i < strArray.Length; i++)
            {
                if (!Regex.IsMatch(strArray[i], rule))
                {
                    str += strArray[i] + " ";
                }
            }
            return str;
        }

        public string FingLongestWord()
        {
            string str = String.Empty;
            string[] strArray = CurrentString.Split(' ');
            int maxLength = 0;
            string maxLengthWord = String.Empty;

            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length > maxLength)
                {
                    maxLength = strArray[i].Length;
                    maxLengthWord = strArray[i];
                }
            }

            str = "Самое длинное слово: " + maxLengthWord + " с количеством символов в нем: " + maxLength;
            return str;
        }
    }

    /// <summary>
    /// 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.
    ///а) с использованием методов C#
    ///б) * разработав собственный алгоритм
    ///Например:
    ///badc являются перестановкой abcd
    /// </summary>

    public class Task3CombinatoricalMethods
    {
        private string FirstString { get; set; }
        private string SecondString { get; set; }

        public Task3CombinatoricalMethods(string firstString, string secondString)
        {
            FirstString = firstString;
            SecondString = secondString;
        }

        public bool FindCombination()
        {
            bool flag = false;

            for (int i = 0; i < FirstString.Length; i++)
            {
                char[] charStr = FirstString.ToCharArray();
                char selectedChar = charStr[i];
                for (int j = 0; j < FirstString.Length - 1; j++)
                {
                    char tempChar;
                    tempChar = charStr[j+1];
                    charStr[j] = charStr[j + 1];
                    charStr[j + 1] = tempChar;

                    StringBuilder buildStr = new StringBuilder();
                    string outputStr = buildStr.Append(charStr).ToString();
                    if (outputStr.Equals(SecondString))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                { break; }
            }
            return flag;
        }
    }
}
