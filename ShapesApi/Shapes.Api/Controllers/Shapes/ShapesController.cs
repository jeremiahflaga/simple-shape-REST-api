using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shapes.Application.UseCases.AddShape;
using Shapes.Application.UseCases.GetAllShapes;
using Shapes.Application.UseCases.GetShape;
using Shapes.Application.UseCases.UpdateShape;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Shapes.Api.Controllers.Shapes
{
    [ApiController]
    [Route("[controller]")]
    public class ShapesController : ControllerBase
    {
        private readonly AddShape addShapeUseCase;
        private readonly GetAllShapes getAllShapes;
        private readonly GetShape getShape;
        private readonly UpdateShape updateShapeUseCase;

        public ShapesController(
            AddShape addShapeUseCase,
            GetAllShapes getAllShapes,
            GetShape getShape,
            UpdateShape updateShapeUseCase
        ) {
            this.addShapeUseCase = addShapeUseCase;
            this.getAllShapes = getAllShapes;
            this.getShape = getShape;
            this.updateShapeUseCase = updateShapeUseCase;
        }

        [HttpGet]
        public IEnumerable<ShapeViewModel> GetAll()
        {
            var shapes = from shape in getAllShapes.Execute()
                         select ShapeViewModelFactory.CreateFrom(shape);
            return shapes;
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<ShapeViewModel> Get(Guid id)
        {
            var shape = getShape.Execute(id);
            if (shape == null)
                return NotFound();

            return Ok(ShapeViewModelFactory.CreateFrom(shape));
        }

        [HttpPost]
        public ActionResult Create([FromBody] dynamic inputModel)
        {
            // TODO: add validation for inputModel here then return 400 Bad Request if invalid

            var id = addShapeUseCase.Execute(new AddShapeRequest 
            {
                Type = inputModel.type,
                Length = inputModel.length,
                Radius = inputModel.radius,
                Side = inputModel.side,
                Width = inputModel.width
            });
            var newlyCreatedShape = getShape.Execute(id.Value);
            return CreatedAtAction(nameof(Get), new { id = id.Value }, ShapeViewModelFactory.CreateFrom(newlyCreatedShape));
        }
        
        [HttpPut("{id:Guid}")]
        public ActionResult<ShapeViewModel> Update(Guid id, [FromBody] dynamic inputModel)
        {
            var shape = getShape.Execute(id);
            if (shape == null)
                return NotFound();

            // TODO: add validation for inputModel here then return 400 Bad Request if invalid

            updateShapeUseCase.Execute(new UpdateShapeRequest 
            {
                Id = id,
                Length = inputModel.length,
                Radius = inputModel.radius,
                Side = inputModel.side,
                Width = inputModel.width
            });
            var updatedShape = getShape.Execute(shape.Id.Value);
            return Ok(ShapeViewModelFactory.CreateFrom(updatedShape));
        }
    }
}
