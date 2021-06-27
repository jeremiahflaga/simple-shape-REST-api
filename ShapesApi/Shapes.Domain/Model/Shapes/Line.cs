using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model.Shapes
{
    public class Line : Shape
    {
        public override ShapeType Type => ShapeType.Line;
        public override double ComputeArea() => Length;
        public override double ComputePerimeter() => Length;

        public Line(ShapeId id, double length)
            : base(id)
        {
            Length = length;
        }
        
        public double Length { get; }
    }
}
