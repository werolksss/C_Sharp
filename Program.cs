using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Statistika
{
    class Program
    {
        static void Main(string[] args)
        {
            // Текст
            string text = @"Вот дом, Который построил Джек. 
            А это пшеница, Которая в темном чулане хранится
            В доме, Который построил Джек.
            А это веселая птица-синица,
            Которая часто ворует пшеницу, 
            Которая в темном чулане хранится 
            В доме, Который построил Джек.";

            Dictionary<string, int> slovar = PodschetSlov(text);

            VivodTablici(slovar);

            Console.ReadKey();
        }
        // метод подсчета слов
        static Dictionary<string, int> PodschetSlov(string text)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            // удаление знаков препинания
            string textBezZnakov = Regex.Replace(text, @"[^\w\s]", "");
            // разделение текста на слова
            string[] slova = textBezZnakov.Split(
                new char[] { ' ', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries
            );
            // подсчет слов
            foreach (string slovo in slova)
            {
                string nizhniyRegistr = slovo.ToLower();

                if (result.ContainsKey(nizhniyRegistr))
                {
                    result[nizhniyRegistr]++;
                }
                else
                {
                    result.Add(nizhniyRegistr, 1);
                }
            }

            return result;
        }
        static void VivodTablici(Dictionary<string, int> slovar)
        {
            Console.WriteLine("Слово\t\tКоличество");
            Console.WriteLine("--------------------------");

            foreach (var element in slovar)
            {
                Console.WriteLine($"{element.Key}\t\t{element.Value}");
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine($"Уникальных слов: {slovar.Count}");
        }
    }
}