using System;

class Program
{
    static void Main(string[] args)
    {
        // Ввод координат первой точки
        Console.WriteLine("Введите координаты первой точки");
        double x1 = GetCoordinate("x1");
        double y1 = GetCoordinate("y1");

        // Ввод координат второй точки
        Console.WriteLine("Введите координаты второй точки");
        double x2 = GetCoordinate("x2");
        double y2 = GetCoordinate("y2");

        // Создание точек
        Point p1 = new Point(x1, y1);
        Point p2 = new Point(x2, y2);

        // Вывод информации о точках
        Console.WriteLine($"Точка 1: {p1}");
        Console.WriteLine($"Точка 2: {p2}");

        // Увеличение координаты x у первой точки (унарный оператор ++)
        p1++;
        Console.WriteLine($"После увеличения x у p1: {p1}");

        // Уменьшение координаты x у первой точки (унарный оператор --)
        p1--;
        Console.WriteLine($"После уменьшения x у p1: {p1}");

        // Вычисление и вывод расстояния между p1 и p2 (перегруженный оператор +)
        double distance = p1.distanceXY(p2);
        Console.WriteLine($"Расстояние между p1 и p2: {distance}");

        // Приведение к типу int и double
        int xAsInt = (int)p1; // Явное приведение к int (возвращает x)
        double yAsDouble = p1; // Неявное приведение к double (возвращает y)
        Console.WriteLine($"p1 как int (x): {xAsInt}, p1 как double (y): {yAsDouble}");

        // Ввод целого числа с клавиатуры, на которое увеличивается x
        int incrementValue = GetInteger("Введите целое число для увеличения x");

        // Увеличение координаты x на целое число с помощью оператора +
        Point p3 = p1 + incrementValue;
        Console.WriteLine($"p1 после увеличения на {incrementValue}: {p3}");

        // Использование правостороннего оператора + с целым числом
        Point p4 = incrementValue + p1;
        Console.WriteLine($"p1 после увеличения на {incrementValue} (правосторонний оператор): {p4}");

        Console.WriteLine(p1.ToString() + ' ' + p2.ToString());
    }

    // Метод для получения координат с клавиатуры (double)
    static double GetCoordinate(string name)
    {
        double result;
        Console.Write($"{name}: ");
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите число.");
        }
        return result;
    }

    // Метод для получения целого числа с клавиатуры (int)
    static int GetInteger(string message)
    {
        int result;
        Console.WriteLine($"{message}: ");
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число.");
        }
        return result;
    }
}

public class Point
{
    private double x;
    private double y;

    // Конструктор
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double GetX() => x;
    public double GetY() => y;


    public double distanceXY(Point other)
    {
        double x = other.x - this.x;
        double y = other.y - this.y;
        return Math.Sqrt(x * x + y * y);
    }


    // Унарные операции ++ и --
    public static Point operator ++(Point p)
    {
        p.x += 1;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.x -= 1;
        return p;
    }

    // Операции приведения типа
    public static explicit operator int(Point p)
    {
        return (int)p.x; // Явное приведение к int (возвращает x)
    }

    public static implicit operator double(Point p)
    {
        return p.y; // Неявное приведение к double (возвращает y)
    }

    // Оператор + для увеличения x на целое число (левосторонний)
    public static Point operator +(Point p, int value)
    {
        return new Point(p.x + value, p.y);
    }

    // Оператор + для увеличения x на целое число (правосторонний)
    public static Point operator +(int value, Point p)
    {
        return new Point(p.x + value, p.y);
    }

    // Переопределение метода ToString для вывода координат
    public override string ToString()
    {
        return $"x: {x}, y: {y}";
    }
}