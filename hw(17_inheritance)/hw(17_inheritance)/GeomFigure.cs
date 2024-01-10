using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_17_inheritance_
{
    abstract public class GeomFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public override string ToString()
        {
            return $"\nPerimetr: {GetPerimeter().ToString("F2"),-10}Area: {GetArea().ToString("F2")}";
        }
    }
    // трикутник
    internal class Triangle : GeomFigure
    {
        private double a;
        private double b;
        private double c;
        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }
        public override double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public override double GetPerimeter()
        {
            return a + b + c;
        }
        public override string ToString()
        {
            return "\t  TRIANGLE >>" + base.ToString();
        }
    }
    // квадрат
    internal class Square : GeomFigure
    {
        private double a;
        public Square(double A)
        {
            a = A;
        }
        public override double GetArea()
        {
            return a * a;
        }
        public override double GetPerimeter()
        {
            return a * 4;
        }
        public override string ToString()
        {
            return "\n\t  SQUARE >>" + base.ToString();
        }
    }
    // ромб
    internal class Rhomb : GeomFigure
    {
        private double a;
        private double h;
        public Rhomb(double A, double H)
        {
            a = A;
            h = H;
        }
        public override double GetArea()
        {
            return a * h;
        }
        public override double GetPerimeter()
        {
            return a * 4;
        }
        public override string ToString()
        {
            return "\n\t  RHOMB >>" + base.ToString();
        }
    }
    // прямокутник
    internal class Rectangle : GeomFigure
    {
        private double length;
        private double width;
        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }
        public override double GetArea()
        {
            return length * width;
        }
        public override double GetPerimeter()
        {
            return (length + width) * 2;
        }
        public override string ToString()
        {
            return "\n\t  RHOMB >>" + base.ToString();
        }
    }
    // паралелограм
    class Parallelogram : GeomFigure
    {
        private double a;
        private double h;
        public Parallelogram(double A, double H)
        {
            a = A;
            h = H;
        }
        public override double GetArea()
        {
            return a * h;
        }
        public override double GetPerimeter()
        {
            return a * h;
        }
        public override string ToString()
        {
            return "\n\t  PARALLELOGRAM >>" + base.ToString();
        }
    }
    // трапеція
    internal class Trapezoid : GeomFigure
    {
        private double baseA;
        private double baseB;
        private double h;
        public Trapezoid(double A, double B, double H)
        {
            baseA = A;
            baseB = B;
            h = H;
        }
        public override double GetArea()
        {
            return ((baseA + baseB) / 2) * h;
        }
        public override double GetPerimeter()
        {
            return baseA + baseB + h;
        }
        public override string ToString()
        {
            return "\n\t  TRAPEZOID >>" + base.ToString();
        }
    }
    // коло
    internal class Circle : GeomFigure
    {
        private double r;
        public Circle(double r)
        {
            this.r = r;
        }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(r, 2);
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * r;
        }
        public override string ToString()
        {
            return "\n\t  CIRCLE >>" + base.ToString();
        }
    }
    // еліпс
    internal class Ellipse : GeomFigure
    {
        private double major;
        private double minor;
        public Ellipse(double A, double B)
        {
            major = A;
            minor = B;
        }
        public override double GetArea()
        {
            return Math.PI * major * minor;
        }
        public override double GetPerimeter()
        {
            return 4 * (Math.PI * (major * minor) + (major - minor)
                / (major + minor));
        }
        public override string ToString()
        {
            return "\n\t  ELLIPSE >>" + base.ToString();
        }
    }
}