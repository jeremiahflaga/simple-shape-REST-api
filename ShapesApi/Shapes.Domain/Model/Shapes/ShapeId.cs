using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Domain.Model
{
    public class ShapeId : ValueObject
    {
        public readonly Guid Value;
        
        public ShapeId()
        {
            this.Value = Guid.NewGuid();
        }
        
        public ShapeId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException($"Guid for {this.GetType().Name} cannot be empty", nameof(id));

            this.Value = id;
        }
                
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
