using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model.Shapes
{
    internal class ShapeType : Enumeration
    {
        

        public ShapeType(int id, string name)
            : base(id, name)
        {
        }
    }
}
