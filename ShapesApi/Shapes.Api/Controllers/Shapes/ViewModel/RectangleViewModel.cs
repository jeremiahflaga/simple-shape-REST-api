using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public class RectangleViewModel : ShapeViewModel
    {
        public string Type { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        
        public static RectangleViewModel CreateFrom(Rectangle square) 
        {
            var vm = new RectangleViewModel();         
            vm.Id = square.Id.Value.ToString();
            vm.Type = square.Type.Name.ToLower();
            vm.Area = square.ComputeArea();
            vm.Perimeter = square.ComputePerimeter();
            vm.Length = square.Length;
            vm.Width = square.Width;
            return vm;
        }
    }
}
