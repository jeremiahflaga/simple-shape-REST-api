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
        public static ShapeViewModel CreateFrom(Shape shape) 
        {
            var vm = new ShapeViewModel();         
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
    }
}
