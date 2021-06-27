using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Shapes.Data.Repositories
{
    internal sealed class ShapeDataModel
    {
        internal Guid Id { get; set; }
        internal string Type { get; set; }

        // Fields representing columns of SQL database
        internal double Length { get; set; } // for line and rectangle
        internal double Radius { get; set; } // for circle
        internal double Side { get; set; } // for square
        internal double Width { get; set; } // for rectangle

        internal Shape ConvertToShapeDomainModel()
        {
            if (Type == ShapeType.Line.Name)
                return new Line(new ShapeId(Id), Length);
            else if (Type == ShapeType.Circle.Name)
                return new Circle(new ShapeId(Id), Radius);
            else if (Type == ShapeType.Square.Name)
                return new Square(new ShapeId(Id), Side);
            else if (Type == ShapeType.Rectangle.Name)
                return new Rectangle(new ShapeId(Id), Length, Width);
            else
                throw new Exception($"Cannot convert shape with Id '{Id}' and Type '{Type}'");
        }

        
        //// Field representing JSON object of NoSQL database
        //internal dynamic Data { get; set; } = new ExpandoObject();

        //internal Shape ConvertToShapeDomainModel()
        //{
        //    if (Type == ShapeType.Line.Name)
        //        return new Line(new ShapeId(Id), Data.Length);
        //    else if (Type == ShapeType.Circle.Name)
        //        return new Circle(new ShapeId(Id), Data.Radius);             
        //    else if (Type == ShapeType.Square.Name)
        //        return new Square(new ShapeId(Id), Data.Side);
        //    else if (Type == ShapeType.Rectangle.Name)
        //        return new Rectangle(new ShapeId(Id), Data.Length, Data.Width);
        //    else
        //        throw new Exception($"Cannot convert shape with Id '{Id}' and Type '{Type}'");
        //}

    }
}
