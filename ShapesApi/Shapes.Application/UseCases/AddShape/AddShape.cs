using Shapes.Domain.Interfaces;
using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Application.UseCases.AddShape
{
    public class AddShape
    {
        private readonly IShapeRepository shapeRepository;

        public AddShape(IShapeRepository shapeRepository)
        {
            this.shapeRepository = shapeRepository;
        }

        public ShapeId Execute(AddShapeRequest request)
        {
            var id = new ShapeId();
            var type = Enumeration.FromDisplayName<ShapeType>(request.Type);
            shapeRepository.Add(ShapeFactory.Create(id, type, request));
            return id;
        }
    }
}
