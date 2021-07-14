using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Application.UseCases.GetAllShapes
{
    public sealed class GetAllShapesRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
