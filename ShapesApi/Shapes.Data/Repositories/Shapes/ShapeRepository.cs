using Shapes.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;

namespace Shapes.Data.Repositories
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly static ConcurrentDictionary<Guid, ShapeDataModel> shapesDictionary = new ConcurrentDictionary<Guid, ShapeDataModel>() ;

        static ShapeRepository()
        {
            var line1 = new Line(new ShapeId(), 3);
            shapesDictionary.TryAdd(line1.Id.Value, ShapeDataModelFactory.CreateFrom(line1));
            var circle1 = new Circle(new ShapeId(), 4);
            shapesDictionary.TryAdd(circle1.Id.Value, ShapeDataModelFactory.CreateFrom(circle1));            
            var square1 = new Square(new ShapeId(), 5);
            shapesDictionary.TryAdd(square1.Id.Value, ShapeDataModelFactory.CreateFrom(square1));            
            var rectangle1 = new Rectangle(new ShapeId(), 6, 7);
            shapesDictionary.TryAdd(rectangle1.Id.Value, ShapeDataModelFactory.CreateFrom(rectangle1));
        }

        public void Add(Shape shape)
        {
            shapesDictionary.TryAdd(shape.Id.Value, ShapeDataModelFactory.CreateFrom(shape));
        }

        [Obsolete("Use Get<T> instead")]
        public Shape Get(ShapeId id)
        {
            if (shapesDictionary.ContainsKey(id.Value))
                return shapesDictionary[id.Value].ConvertToShapeDomainModel();

            return null;
        }

        public T Get<T>(ShapeId id) where T : Shape
        {
            if (shapesDictionary.ContainsKey(id.Value)) 
            {
                var shape = shapesDictionary[id.Value];
                return ShapeFactory.CreateFrom<T>(shape);
            }

            return null;
        }

        public IEnumerable<Shape> GetAll()
        {
            return from dataModel in shapesDictionary.Values 
                   select dataModel.ConvertToShapeDomainModel();
        }

        public void Update(Shape shape)
        {
            if (shapesDictionary.ContainsKey(shape.Id.Value))
                shapesDictionary[shape.Id.Value] = ShapeDataModelFactory.CreateFrom(shape);
                
        }
    }
}
