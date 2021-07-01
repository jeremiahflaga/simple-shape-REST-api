using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Services
{
    [Obsolete("Delete if not used anymore")]
    internal sealed class ShapeFactory
    {
        [Obsolete("Delete if not used anymore")]
        internal static Shape CreateNew(ShapeId id, ShapeType type, dynamic data)
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

        //internal static Shape CreateNew(ShapeId id, ShapeType type, dynamic data)
        //{
        //    // TODO Jboy: not yet able to find way to convert cmel case to pascal case for dynamic objects 
        //    // coming from input of HttpPost
        //    if (type == ShapeType.Line)
        //        return new Line(id, data.length);
        //    else if (type == ShapeType.Circle)
        //        return new Circle(id, data.radius);
        //    else if (type == ShapeType.Square)
        //        return new Square(id, data.side);
        //    else if (type == ShapeType.Rectangle)
        //        return new Rectangle(id, data.length, data.width);
        //    else
        //        throw new Exception($"Cannot convert shape with Id '{id}' and Type '{type}'");
        //}
    }
}
