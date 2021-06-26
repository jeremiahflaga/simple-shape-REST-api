using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Shapes.Domain.Model;
using Shapes.Domain.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
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

        [HttpGet("{id:Guid}")]
        public ActionResult<ShapeViewModel> Get(Guid id)
        {
            var shape = shapeService.Get(new ShapeId(id));
            if (shape == null)
                return NotFound();

            return Ok(ShapeViewModelFactory.CreateFrom(shape));
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateShapeInputData inputData)
        {
            var data = ParseDynamicData(inputData.Data.ToString());

            var id = new ShapeId();
            shapeService.Add(id, Enumeration.FromDisplayName<ShapeType>(inputData.Type), data);
            var newlyCreatedShape = shapeService.Get(id);

            return CreatedAtAction(nameof(Get), new { id = id.Value }, ShapeViewModelFactory.CreateFrom(newlyCreatedShape));
        }

        [HttpPut("{id:Guid}")]
        public ActionResult<ShapeViewModel> Put(Guid id, [FromBody] CreateShapeInputData inputData)
        {
            var shape = shapeService.Get(new ShapeId(id));
            if (shape == null)
                return NotFound();

            var data = ParseDynamicData(inputData.Data.ToString());

            shapeService.Update(shape, data);
            var updatedShape = shapeService.Get(new ShapeId(id));

            return Ok(ShapeViewModelFactory.CreateFrom(updatedShape));
        }

        private dynamic ParseDynamicData(string json)
        {
            // NOTE: I'm new to this dynamic input data, so I don't have an elegant looking solution for now
            // Get .NET Core JSON Body as dynamic object: https://stackoverflow.com/a/63165181/1451757            
            var converter = new ExpandoObjectConverter();
            var jsonAsExpandoObject = JsonConvert.DeserializeObject<ExpandoObject>(json, converter) as dynamic;
            return jsonAsExpandoObject;
        }

        //private dynamic ToPascalCaseExpandoObject(string json)
        //{
        //    // Deserialize Camel Case JSON to Pascal Case in ExpandoObject: https://stackoverflow.com/a/51218806/1451757
        //    JObject obj = JObject.Parse(json);

        //    dynamic foo = new ExpandoObject();
        //    var bar = (IDictionary<string, object>)foo;
        //    foreach (JProperty property in obj.Properties())
        //    {
        //        var janky = property.Name.Substring(0, 1).ToUpperInvariant() + property.Name.Substring(1);
        //        bar.Add(janky, property.Value);
        //    }

        //    return foo;
        //}
    }
}
