using Shapes.Domain.Model;
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
            if (shape.GetType() == typeof(Circle))
            {
                var circle = (Circle)shape;
                var vm = new ShapeViewModel { Id = circle.Id.Value.ToString(), Type = circle.Type};
                vm.Data.Radius = circle.Radius;
                vm.Data.Circumference = circle.Circumference;
                vm.Data.Area = circle.Area;
                return vm;
            }

            return new ShapeViewModel();
        }
    }
}
