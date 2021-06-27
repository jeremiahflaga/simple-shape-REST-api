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
        internal dynamic Data { get; set; } = new ExpandoObject();
        
        internal Shape ConvertToShapeDomainModel()
        {
            if (Type == ShapeType.Line.Name)
                return new Line(new ShapeId(Id), Data.Length);
            else if (Type == ShapeType.Circle.Name)
                return new Circle(new ShapeId(Id), Data.Radius);             
            else if (Type == ShapeType.Square.Name)
                return new Square(new ShapeId(Id), Data.Side);
            else if (Type == ShapeType.Rectangle.Name)
                return new Rectangle(new ShapeId(Id), Data.Length, Data.Width);
            else
                throw new Exception($"Cannot convert shape with Id '{Id}' and Type '{Type}'");
        }
    }
}
