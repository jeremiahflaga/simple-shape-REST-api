using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model.Shapes
{
    public class Circle : Shape
    {
        public override ShapeType Type => ShapeType.Circle;
        public override double ComputeArea() => Math.PI * Math.Pow(Radius, 2);
        public override double ComputePerimeter() => ComputeCircumference();

        public Circle(ShapeId id, double radius)
            : base(id)
        {
            Radius = radius;
        }
        
        public double Radius { get; }
        public double ComputeCircumference() => 2 * Math.PI * Radius;
    }
}
