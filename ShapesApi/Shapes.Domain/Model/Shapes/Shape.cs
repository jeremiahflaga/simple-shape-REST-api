using System;

namespace Shapes.Domain.Model.Shapes
{
    public abstract class Shape
    {
        protected Shape(ShapeId id)
        {
            Id = id;
        }

        public ShapeId Id { get; }
        public abstract ShapeType Type { get; }

        public abstract double ComputeArea();
        public abstract double ComputePerimeter();
    }
}
