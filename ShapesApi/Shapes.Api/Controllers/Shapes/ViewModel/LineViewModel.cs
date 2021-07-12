using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public sealed class LineViewModel : ShapeViewModel
    {
        public string Type { get; set; }
        public double Length { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        
        public static LineViewModel CreateFrom(Line line) 
        {
            var vm = new LineViewModel();         
            vm.Id = line.Id.Value.ToString();
            vm.Type = line.Type.Name.ToLower();
            vm.Area = line.ComputeArea();
            vm.Perimeter = line.ComputePerimeter();
            vm.Length = line.Length;
            return vm;
        }
    }
}
