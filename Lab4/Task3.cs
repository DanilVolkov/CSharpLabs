abstract class Figure
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public abstract double Area2 { get; }

    public Figure(string _name)
    {
        name = _name;
    }

    public abstract double Area();

    public virtual void Print()
    {
        Console.Write(name);
    }
}

class Triangle : Figure
{
    private int a;
    private int b;
    private int c;


    public Triangle(string _name, int _a, int _b, int _c) : base(_name)
    {
        SetABC(_a, _b, _c);
    }

    public void SetABC(int _a, int _b, int _c)
    {
        if (isTriangle(_a, _b, _c))
        {
            a = _a;
            b = _b;
            c = _c;
        }
        else
        {
            Console.WriteLine("Данные длины сторон не образуют треугольник.");
        }
    }

    public (int, int, int) GetABC()
    {
        return (a, b, c);
    }

    private bool isTriangle(int a, int b, int c) => a + b > c && a + c > b && b + c > a;

    public override double Area2
    {
        get { return Math.Round(Area(), 2); }
    }

    public override double Area()
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($", a: {a}, b: {b}, c: {c}");
    }
}

class TriangleColor : Triangle
{
    private string color;

    public string Color {
        get { return color; }
        set { color = value; }
    }

    public TriangleColor(string _name, int _a, int _b, int _c, string _color) : base(_name, _a, _b, _c)
    {
        color = _color;
    }

    public override double Area2 => base.Area2;

    public override double Area() => base.Area();

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"цвет: {color}");
    }
}



class Task3
{
    static void Main()
    {
        Triangle triangle = new Triangle("Треугольник", 5, 7, 6);
        TriangleColor triangleColor = new TriangleColor("Треугольник", 6, 6, 8, "Синий");

        triangle.Print();
        Console.WriteLine(triangle.GetABC());
        triangle.SetABC(1, 2, 3);
        Console.WriteLine(triangle.Area2);
        Console.WriteLine(triangle.Area());

        Console.WriteLine();

        triangleColor.Print();
        Console.WriteLine(triangleColor.GetABC());
        triangle.SetABC(1, 2, 3);
        Console.WriteLine(triangleColor.Area2);
        Console.WriteLine(triangleColor.Area());
        Console.WriteLine(triangleColor.Color);

    }
}
