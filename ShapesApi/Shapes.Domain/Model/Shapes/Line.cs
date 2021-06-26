using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model
{
    public class Line : Shape
    {
        public Line(ShapeId id, double length)
            : base(id)
        {
            Length = length;
        }
        
        public double Length { get; }
        public override double Area => Length;
        public override string Type => "line";
    }
}
