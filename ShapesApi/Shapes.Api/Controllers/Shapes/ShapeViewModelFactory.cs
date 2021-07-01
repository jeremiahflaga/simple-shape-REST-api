using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public class ShapeViewModelFactory
    {
        [Obsolete("Delete if not used anymore")]
        public static ShapeViewModel_OLD Create_OLD_From(Shape shape)
        {
            var vm = new ShapeViewModel_OLD();
            vm.Id = shape.Id.Value.ToString();
            vm.Type = shape.Type.Name.ToLower();
            vm.Data.Area = shape.ComputeArea();
            vm.Data.Perimeter = shape.ComputePerimeter();

            if (shape.GetType() == typeof(Line))
            {
                var line = (Line)shape;
                vm.Data.Length = line.Length;
            }
            else if (shape.GetType() == typeof(Circle))
            {
                var circle = (Circle)shape;
                vm.Data.Radius = circle.Radius;
                vm.Data.Circumference = circle.ComputeCircumference();
            }
            else if (shape.GetType() == typeof(Square))
            {
                var square = (Square)shape;
                vm.Data.Side = square.Side;
            }
            else if (shape.GetType() == typeof(Rectangle))
            {
                var rectangle = (Rectangle)shape;
                vm.Data.Length = rectangle.Length;
                vm.Data.Width = rectangle.Width;
            }

            return vm;
        }


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
