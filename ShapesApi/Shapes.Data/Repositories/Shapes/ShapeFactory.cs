using Shapes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Dynamic;
using Shapes.Domain.Model.Shapes;

namespace Shapes.Data.Repositories
{
    internal static class ShapeFactory
    {
        internal static T CreateFrom<T>(ShapeDataModel dataModel) where T : Shape
        {
            if (dataModel.Type == ShapeType.Line.Name)
                return new Line(new ShapeId(dataModel.Id), dataModel.Length) as T;
            else if (dataModel.Type == ShapeType.Circle.Name)
                return new Circle(new ShapeId(dataModel.Id), dataModel.Radius) as T;
            else if (dataModel.Type == ShapeType.Square.Name)
                return new Square(new ShapeId(dataModel.Id), dataModel.Side) as T;
            else if (dataModel.Type == ShapeType.Rectangle.Name)
                return new Rectangle(new ShapeId(dataModel.Id), dataModel.Length, dataModel.Width) as T;
            else
                throw new Exception($"Cannot convert shape with Id '{dataModel.Id}' and Type '{dataModel.Type}'");
        }
    }
}
