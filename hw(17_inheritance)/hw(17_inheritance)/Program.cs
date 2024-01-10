using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_17_inheritance_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeomFigure triangle = new Triangle(2, 3, 4);
            GeomFigure square = new Square(3);
            GeomFigure rhomb = new Rhomb(12, 7.5); 
            GeomFigure rectangle = new Rectangle(7, 12);
            GeomFigure parallelogram = new Parallelogram(5, 7.2); 
            GeomFigure trapezoid = new Trapezoid(6, 12, 9); 
            GeomFigure circle = new Circle(8); 
            GeomFigure ellipse = new Ellipse(12, 8);
            CompositeFigure compositeF = 
                new CompositeFigure(triangle, square, rhomb, rectangle, parallelogram, trapezoid, circle, ellipse);

            foreach (var item in compositeF.GetFigures())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(compositeF.ToString());
            Console.WriteLine();
        }
    }
}
