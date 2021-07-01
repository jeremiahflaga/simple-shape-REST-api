using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public class CircleViewModel : ShapeViewModel
    {
        public string Type { get; set; }
        public double Radius { get; set; }
        public double Area { get; set; }
        public double Circumference { get; set; }
        
        public static CircleViewModel CreateFrom(Circle circle) 
        {
            var vm = new CircleViewModel();         
            vm.Id = circle.Id.Value.ToString();
            vm.Type = circle.Type.Name.ToLower();
            vm.Area = circle.ComputeArea();
            vm.Circumference = circle.ComputeCircumference();
            vm.Radius = circle.Radius;
            return vm;
        }
    }
}
