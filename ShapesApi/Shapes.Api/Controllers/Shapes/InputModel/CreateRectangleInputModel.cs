using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public sealed class CreateRectangleInputModel
    {
        public double Length { get; set; }
        public double Width { get; set; }
    }
}
