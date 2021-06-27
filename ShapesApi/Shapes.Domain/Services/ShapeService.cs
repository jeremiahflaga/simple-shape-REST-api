using Shapes.Domain.Interfaces;
using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
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
        
        public void Add(ShapeId id, ShapeType type, dynamic data) 
        {
            shapeRepository.Add(ShapeFactory.CreateNew(id, type, data));
        }        

        public Shape Get(ShapeId id)
        {
            return shapeRepository.Get(id);
        }

        public IEnumerable<Shape> GetAll() 
        {
            return shapeRepository.GetAll();
        }

        public void Update(Shape shape, dynamic data)
        {
            var updatedShape = ShapeFactory.CreateNew(shape.Id, shape.Type, data);
            shapeRepository.Update(updatedShape);
        }
    }
}
