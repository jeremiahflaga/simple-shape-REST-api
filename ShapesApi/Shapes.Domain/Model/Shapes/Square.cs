using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model
{
    public class Square : Shape
    {
        public Square(ShapeId id, double side)
            : base(id)
        {
            Side = side;
        }
        
        public double Side { get; }
        public double Perimeter => Side * 4;
        public override double Area =>  Side * Side;
        public override string Type => "square";
    }
}
