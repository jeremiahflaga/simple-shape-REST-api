using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model.Shapes
{
    public class Square : Shape
    {
        public override ShapeType Type => ShapeType.Square;
        public override double ComputeArea() =>  Side * Side;
        public override double ComputePerimeter() => Side * 4;

        public Square(ShapeId id, double side)
            : base(id)
        {
            Side = side;
        }
        
        public double Side { get; }
    }
}
