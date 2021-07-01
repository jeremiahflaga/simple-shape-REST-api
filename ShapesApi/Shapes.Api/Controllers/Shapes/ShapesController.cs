using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
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

        #region Get All
        [Obsolete("Use GET new")]
        [HttpGet]
        public IEnumerable<ShapeViewModel_OLD> GetAll_OLD()
        {
            var shapes = from shape in shapeService.GetAll()
                         select ShapeViewModelFactory.Create_OLD_From(shape);
            return shapes;
        }

        [HttpGet("new")]
        public IEnumerable<ShapeViewModel> GetAll()
        {
            var shapes = from shape in shapeService.GetAll()
                         select ShapeViewModelFactory.CreateFrom(shape);
            return shapes;
        }
        #endregion

        #region Get individual shape
        [Obsolete("Use individual endpoints for each shape")]
        [HttpGet("{id:Guid}")]
        public ActionResult<ShapeViewModel> Get(Guid id)
        {
            var shape = shapeService.Get(new ShapeId(id));
            if (shape == null)
                return NotFound();

            return Ok(ShapeViewModelFactory.CreateFrom(shape));
        }

        [HttpGet("line/{id:Guid}")]
        public ActionResult<LineViewModel> GetLine(Guid id)
        {
            var line = shapeService.Get<Line>(new ShapeId(id));
            if (line == null)
                return NotFound();

            return Ok(LineViewModel.CreateFrom(line));
        }
        
        [HttpGet("circle/{id:Guid}")]
        public ActionResult<CircleViewModel> GetCircle(Guid id)
        {
            var circle = shapeService.Get<Circle>(new ShapeId(id));
            if (circle == null)
                return NotFound();

            return Ok(CircleViewModel.CreateFrom(circle));
        }
        
        [HttpGet("square/{id:Guid}")]
        public ActionResult<SquareViewModel> GetSquare(Guid id)
        {
            var square = shapeService.Get<Square>(new ShapeId(id));
            if (square == null)
                return NotFound();

            return Ok(SquareViewModel.CreateFrom(square));
        }
        
        [HttpGet("rectangle/{id:Guid}")]
        public ActionResult<RectangleViewModel> GetRectangle(Guid id)
        {
            var rectangle = shapeService.Get<Rectangle>(new ShapeId(id));
            if (rectangle == null)
                return NotFound();

            return Ok(RectangleViewModel.CreateFrom(rectangle));
        }
        #endregion


        #region Add Shape
        [Obsolete("Use individual endpoints for each shape")]
        [HttpPost]
        public ActionResult Post([FromBody] CreateShapeInputData inputData)
        {
            var data = ParseDynamicData(inputData.Data.ToString());

            var id = new ShapeId();
            shapeService.Add(id, Enumeration.FromDisplayName<ShapeType>(inputData.Type), data);
            var newlyCreatedShape = shapeService.Get(id);

            return CreatedAtAction(nameof(Get), new { id = id.Value }, ShapeViewModelFactory.CreateFrom(newlyCreatedShape));
        }
        
        [HttpPost("line")]
        public ActionResult CreateLine([FromBody] CreateLineInputModel inputModel)
        {
            var id = shapeService.AddLine(inputModel.Length);
            var newlyCreatedShape = shapeService.Get<Line>(id);
            return CreatedAtAction(nameof(Get), new { id = id.Value }, ShapeViewModelFactory.CreateFrom(newlyCreatedShape));
        }
        
        [HttpPost("circle")]
        public ActionResult CreateCircle([FromBody] CreateCircleInputModel inputModel)
        {
            var id = shapeService.AddCircle(inputModel.Radius);
            var newlyCreatedShape = shapeService.Get<Circle>(id);
            return CreatedAtAction(nameof(Get), new { id = id.Value }, ShapeViewModelFactory.CreateFrom(newlyCreatedShape));
        }
        
        [HttpPost("square")]
        public ActionResult CreateSquare([FromBody] CreateSquareInputModel inputModel)
        {
            var id = shapeService.AddSquare(inputModel.Side);
            var newlyCreatedShape = shapeService.Get<Square>(id);
            return CreatedAtAction(nameof(Get), new { id = id.Value }, ShapeViewModelFactory.CreateFrom(newlyCreatedShape));
        }
        
        [HttpPost("rectangle")]
        public ActionResult CreateRectangle([FromBody] CreateRectangleInputModel inputModel)
        {
            var id = shapeService.AddRectangle(inputModel.Length, inputModel.Width);
            var newlyCreatedShape = shapeService.Get<Rectangle>(id);
            return CreatedAtAction(nameof(Get), new { id = id.Value }, ShapeViewModelFactory.CreateFrom(newlyCreatedShape));
        }
        #endregion



        #region Update Shape
        [Obsolete("Use individual endpoints for each shape")]
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
        
        [HttpPut("line/{id:Guid}")]
        public ActionResult<ShapeViewModel> UpdateLine(Guid id, [FromBody] CreateLineInputModel inputModel)
        {
            var line = shapeService.Get<Line>(new ShapeId(id));
            if (line == null)
                return NotFound();

            shapeService.UpdateLine(line.Id, inputModel.Length);
            var updatedShape = shapeService.Get<Line>(line.Id);
            return Ok(ShapeViewModelFactory.CreateFrom(updatedShape));
        }
        
        [HttpPut("circle/{id:Guid}")]
        public ActionResult<ShapeViewModel> UpdateCircle(Guid id, [FromBody] CreateCircleInputModel inputModel)
        {
            var circle = shapeService.Get<Circle>(new ShapeId(id));
            if (circle == null)
                return NotFound();

            shapeService.UpdateCircle(circle.Id, inputModel.Radius);
            var updatedShape = shapeService.Get<Circle>(circle.Id);
            return Ok(ShapeViewModelFactory.CreateFrom(updatedShape));
        }
        
        [HttpPut("square/{id:Guid}")]
        public ActionResult<ShapeViewModel> UpdateSquare(Guid id, [FromBody] CreateSquareInputModel inputModel)
        {
            var square = shapeService.Get<Square>(new ShapeId(id));
            if (square == null)
                return NotFound();

            shapeService.UpdateSquare(square.Id, inputModel.Side);
            var updatedShape = shapeService.Get<Square>(square.Id);
            return Ok(ShapeViewModelFactory.CreateFrom(updatedShape));
        }
        
        [HttpPut("rectangle/{id:Guid}")]
        public ActionResult<ShapeViewModel> UpdateRectangle(Guid id, [FromBody] CreateRectangleInputModel inputModel)
        {
            var rectangle = shapeService.Get<Rectangle>(new ShapeId(id));
            if (rectangle == null)
                return NotFound();

            shapeService.UpdateRectangle(rectangle.Id, inputModel.Length, inputModel.Width);
            var updatedShape = shapeService.Get<Rectangle>(rectangle.Id);
            return Ok(ShapeViewModelFactory.CreateFrom(updatedShape));
        }
        #endregion


        #region Helpers
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
        #endregion
    }
}
