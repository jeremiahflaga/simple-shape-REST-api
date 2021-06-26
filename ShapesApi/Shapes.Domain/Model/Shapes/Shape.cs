using System;

namespace Shapes.Domain.Model
{
    public abstract class Shape
    {
        internal Shape(ShapeId id)
        {
            Id = id;
        }

        public ShapeId Id { get; }
        public abstract string Type { get; }
        public abstract double Area { get; }
    }
}
