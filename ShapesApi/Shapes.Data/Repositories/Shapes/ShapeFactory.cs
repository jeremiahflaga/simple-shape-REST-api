using Shapes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Dynamic;

namespace Shapes.Data.Repositories
{
    internal class ShapeFactory
    {
        internal static Domain.Model.Shape CreateFrom(ShapeDataModel dataModel)
        {
            switch (dataModel.Type)
            {
                case "circle":
                    //var circle = JsonSerializer.Deserialize<Circle>(dataModel.Data);
                    return new Circle(new ShapeId(dataModel.Id), dataModel.Data.Radius);
                default:
                    throw new Exception($"Cannot convert shape with Id '{dataModel.Id}' and Type '{dataModel.Type}'");
            }
        }
    }
}
