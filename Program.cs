using System.Collections.Generic;
using System.Drawing;
using System.Transactions;

namespace FigureIerarhe
{
    abstract class Figure
    {
        public abstract double SquareFigure();
        public abstract double PerimeterFigure();
        public abstract void Draw();
        public abstract void ShowProperties();
    }

    class Square : Figure
    {
        public int Length { get; set; }

        public Square(int length)
        {
            Length = length;
        }

        public override double SquareFigure()
        {
            return Length * Length;
        }

        public override double PerimeterFigure()
        {
            return Length * 4;
        }

        public override void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (Length == 1 || Length == 2) Console.Write("#");
                    else Console.Write("##");
                }
                Console.WriteLine();
            }
        }

        public override void ShowProperties()
        {
            Console.WriteLine("---===КВАДРАТ===---");
            Console.WriteLine("Первичные свойства: ");
            Console.WriteLine("  Длина стороны квадрата: " + Length);
            Console.WriteLine("Вторичные свойства: ");
            Console.WriteLine("  Площадь квадрата: " + SquareFigure());
            Console.WriteLine("  Периметр квадрата: " + PerimeterFigure());
        }
    }

    class Rectangle : Figure
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override double SquareFigure()
        {
            return Width * Height;
        }

        public override double PerimeterFigure()
        {
            return 2 * (Width + Height);
        }

        public override void Draw()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Width == 1) Console.Write("#");
                    else Console.Write("##");
                }
                Console.WriteLine();
            }
        }
        public override void ShowProperties()
        {
            Console.WriteLine("---===ПРЯМОУГОЛЬНИК===---");
            Console.WriteLine("Первичные свойства: ");
            Console.WriteLine("  Ширина прямоугольника: " + Width);
            Console.WriteLine("  Высота прямоугольника: " + Height);
            Console.WriteLine("Вторичные свойства: ");
            Console.WriteLine("  Площадь прямоугольника: " + SquareFigure());
            Console.WriteLine("  Периметр прямоугольника: " + PerimeterFigure());
        }
    }

    class Circle : Figure
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public override double SquareFigure()
        {
            return 2 * Math.PI * Radius;
        }

        public override double PerimeterFigure()
        {
            return Math.PI * Radius * Radius;
        }

        public override void Draw()
        {      
            for (double y = Radius; y >= -Radius; --y)
            {
                for (double x = -Radius; x <= Radius; x += 0.5)
                {                    
                    double gip = x * x + y * y;
                    if (gip == Radius * Radius)
                    {
                        Console.Write("*");
                    }
                    else if (gip < Radius * Radius)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

        }
        public override void ShowProperties()
        {
            Console.WriteLine("---===КРУГ===---");
            Console.WriteLine("Первичные свойства: ");
            Console.WriteLine("  Радиус круга: " + Radius);
            Console.WriteLine("Вторичные свойства: ");
            Console.WriteLine("  Площадь круга: " + SquareFigure());
            Console.WriteLine("  Периметр круга: " + PerimeterFigure());
        }
    }

    class Triangle : Figure
    {
        public int Length { get; set; }

        public Triangle(int length)
        {
            Length = length;
        }

        public override double SquareFigure()
        {
            double polyperimeter = 3 * Length / 2;
            return Math.Sqrt(polyperimeter * Math.Pow((polyperimeter - Length), 3));
        }

        public override double PerimeterFigure()
        {
            return 3 * Length;
        }

        public override void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (double j = 0; j <= i; j += 0.5)
                {
                    Console.Write("^");
                }
                Console.WriteLine();
            }
        }
        public override void ShowProperties()
        {
            Console.WriteLine("---===ТРЕУГОЛЬНИК===---");
            Console.WriteLine("Первичные свойства: ");
            Console.WriteLine("  Сторона треугольника: " + Length);
            Console.WriteLine("Вторичные свойства: ");
            Console.WriteLine("  Площадь треугольника: " + SquareFigure());
            Console.WriteLine("  Периметр треугольника: " + PerimeterFigure());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();

            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                int figureType = rand.Next(1, 5);

                if (figureType == 1)
                {
                    int lengthSideSquare = rand.Next(1, 10);
                    figures.Add(new Square(lengthSideSquare));
                }
                else if (figureType == 2)
                {
                    int width = rand.Next(1, 10);
                    int height = rand.Next(1, 10);
                    figures.Add(new Rectangle(width, height));
                }
                else if (figureType == 3)
                {
                    int radius = rand.Next(1, 10);
                    figures.Add(new Circle(radius));
                }
                else if (figureType == 4)
                {
                    int lengthSideTriangle = rand.Next(1, 10);
                    figures.Add(new Triangle(lengthSideTriangle));
                }
            }

            foreach (Figure figure in figures)
            {
                if (figure is Square)
                {
                    Square square = (Square)figure;
                    square.ShowProperties();
                    square.Draw();
                }
                else if (figure is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)figure;
                    rectangle.ShowProperties();
                    rectangle.Draw();
                }
                else if (figure is Circle)
                {
                    Circle circle = (Circle)figure;
                    circle.ShowProperties();
                    circle.Draw();
                }
                else if (figure is Triangle)
                {
                    Triangle triangle = (Triangle)figure;
                    triangle.ShowProperties();
                    triangle.Draw();
                }
                Console.WriteLine();
            }                       
        }
    }
}