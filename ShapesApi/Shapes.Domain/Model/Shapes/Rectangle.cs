using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model
{
    public class Rectangle : Shape
    {
        public Rectangle(ShapeId id, double length, double width)
            : base(id)
        {
            Length = length;
            Width = width;
        }
        
        public double Length { get; }
        public double Width { get; }
        public double Perimeter => (Length * 2) +  (Width * 2);
        public override double Area =>  Length * Width;
        public override string Type => "rectangle";
    }
}
