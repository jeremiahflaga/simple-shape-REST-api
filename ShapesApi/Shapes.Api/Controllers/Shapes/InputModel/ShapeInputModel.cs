using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public sealed class ShapeInputModel
    {
        public string Type { get; set; }

        public double Length { get; set; } // for line and rectangle
        public double Radius { get; set; } // for circle
        public double Side { get; set; } // for square
        public double Width { get; set; } // for rectangle
    }
}
