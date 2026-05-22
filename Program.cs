using System;

namespace BankAccountApp
{
    // искл нев суммы
    class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message)
            : base(message)
        {
        }
    }
    // искл недостатка средств
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message)
            : base(message)
        {
        }
    }
    // банковский счет
    class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        //конструктор
        public BankAccount(decimal startBalance = 0)
        {
            if (startBalance < 0)
            {
                throw new InvalidAmountException(
                    "Начальный баланс не может быть отрицательным");
            }

            Random rnd = new Random();

            AccountNumber = "ACCT-" + rnd.Next(1000, 9999);

            Balance = startBalance;
        }

        // пополнение
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException(
                    "Сумма пополнения должна быть положительной");
            }

            Balance += amount;
        }
        //снятие
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException(
                    "Сумма снятия должна быть положительной");
            }

            if (amount > Balance)
            {
                throw new InsufficientFundsException(
                    "Недостаточно средств на счете");
            }

            Balance -= amount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount();

                bool work = true;

                while (work)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Номер счета: {account.AccountNumber}");
                    Console.WriteLine("1 - Пополнить");
                    Console.WriteLine("2 - Снять");
                    Console.WriteLine("3 - Показать баланс");
                    Console.WriteLine("4 - Выход");

                    Console.Write("Выберите действие: ");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Введите сумму пополнения: ");
                                decimal add = Convert.ToDecimal(Console.ReadLine());

                                account.Deposit(add);

                                Console.WriteLine("Счет успешно пополнен");
                                break;

                            case 2:
                                Console.Write("Введите сумму снятия: ");
                                decimal minus = Convert.ToDecimal(Console.ReadLine());

                                account.Withdraw(minus);

                                Console.WriteLine("Деньги успешно сняты");
                                break;

                            case 3:
                                Console.WriteLine(
                                    $"Баланс: {account.Balance:F2}");
                                break;

                            case 4:
                                work = false;
                                break;

                            default:
                                Console.WriteLine("Неверный выбор");
                                break;
                        }
                    }
                    catch (InvalidAmountException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    catch (InsufficientFundsException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Общая ошибка: {ex.Message}");
                    }

                    Console.WriteLine(
                        $"Текущий баланс: {account.Balance:F2}");
                }
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}