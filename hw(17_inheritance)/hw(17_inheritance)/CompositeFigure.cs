using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_17_inheritance_
{
    class CompositeFigure : GeomFigure
    {
        private GeomFigure[] figures;
        public CompositeFigure(params GeomFigure[] figures)
        {
            this.figures = figures;
        }
        public override double GetArea()
        {
            double area = 0;
            foreach (var figure in figures)
            {
                area += figure.GetArea();
            }
            return area;
        }
        public override double GetPerimeter()
        {
            double perimeter = 0;
            foreach (var figure in figures)
            {
                perimeter += figure.GetPerimeter();
            }
            return perimeter;
        }
        public GeomFigure[] GetFigures()
        {
            return figures;
        }
        public override string ToString()
        {
            return $"\n\tCOMPOSITE FIGURE >>>\nArea of the composite figure --> {GetArea().ToString("F2")}\n" +
                $"Perimeter of the composite figure --> {GetPerimeter().ToString("F2")}";
        }
    }
}
