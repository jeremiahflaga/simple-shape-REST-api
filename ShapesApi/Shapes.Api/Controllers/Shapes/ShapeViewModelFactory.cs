using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public static class ShapeViewModelFactory
    {
        public static ShapeViewModel CreateFrom(Shape shape) 
        {
            if (shape.GetType() == typeof(Line))
            {
                var line = (Line)shape;
                return new LineViewModel
                {
                    Id = shape.Id.Value.ToString(),
                    Type = shape.Type.Name.ToLower(),
                    Length = line.Length,
                    Area = shape.ComputeArea(),
                    Perimeter = shape.ComputePerimeter()
                };
            }
            else if (shape.GetType() == typeof(Circle))
            {
                var circle = (Circle)shape;
                return new CircleViewModel
                {
                    Id = shape.Id.Value.ToString(),
                    Type = shape.Type.Name.ToLower(),
                    Radius = circle.Radius,
                    Circumference = circle.ComputeCircumference(),
                    Area = shape.ComputeArea()
                };
            }            
            else if (shape.GetType() == typeof(Square))
            {
                var square = (Square)shape;
                return new SquareViewModel
                {
                    Id = shape.Id.Value.ToString(),
                    Type = shape.Type.Name.ToLower(),
                    Side = square.Side,
                    Perimeter = shape.ComputePerimeter(),
                    Area = shape.ComputeArea()
                };
            }                 
            else if (shape.GetType() == typeof(Rectangle))
            {
                var rectangle = (Rectangle)shape;
                return new RectangleViewModel
                {
                    Id = shape.Id.Value.ToString(),
                    Type = shape.Type.Name.ToLower(),
                    Length = rectangle.Length,
                    Width = rectangle.Width,
                    Perimeter = shape.ComputePerimeter(),
                    Area = shape.ComputeArea()
                };
            }

            return new ShapeViewModel();
        }
    }
}
