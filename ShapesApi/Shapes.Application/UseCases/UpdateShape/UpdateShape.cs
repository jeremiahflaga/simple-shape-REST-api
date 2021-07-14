using Shapes.Domain.Interfaces;
using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Application.UseCases.UpdateShape
{
    public class UpdateShape
    {
        private readonly IShapeRepository shapeRepository;

        public UpdateShape(IShapeRepository shapeRepository)
        {
            this.shapeRepository = shapeRepository;
        }

        public void Execute(UpdateShapeRequest request)
        {
            var shape = shapeRepository.Get(new ShapeId(request.Id));
            if (shape != null)
                shapeRepository.Update(ShapeFactory.Create(shape.Id, shape.Type, request));
        }
    }
}
