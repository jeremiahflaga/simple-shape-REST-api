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
        
        [Obsolete("Use dedicated Add method for each shape intead")]
        public void Add(ShapeId id, ShapeType type, dynamic data) 
        {
            shapeRepository.Add(ShapeFactory.CreateNew(id, type, data));
        }        
        
        public ShapeId AddLine(double length)
        {
            var id = new ShapeId();
            shapeRepository.Add(new Line(id, length));
            return id;
        }
        
        public ShapeId AddCircle(double radius)
        {
            var id = new ShapeId();
            shapeRepository.Add(new Circle(id, radius));
            return id;
        }
        
        public ShapeId AddSquare(double side)
        {
            var id = new ShapeId();
            shapeRepository.Add(new Square(id, side));
            return id;
        }
        
        public ShapeId AddRectangle(double length, double width)
        {
            var id = new ShapeId();
            shapeRepository.Add(new Rectangle(id, length, width));
            return id;
        }

        [Obsolete("Use Get<T> intead")]
        public Shape Get(ShapeId id)
        {
            return shapeRepository.Get(id);
        }
        
        public T Get<T>(ShapeId id) where T : Shape
        {
            return shapeRepository.Get<T>(id);
        }

        public IEnumerable<Shape> GetAll() 
        {
            return shapeRepository.GetAll();
        }
        
        [Obsolete("Use dedicated Update method for each shape intead")]
        public void Update(Shape shape, dynamic data)
        {
            var updatedShape = ShapeFactory.CreateNew(shape.Id, shape.Type, data);
            shapeRepository.Update(updatedShape);
        }

        public void UpdateLine(ShapeId id, double length)
        {
            shapeRepository.Update(new Line(id, length));
        }

        public void UpdateCircle(ShapeId id, double radius)
        {
            shapeRepository.Update(new Circle(id, radius));
        }
        
        public void UpdateSquare(ShapeId id, double side)
        {
            shapeRepository.Update(new Square(id, side));
        }
        
        public void UpdateRectangle(ShapeId id, double length, double width)
        {
            shapeRepository.Update(new Rectangle(id, length, width));
        }
    }
}
