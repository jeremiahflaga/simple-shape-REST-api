using Shapes.Domain.Interfaces;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Application.UseCases.GetAllShapes
{
    public class GetAllShapes
    {
        private readonly IShapeRepository shapeRepository;

        public GetAllShapes(IShapeRepository shapeRepository)
        {
            this.shapeRepository = shapeRepository;
        }
        
        public IEnumerable<Shape> Execute()
        {
            return shapeRepository.GetAll();
        }
    }
}
