using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Application.UseCases.UpdateShape
{
    public sealed class UpdateShapeRequest
    {
        public Guid Id { get; set; }

        public double? Length { get; set; } // for line and rectangle
        public double? Radius { get; set; } // for circle
        public double? Side { get; set; } // for square
        public double? Width { get; set; } // for rectangle
    }
}
