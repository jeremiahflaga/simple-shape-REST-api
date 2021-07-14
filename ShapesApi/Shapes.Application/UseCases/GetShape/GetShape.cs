using Shapes.Domain.Interfaces;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Application.UseCases.GetShape
{
    public class GetShape
    {
        private readonly IShapeRepository shapeRepository;

        public GetShape(IShapeRepository shapeRepository)
        {
            this.shapeRepository = shapeRepository;
        }
        
        public Shape Execute(Guid id)
        {
            return shapeRepository.Get(new ShapeId(id));
        }
    }
}
