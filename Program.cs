using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lecture5HomeWork
{
    public static class Task1UserInterface
    {
        public static void TaskN1()
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-2]";
            Console.Write("Введите логин для проверки:");
            string login = Console.ReadLine();

            Console.WriteLine("Каким алгоритмом вы бы хотели проверить логин?");
            Console.WriteLine("\t1. Алгоритмом С#.");
            Console.WriteLine("\t2. Регулярными выражениями.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        if (Task1CheckLogPass.CheckLogPass(login))
                        {
                            Console.WriteLine("Логин корректен");
                            Console.ReadKey();
                        }
                        break;
                    case '2':
                        if (Task1CheckLogPass.CheckLogPassWithReg(login))
                        {
                            Console.WriteLine("Логин корректен");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }
    }

    public static class Task2UserInterface
    {

        public static void TaskN2()
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-3]";
            Console.Write("Введите сообщение:");
            string str = Console.ReadLine();
            Task2WorkWithWords t2 = new Task2WorkWithWords(str);

            Console.WriteLine("Что бы вы хотели сделать с сообщением?");
            Console.WriteLine("\t1. Найти все слова, символов в кототм меньше чем задает пользователь.");
            Console.WriteLine("\t2. Удалить все слова которые заканчиваются на поеределенный символ.");
            Console.WriteLine("\t2. Найти самое длинное слово.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        Console.Write("Введите необходимое количество символов в слове:");
                        t2.OutputWordsWithLengthLessThenNeed(int.Parse(Console.ReadLine()));
                        break;
                    case '2':
                        Console.Write("Введите символ:");
                        t2.DelWorldWitchEndsWithNeedSymbol(Convert.ToChar(Console.ReadLine()));
                        break;
                    case '3':
                        Console.Write("Самое большое количество символов в слове: " + t2.FingLongestWord());
                        break;
                }
            }
        }
    }


    class Program
    {



        static void Main(string[] args)
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-3]";

            Console.WriteLine("Добрый день, уважаемый пользователь. Демонстрацию работы какой программы вы бы хотели увидеть?");
            Console.WriteLine("\t1. Программа проверки логина на корректность.");
            Console.WriteLine("\t2. Программа работы с введенным сообщением.");
            Console.WriteLine("\t3. Программа определения, является ли одна строка перебором другой.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        Task1UserInterface.TaskN1();
                        break;
                    case '2':
                        Task2UserInterface.TaskN2();
                        break;
                    case '3':
                        Task3CombinatoricalMethods t3 = new Task3CombinatoricalMethods("abcd", "bcda");
                        break;
                }
            }
        }
    }
}
