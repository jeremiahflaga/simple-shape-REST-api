using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public class SquareViewModel : ShapeViewModel
    {
        public string Type { get; set; }
        public double Side { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        
        public static SquareViewModel CreateFrom(Square square) 
        {
            var vm = new SquareViewModel();         
            vm.Id = square.Id.Value.ToString();
            vm.Type = square.Type.Name.ToLower();
            vm.Area = square.ComputeArea();
            vm.Perimeter = square.ComputePerimeter();
            vm.Side = square.Side;
            return vm;
        }
    }
}
