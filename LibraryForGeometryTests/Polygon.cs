﻿namespace LibraryForGeometryTests
{
    public class Polygon : IShapeWithPosition
    {
        private readonly List<IShapeWithPosition> _shapes = new();

        public IReadOnlyCollection<IShapeWithPosition> Shapes => _shapes.AsReadOnly();

        public Point Position => GetBoundingBox().Center;

        public void AddShape(IShapeWithPosition shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            _shapes.Add(shape);
        }

        public void RemoveShape(IShapeWithPosition shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            _shapes.Remove(shape);
        }

        public double GetArea()
        {
            return _shapes.Sum(s => s.GetArea());
        }

        public double GetPerimeter()
        {
            return _shapes.Sum(s => s.GetPerimeter());
        }

        // Получает "ограничивающий прямоугольник" вокруг всех фигур
        public BoundingBox GetBoundingBox()
        {
            if (!_shapes.Any())
                return new BoundingBox(new Point(0, 0), new Point(0, 0));

            var allPoints = _shapes.SelectMany(GetCorners).ToList();
            double minX = allPoints.Min(p => p.X);
            double maxX = allPoints.Max(p => p.X);
            double minY = allPoints.Min(p => p.Y);
            double maxY = allPoints.Max(p => p.Y);

            return new BoundingBox(new Point(minX, minY), new Point(maxX, maxY));
        }

        // Проверяет, есть ли пересечение между любыми двумя фигурами
        public bool HasIntersection()
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                for (int j = i + 1; j < _shapes.Count; j++)
                {
                    var box1 = GetBoundingBoxFor(_shapes[i]);
                    var box2 = GetBoundingBoxFor(_shapes[j]);

                    if (box1.Intersects(box2))
                        return true;
                }
            }

            return false;
        }

        private BoundingBox GetBoundingBoxFor(IShapeWithPosition shape)
        {
            return shape switch
            {
                Circle c => new BoundingBox(
                    new Point(c.Position.X - c.Radius, c.Position.Y - c.Radius),
                    new Point(c.Position.X + c.Radius, c.Position.Y + c.Radius)),

                Rectangle r => new BoundingBox(
                    new Point(r.Position.X - r.Width / 2, r.Position.Y - r.Height / 2),
                    new Point(r.Position.X + r.Width / 2, r.Position.Y + r.Height / 2)),

                Triangle t => new BoundingBox(t.Position, t.Position),

                _ => new BoundingBox(shape.Position, shape.Position)
            };
        }

        private IEnumerable<Point> GetCorners(IShapeWithPosition shape)
        {
            var box = GetBoundingBoxFor(shape);
            yield return box.BottomLeft;
            yield return box.TopRight;
        }
    }
}