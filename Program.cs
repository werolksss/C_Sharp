using System;

//абстрактный класс товар
abstract class Tovar
{
    public string Nazvanie;
    public double Cena;
    public int Kolichestvo;

    public Tovar(string nazvanie, double cena, int kolichestvo)
    {
        if (cena <= 0 || kolichestvo < 0)
        {
            Console.WriteLine("Ошибка при создании товара");
            Nazvanie = "Без названия";
            Cena = 1;
            Kolichestvo = 0;
        }
        else
        {
            Nazvanie = nazvanie;
            Cena = cena;
            Kolichestvo = kolichestvo;
        }
    }

    public virtual void Info()
    {
        Console.WriteLine("Название: " + Nazvanie);
        Console.WriteLine("Цена: " + Cena);
        Console.WriteLine("Количество: " + Kolichestvo);
    }

    public double Stoimost()
    {
        return Cena * Kolichestvo;
    }
}

//бытовая химия
class BitovayaHimiya : Tovar
{
    public string Tip;
    public double Obem;

    public BitovayaHimiya(string nazvanie, double cena, int kolichestvo, string tip, double obem)
        : base(nazvanie, cena, kolichestvo)
    {
        Tip = tip;

        if (obem <= 0)
        {
            Console.WriteLine("Ошибка объема");
            Obem = 1;
        }
        else
        {
            Obem = obem;
        }
    }

    public override void Info()
    {
        Console.WriteLine("Бытовая химия");
        base.Info();
        Console.WriteLine("Тип: " + Tip);
        Console.WriteLine("Объем: " + Obem + " л");
    }
}

//продукты питания
class ProduktPitania : Tovar
{
    public string SrokGodnosti;
    public double Ves;

    public ProduktPitania(string nazvanie, double cena, int kolichestvo, string srokGodnosti, double ves)
        : base(nazvanie, cena, kolichestvo)
    {
        SrokGodnosti = srokGodnosti;

        if (ves <= 0)
        {
            Console.WriteLine("Ошибка веса");
            Ves = 1;
        }
        else
        {
            Ves = ves;
        }
    }

    public override void Info()
    {
        Console.WriteLine("Продукт питания");
        base.Info();
        Console.WriteLine("Срок годности: " + SrokGodnosti);
        Console.WriteLine("Вес: " + Ves + " кг");
    }
}

//класс управления потоком товаров
class PotokTovarov
{
    public Tovar[] Tovary;

    public PotokTovarov(Tovar[] tovary)
    {
        Tovary = tovary;
    }

    //пришло
    public void Prishlo(Tovar tovar, int kolichestvo)
    {
        if (kolichestvo <= 0)
        {
            Console.WriteLine("Ошибка: количество должно быть больше нуля");
        }
        else
        {
            tovar.Kolichestvo += kolichestvo;
            Console.WriteLine("Поступило товара: " + tovar.Nazvanie + " — " + kolichestvo + " шт.");
        }
    }

    //реализовано
    public void Realizovano(Tovar tovar, int kolichestvo)
    {
        if (kolichestvo <= 0)
        {
            Console.WriteLine("Ошибка: количество должно быть больше нуля");
        }
        else if (kolichestvo > tovar.Kolichestvo)
        {
            Console.WriteLine("Ошибка: недостаточно товара для реализации");
        }
        else
        {
            tovar.Kolichestvo -= kolichestvo;
            Console.WriteLine("Реализовано товара: " + tovar.Nazvanie + " — " + kolichestvo + " шт.");
        }
    }

    //списано
    public void Spisano(Tovar tovar, int kolichestvo)
    {
        if (kolichestvo <= 0)
        {
            Console.WriteLine("Ошибка: количество должно быть больше нуля");
        }
        else if (kolichestvo > tovar.Kolichestvo)
        {
            Console.WriteLine("Ошибка: нельзя списать больше, чем есть на складе");
        }
        else
        {
            tovar.Kolichestvo -= kolichestvo;
            Console.WriteLine("Списано товара: " + tovar.Nazvanie + " — " + kolichestvo + " шт.");
        }
    }

    //передано
    public void Peredano(Tovar tovar, int kolichestvo, string kuda)
    {
        if (kolichestvo <= 0)
        {
            Console.WriteLine("Ошибка: количество должно быть больше нуля");
        }
        else if (kolichestvo > tovar.Kolichestvo)
        {
            Console.WriteLine("Ошибка: недостаточно товара для передачи");
        }
        else
        {
            tovar.Kolichestvo -= kolichestvo;
            Console.WriteLine("Передано товара: " + tovar.Nazvanie + " — " + kolichestvo + " шт. Куда: " + kuda);
        }
    }

    public void PokazatVseTovary()
    {
        Console.WriteLine("Список товаров:");

        for (int i = 0; i < Tovary.Length; i++)
        {
            Console.WriteLine();
            Tovary[i].Info();
            Console.WriteLine("Общая стоимость: " + Tovary[i].Stoimost());
        }
    }

    public double ObshayaStoimost()
    {
        double sum = 0;

        for (int i = 0; i < Tovary.Length; i++)
        {
            sum += Tovary[i].Stoimost();
        }

        return sum;
    }
}

//main
class Program
{
    static void Main()
    {
        BitovayaHimiya poroshok = new BitovayaHimiya("Стиральный порошок", 450, 20, "Для стирки", 3);
        BitovayaHimiya gel = new BitovayaHimiya("Гель для посуды", 180, 30, "Для кухни", 0.5);

        ProduktPitania moloko = new ProduktPitania("Молоко", 90, 40, "10 дней", 1);
        ProduktPitania hleb = new ProduktPitania("Хлеб", 55, 25, "3 дня", 0.5);

        Tovar[] arr =
        {
            poroshok,
            gel,
            moloko,
            hleb
        };

        PotokTovarov potok = new PotokTovarov(arr);

        potok.PokazatVseTovary();

        Console.WriteLine();
        Console.WriteLine("Общая стоимость всех товаров: " + potok.ObshayaStoimost());

        Console.WriteLine();
        Console.WriteLine("Операции с товарами:");

        potok.Prishlo(moloko, 10);
        potok.Realizovano(hleb, 5);
        potok.Spisano(gel, 3);
        potok.Peredano(poroshok, 4, "Склад №2");

        Console.WriteLine();
        Console.WriteLine("После операций:");

        potok.PokazatVseTovary();

        Console.WriteLine();
        Console.WriteLine("Общая стоимость после операций: " + potok.ObshayaStoimost());
    }
}