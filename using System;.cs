using System;

//интерфейс
interface Figura
{
    double Ploshad();
    double Perimetr();
}

//абстрактный класс
abstract class GeomFig
{
    public abstract double Ploshad();
    public abstract double Perimetr();
}

//квадрат
class Kvadrat : GeomFig, Figura
{
    public double a;

    public Kvadrat(double storona)
    {
        if (storona <= 0)
        {
            Console.WriteLine("ошибка");
            a = 1;
        }
        else
        {
            a = storona;
        }
    }

    public override double Ploshad()
    {
        return a * a;
    }

    public override double Perimetr()
    {
        return a * 4;
    }
}

//треугольник
class Treugolnik : GeomFig, Figura
{
    public double a;
    public double b;
    public double c;

    public Treugolnik(double x, double y, double z)
    {
        if (x + y <= z || x + z <= y || y + z <= x)
        {
            Console.WriteLine("такой треугольник нельзя создать");

            a = 1;
            b = 1;
            c = 1;
        }
        else
        {
            a = x;
            b = y;
            c = z;
        }
    }

    public override double Ploshad()
    {
        double p = (a + b + c) / 2;

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public override double Perimetr()
    {
        return a + b + c;
    }
}
// ромб
class Romb : GeomFig, Figura
{
    public double a;
    public double h;
    public Romb(double storona, double visota)
    {
        if (storona <= 0 || visota <= 0)
        {
            Console.WriteLine("Ошибка");

            a = 1;
            h = 1;
        }
        else
        {
            a = storona;
            h = visota;
        }
    }
    public override double Ploshad()
    {
        return a * h;
    }
    public override double Perimetr()
    {
        return a * 4;
    }

    //прямоугольник
    class Pryamougolnik : GeomFig, Figura
    {
        public double a;
        public double b;

        public Pryamougolnik(double x, double y)
        {
            if (x <= 0 || y <= 0)
            {
                Console.WriteLine("Ошибка");

                a = 1;
                b = 1;
            }
            else
            {
                a = x;
                b = y;
            }
        }
        public override double Ploshad()
        {
            return a * b;
        }
        public override double Perimetr()
        {
            return 2 * (a + b);
        }
    }
    //параллелограмм
    class Paralelogram : GeomFig, Figura
    {
        public double a;
        public double b;
        public double h;

        public Paralelogram(double x, double y, double visota)
        {
            if (x <= 0 || y <= 0 || visota <= 0)
            {
                Console.WriteLine("Ошибка");
                a = 1;
                b = 1;
                h = 1;
            }
            else
            {
                a = x;
                b = y;
                h = visota;
            }
        }
        public override double Ploshad()
        {
            return a * h;
        }
        public override double Perimetr()
        {
            return 2 * (a + b);
        }
    }
    //составная фигура
    class SostFigura
    {
        public Figura[] figs;

        public SostFigura(Figura[] f)
        {
            figs = f;
        }

        public double ObshayaPloshad()
        {
            double sum = 0;

            for (int i = 0; i < figs.Length; i++)
            {
                sum += figs[i].Ploshad();
            }

            return sum;
        }
    }
    class Program
    {
        static void Main()
        {
            Kvadrat k = new Kvadrat(6);

            Console.WriteLine("Квадрат");
            Console.WriteLine("Площадь " + k.Ploshad());
            Console.WriteLine("Периметр " + k.Perimetr());

            Console.WriteLine();

            Treugolnik t = new Treugolnik(6, 6, 5);

            Console.WriteLine("Треугольник");
            Console.WriteLine("Площадь " + t.Ploshad());
            Console.WriteLine("Периметр " + t.Perimetr());

            Console.WriteLine();

            Romb r = new Romb(6, 4);

            Console.WriteLine("Ромб");
            Console.WriteLine("Площадь " + r.Ploshad());
            Console.WriteLine("Периметр " + r.Perimetr());

            Console.WriteLine();

            Pryamougolnik p = new Pryamougolnik(7, 4);

            Console.WriteLine("Прямоугольник");
            Console.WriteLine("Площадь " + p.Ploshad());
            Console.WriteLine("Периметр " + p.Perimetr());

            Console.WriteLine();

            Paralelogram par = new Paralelogram(5, 3, 4);

            Console.WriteLine("Параллелограмм");
            Console.WriteLine("Площадь " + par.Ploshad());
            Console.WriteLine("Периметр " + par.Perimetr());

            Console.WriteLine();

                Figura[] arr =
            {
            k,
            t,
            r,
            p,
            par
        };

            SostFigura sf = new SostFigura(arr);

            Console.WriteLine("Общая площадь " + sf.ObshayaPloshad());

        }
    }
}