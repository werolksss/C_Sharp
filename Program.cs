using System;
using System.Collections.Generic;
using System.Threading;

namespace Gonki
{
    // делегат
    delegate void GonkaDelegate(string message);
    // абстрактный класс
    abstract class Avtomobil
    {
        public string Nazvanie { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }

        protected Random rnd = new Random();

        // событие финиша
        public event Action<string> Finish;

        public Avtomobil(string name)
        {
            Nazvanie = name;
            Distance = 0;
        }

        // метод движения
        public virtual void Ehat()
        {
            Speed = rnd.Next(5, 20);
            Distance += Speed;

            Console.WriteLine($"{Nazvanie} проехал {Distance} км");

            // проверка финиша
            if (Distance >= 100)
            {
                Finish?.Invoke(Nazvanie);
            }
        }
    }

    // спортивная
    class SportCar : Avtomobil
    {
        public SportCar(string name) : base(name) { }
    }

    // легковая
    class Legkovaya : Avtomobil
    {
        public Legkovaya(string name) : base(name) { }
    }

    // грузовая
    class Gruzovaya : Avtomobil
    {
        public Gruzovaya(string name) : base(name) { }
    }

    // автобус
    class Avtobus : Avtomobil
    {
        public Avtobus(string name) : base(name) { }
    }

    class Program
    {
        static bool gameOver = false;

        static void Main(string[] args)
        {
            GonkaDelegate start = StartMessage;

            // машины
            List<Avtomobil> cars = new List<Avtomobil>()
            {
                new SportCar("Ferrari"),
                new Legkovaya("Toyota"),
                new Gruzovaya("Kamaz"),
                new Avtobus("Scania ")
            };

            foreach (var car in cars)
            {
                car.Finish += FinishRace;
            }

            //старт
            start("Гонка началась!");

            //игра
            while (!gameOver)
            {
                foreach (var car in cars)
                {
                    car.Ehat();

                    if (gameOver)
                        break;
                }

                Console.WriteLine("--------------------------");

                Thread.Sleep(500);
            }

            Console.ReadKey();
        }
        // старт
        static void StartMessage(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine();
        }
        // финиш
        static void FinishRace(string winner)
        {
            Console.WriteLine();
            Console.WriteLine($"Победитель: {winner}");
            gameOver = true;
        }
    }
}