using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Application
{
    internal static class ShapeFactory
    {
        internal static Shape Create(ShapeId id, ShapeType type, dynamic data)
        {
            if (type == ShapeType.Line)
                return new Line(id, data.Length);
            else if (type == ShapeType.Circle)
                return new Circle(id, data.Radius);
            else if (type == ShapeType.Square)
                return new Square(id, data.Side);
            else if (type == ShapeType.Rectangle)
                return new Rectangle(id, data.Length, data.Width);
            else
                throw new Exception($"Cannot convert shape with Id '{id}' and Type '{type}'");
        }
    }
}
