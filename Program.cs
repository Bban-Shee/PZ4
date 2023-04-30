using System;
using System.Collections.Generic;
using System.Linq;

namespace PZ4
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Введення першого слова
            Console.Write("Введiть перше слово: ");
            string s1 = Console.ReadLine();
            //Перевірка: чи всі символи введеного рядка є літерами
            while (Chek(s1) == false)
            {
                Console.Write("Ви помилились! Слово повинно складатись тiльки з лiтер!\nВведiть перше слово знову: ");
                s1 = Console.ReadLine();
            }
            //Введення другого слова
            Console.Write("Введiть друге слово: ");
            string s2 = Console.ReadLine();
            //Перевірка: чи всі символи введеного рядка є літерами
            while (Chek(s2) == false)
            {
                Console.Write("Ви помилились! Слово повинно складатись тiльки з лiтер!\nВведiть друге слово знову: ");
                s2 = Console.ReadLine();
            }

            //Створення списку літер, які зустрічаються лише в одному зі слів
            var letters = Compare(s1, s2);
            letters.AddRange(Compare(s2, s1));
            //Видалення повторюваних літер та сортування їх в алфавітному порядку
            var dist = letters.Distinct();
            var result = new List<char>();
            result.AddRange(dist);
            result.Sort();
            //Виведення літер, які є лише в одному зi слiв, або повідомлення про їх відсутність
            if(result.Count == 0) Console.Write("\nУсi лiтери, з яких складається перше та друге слово, є в обох словах!\n");
            else
            {
                Console.Write("\nЛiтери, якi є лише в одному зi слiв: ");
                for (int i = 0; i < result.Count; i++)
                {
                    if (i == result.Count - 1) Console.Write(result[i] + "\n");
                    else Console.Write(result[i] + ", ");
                }
            } 
        }

        //Метод для перевірки: чи всі символи введеного рядка є літерами
        public static bool Chek(string s)
        {
            bool NoInt = true;
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]) == false)
                {
                    NoInt = false;
                    break;
                }
            }
            return NoInt;
        }

        //Метод для створення списку літер, які зустрічаються лише в одному зі слів
        public static List<char> Compare(string s1, string s2)
        {
            var letters = new List<char>();
            char[] chars1 = s1.ToCharArray();
            char[] chars2 = s2.ToCharArray();
            bool IsUniq = true;
            for (int i = 0; i < chars1.Length; i++)
            {
                for (int j = 0; j < chars2.Length; j++)
                {
                    if (chars1[i].CompareTo(chars2[j]) == 0)
                    {
                        IsUniq = false;
                        break;
                    }
                }
                if (IsUniq) letters.Add(chars1[i]);
                IsUniq = true;
            }
            return letters;
        }
    }
}