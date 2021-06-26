using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shapes.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    [ApiController]
    [Route("[controller]")]
    public class ShapesController : ControllerBase
    {
        private readonly ShapeService shapeService;

        public ShapesController(ShapeService shapeService)
        {
            this.shapeService = shapeService;
        }

        [HttpGet]
        public IEnumerable<ShapeViewModel> Get()
        {
            var shapes = from shape in shapeService.GetAll()
                         select ShapeViewModelFactory.CreateFrom(shape);
            return shapes;
        }
    }
}
