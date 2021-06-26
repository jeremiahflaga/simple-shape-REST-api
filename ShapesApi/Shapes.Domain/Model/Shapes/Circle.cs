using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model
{
    public class Circle : Shape
    {
        public Circle(ShapeId id, double radius)
            : base(id)
        {
            Radius = radius;
        }
        
        public double Radius { get; }
        public double Circumference => 2 * Math.PI * Radius;
        public override double Area =>  Math.PI * Math.Pow(Radius, 2);
        public override string Type => "circle";
    }
}
