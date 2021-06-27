using Shapes.Domain.Model;
using Shapes.Domain.Model.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Interfaces
{
    public interface IShapeRepository
    {
        void Add(Shape shape);
        Shape Get(ShapeId id);
        IEnumerable<Shape> GetAll();
        void Update(Shape shape);
    }
}
