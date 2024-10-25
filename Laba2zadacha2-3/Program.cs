using System;

class Program
{
    static void Main(string[] args)
    {
        // Ввод координат первой точки
        Console.WriteLine("Введите координаты первой точки");
        Program program = new Program();
        double x1 = program.GetCoordinate("x1");
        double y1 = program.GetCoordinate("y1");

        // Ввод координат второй точки
        Console.WriteLine("Введите координаты второй точки");
        double x2 = program.GetCoordinate("x2");
        double y2 = program.GetCoordinate("y2");

        // Создание точек
        Point p1 = new Point(x1, y1);
        Point p2 = new Point(x2, y2);

        // Вывод информации о точках
        Console.WriteLine($"Точка 1: {p1}");
        Console.WriteLine($"Точка 2: {p2}");

        // Увеличение координаты x у первой точки (унарный оператор ++)
        p1.IncrementX();
        Console.WriteLine($"После увеличения x у p1: {p1}");

        // Уменьшение координаты x у первой точки (унарный оператор --)
        p1.DecrementX();
        Console.WriteLine($"После уменьшения x у p1: {p1}");

        // Вычисление и вывод расстояния между p1 и p2
        double distance = p1.DistanceTo(p2);
        Console.WriteLine($"Расстояние между p1 и p2: {distance}");

        // Приведение к типу int и double
        int xAsInt = p1.ToInt(); 
        double yAsDouble = p1.ToDouble();  
        Console.WriteLine($"p1 как int (x): {xAsInt}, p1 как double (y): {yAsDouble}");

        // Ввод целого числа с клавиатуры, на которое увеличивается x
        int incrementValue = program.GetInteger("Введите целое число для увеличения x");

        // Увеличение координаты x на целое число
        Point p3 = p1.AddToX(incrementValue);
        Console.WriteLine($"p1 после увеличения на {incrementValue}: {p3}");

        Console.WriteLine(p1.ToString() + ' ' + p2.ToString());
    }

    // Метод для получения координат с клавиатуры (double)
    public double GetCoordinate(string name)
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
    public int GetInteger(string message)
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

class Point
{
    double x;
    double y;

    // Конструктор
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double GetX() => x;
    public double GetY() => y;

    public double DistanceTo(Point other)
    {
        double x = other.x - this.x;
        double y = other.y - this.y;
        return Math.Sqrt(x * x + y * y);
    }

    // Увеличение и уменьшение координаты x
    public void IncrementX()
    {
        x += 1;
    }

    public void DecrementX()
    {
        x -= 1;
    }

    // Приведение к типу int и double
    public int ToInt()
    {
        return (int)x;
    }

    public double ToDouble()
    {
        return y;
    }

    // Увеличение x на заданное целое значение
    public Point AddToX(int value)
    {
        return new Point(this.x + value, this.y);
    }

    public override string ToString()
    {
        return $"x: {x}, y: {y}";
    }
}
