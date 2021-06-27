using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model.Shapes
{
    public class ShapeType : Enumeration
    {
        public readonly static ShapeType Line = new(1, nameof(Line));
        public readonly static ShapeType Circle = new(2, nameof(Circle));
        public readonly static ShapeType Square = new(3, nameof(Square));
        public readonly static ShapeType Rectangle = new(4, nameof(Rectangle));

        public ShapeType(int id, string name)
            : base(id, name)
        {
        }
    }
}
