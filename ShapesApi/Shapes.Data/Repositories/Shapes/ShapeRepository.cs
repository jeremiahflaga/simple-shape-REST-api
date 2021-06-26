using Shapes.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Shapes.Data.Repositories
{
    public class ShapeRepository : IShapeRepository
    {
        //private static Guid circle1_id = Guid.NewGuid();
        private static ConcurrentDictionary<Guid, ShapeDataModel> shapesDictionary = new ConcurrentDictionary<Guid, ShapeDataModel>() ;

        static ShapeRepository()
        {
            var circle1 = new ShapeDataModel { Id = Guid.NewGuid(), Type = "circle" };
            circle1.Data.Radius = 3;
            shapesDictionary.TryAdd(circle1.Id, circle1);
        }

        public IEnumerable<Domain.Model.Shape> GetAll()
        {
            return from dataModel in shapesDictionary.Values 
                   select ShapeFactory.CreateFrom(dataModel);
        }
    }
}
