//using Shapes.Domain.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using System.Dynamic;

//namespace Shapes.Data.Repositories
//{
//    internal class ShapeFactory
//    {
//        internal static Shape CreateFrom(ShapeDataModel dataModel)
//        {
//            if (dataModel.Type == ShapeType.Line.Name)
//                return new Line(new ShapeId(dataModel.Id), dataModel.Data.Length);
//            else if (dataModel.Type == ShapeType.Circle.Name)
//                return new Circle(new ShapeId(dataModel.Id), dataModel.Data.Radius);             
//            else if (dataModel.Type == ShapeType.Square.Name)
//                return new Square(new ShapeId(dataModel.Id), dataModel.Data.Side);
//            else if (dataModel.Type == ShapeType.Rectangle.Name)
//                return new Rectangle(new ShapeId(dataModel.Id), dataModel.Data.Length, dataModel.Data.Width);
//            else
//                throw new Exception($"Cannot convert shape with Id '{dataModel.Id}' and Type '{dataModel.Type}'");
//        }
//    }
//}
