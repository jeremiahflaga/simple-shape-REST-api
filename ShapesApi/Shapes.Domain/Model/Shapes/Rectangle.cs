using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model.Shapes
{
    public class Rectangle : Shape
    {
        public override ShapeType Type => ShapeType.Rectangle;
        public override double Area =>  Length * Width;
        public override double Perimeter => (Length * 2) +  (Width * 2);

        public Rectangle(ShapeId id, double length, double width)
            : base(id)
        {
            Length = length;
            Width = width;
        }
        
        public double Length { get; }
        public double Width { get; }
    }
}
