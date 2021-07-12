using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Data.Repositories
{
    internal static class ShapeDataModelFactory
    {
        internal static ShapeDataModel CreateFrom(Shape shape)
        {
            var shapeDataModel = new ShapeDataModel { Id = shape.Id.Value, Type = shape.Type.Name };
            if (shape.GetType() == typeof(Line))
            {
                var line = (Line)shape;
                shapeDataModel.Length = line.Length;
            }
            else if (shape.GetType() == typeof(Circle))
            {
                var circle = (Circle)shape;
                shapeDataModel.Radius = circle.Radius;
            }             
            else if (shape.GetType() == typeof(Square))
            {
                var square = (Square)shape;
                shapeDataModel.Side = square.Side;
            }             
            else if (shape.GetType() == typeof(Rectangle))
            {
                var rectangle = (Rectangle)shape;
                shapeDataModel.Length = rectangle.Length;
                shapeDataModel.Width = rectangle.Width;
            }

            return shapeDataModel;
        }
    }
}
