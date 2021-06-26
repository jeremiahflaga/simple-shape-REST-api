using Shapes.Domain.Interfaces;
using Shapes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Services
{
    public class ShapeService
    {
        private readonly IShapeRepository shapeRepository;

        public ShapeService(IShapeRepository shapeRepository)
        {
            this.shapeRepository = shapeRepository;
        }

        public IEnumerable<Shape> GetAll() 
        {
            return shapeRepository.GetAll();
        }
    }
}
