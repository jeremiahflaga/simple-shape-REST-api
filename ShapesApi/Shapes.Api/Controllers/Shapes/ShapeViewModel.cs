using Shapes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public class ShapeViewModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public dynamic Data { get; set; } = new ExpandoObject();
    }
}
