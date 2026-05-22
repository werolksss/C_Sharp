using System;

namespace BezopasnoeDelenie
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] results = new int[3];
            int index = 0;

            bool work = true;

            while (work)
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    int num1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введите второе число: ");
                    int num2 = Convert.ToInt32(Console.ReadLine());

                    int result = num1 / num2;
                    results[index] = result;
                    index++;

                    Console.WriteLine($"Результат: {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введите целое число");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Ошибка: деление на ноль невозможно");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Массив результатов заполнен, дальнейшие вычисления невозможны");
                    break;
                }
                finally
                {
                    Console.WriteLine("Попытка выполнения операции завершена");
                }

                Console.Write("Хотите продолжить? (да/нет): ");
                string answer = Console.ReadLine();

                if (answer.ToLower() != "да")
                {
                    work = false;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Сохраненные результаты:");

            for (int i = 0; i < index && i < results.Length; i++)
            {
                Console.WriteLine(results[i]);
            }

            Console.ReadKey();
        }
    }
}