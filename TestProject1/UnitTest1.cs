

using System.Linq.Expressions;
using LibraryForGeometryTests;

namespace TestProject1
{

    public class Tests

    {
        [Test]//1(Point)
        public void PointsWithSameCoordinates_AreEqual()
        {
            var point1 = new Point(5, 3);
            var point2 = new Point(5, 3);
            Assert.AreEqual(point1.X, point2.X);
            Assert.AreEqual(point1.Y, point2.Y);

        }

        [Test]//2(Point)
        public void PointsWithDifferentCoordinates_AreNotEqual()
        {
            var point1 = new Point(4, 3);
            var point2 = new Point(5, 2);
            Assert.AreNotEqual(point1.X, point2.X);
            Assert.AreNotEqual(point1.Y, point2.Y);

        }

        [Test]//3(Point)
        public void NullPoint_ThrowsException()
        {
            Point point = null;
            Assert.Throws<ArgumentNullException>(() => new Rectangle(point, 12, 678));

        }

        [Test]//4(Point)
        public void PointToString_ReturnsCorrectFormat()
        {
            var point = new Point(11, 8);
            string stringPoint = "(11, 8)";
            Assert.AreEqual(point.ToString(), stringPoint);
        }

        [Test]//1(BoundingBox)
        public void BoundingBox_Center_CalculatesCorrectly()
        {
            var box1 = new BoundingBox(new Point(0, 0), new Point(4, 4));
            var center = box1.Center;

            Assert.AreEqual(2, center.X);
            Assert.AreEqual(2, center.Y);
        }

        [Test]//2(BoundingBox)
        public void BoundingBox_IntersectingBoxes_ReturnsTrue()
        {
            var box1 = new BoundingBox(new Point(0, 0), new Point(4, 4));
            var box2 = new BoundingBox(new Point(2, 2), new Point(6, 6));
            var box3 = new BoundingBox(new Point(5, 5), new Point(7, 7));
            var box4 = new BoundingBox(new Point(1, 1), new Point(3, 3));
            Assert.IsTrue(box1.Intersects(box2), "");
            Assert.IsTrue(box1.Intersects(box4), "");
        }

        [Test]//3(BoundingBox)
        public void BoundingBox_NonIntersectingBoxes_ReturnsFalse()
        {
            var box1 = new BoundingBox(new Point(0, 0), new Point(4, 4));
            var box2 = new BoundingBox(new Point(2, 2), new Point(6, 6));
            var box3 = new BoundingBox(new Point(5, 5), new Point(7, 7));
            var box4 = new BoundingBox(new Point(1, 1), new Point(3, 3));
            Assert.IsFalse(box1.Intersects(box3), "");
        }

        [Test]//4(BoundingBox)
        public void BoundingBox_EqualBoxes_ReturnsTrue()
        {
            var box1 = new BoundingBox(new Point(0, 0), new Point(4, 4));
            var boxequalto1 = new BoundingBox(new Point(0, 0), new Point(4, 4));

            Assert.IsTrue(box1.Intersects(boxequalto1), "");
        }

        [Test]//5(BoundingBox)
        public void BoundingBox_EmptyBox_ThrowsOrHandlesGracefully()
        {
            var box1 = new BoundingBox(new Point(0, 0), new Point(4, 4));
            var emptybox = new BoundingBox(new Point(2, 2), new Point(2, 2));
            Assert.DoesNotThrow(() => box1.Intersects(emptybox), "");
            Assert.IsTrue(box1.Intersects(emptybox), "");
        }

        [Test]//1(Cirlce)

        public void Circle_GetArea_CorrectValue()
        {
            double radius = 5;
            var Circle = new Circle(new Point(3, 4), radius: 5);
            Assert.AreEqual(Math.PI * Math.Pow(radius, 2), Circle.GetArea());
        }

        [Test]//2(Cirlce)

        public void Circle_GetPerimeter_CorrectValue()
        {
            var BIGCircle = new Circle(new Point(10, 10), radius: 100);
            Assert.AreEqual(2 * Math.PI * 100, BIGCircle.GetPerimeter());
        }

        [Test]//3(Circle)
        public void Circle_NegativeRadius_ThrowsException()
        {
            var circlewithnegativeRadius = new Circle(new Point(3, 4), radius: -1);
            double area = circlewithnegativeRadius.GetPerimeter();
            Assert.IsTrue(area < 0);
        }

        [Test]//4(Circle)
        public void Circle_Position_SetCorrectly()
        {
            var Circle = new Circle(new Point(3, 4), radius: 5);
            Assert.AreEqual(3, Circle.Position.X);
            Assert.AreEqual(4, Circle.Position.Y);
        }

        [Test]//5(Cirlce)
        public void Circle_NullPosition_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Circle(null, radius: 5));
        }

        [Test]//1(Rectangle)

        public void Rectangle_GetArea_CorrectValue()
        {
            var NormRectangle1 = new Rectangle(new Point(3, 4), 5, 10);
            Assert.AreEqual(NormRectangle1.Width * NormRectangle1.Height, NormRectangle1.GetArea());
        }

        [Test]//2(Rectangle)

        public void Rectangle_GetPerimeter_CorrectValue()
        {
            var NormRectangle2 = new Rectangle(new Point(5, 10), 10, 15);
            Assert.AreEqual(2 * (NormRectangle2.Width + NormRectangle2.Height), NormRectangle2.GetPerimeter());
        }

        [Test]//3(Rectangle)
        public void Rectangle_ZeroWidth_ThrowsException()
        {
            var RectangleZeroWidth = new Rectangle(new Point(5, 10), 0, 15);
            Assert.IsFalse(RectangleZeroWidth.Width < 0);
        }

        [Test]//4(Rectangle)
        public void Rectangle_ZeroHeight_ThrowsException()
        {
            var RectangleZeroWidth = new Rectangle(new Point(5, 10), 15, 0);
            Assert.IsFalse(RectangleZeroWidth.Height < 0);
        }

        [Test]//5(Rectangle)
        public void Rectangle_Position_SetCorrectly()
        {
            var RectangleLL = new Rectangle(new Point(5, 10), 15, 10);
            Assert.AreEqual(5, RectangleLL.Position.X);
            Assert.AreEqual(10, RectangleLL.Position.Y);
        }

        [Test]//6(Rectangle)
        public void Rectangle_NullPosition_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Rectangle(null, 1, 1));
            Assert.Throws<ArgumentNullException>(() => new Rectangle(null, 0.5, 2));
        }

        [Test]//7(Rectangle)
        public void Rectangle_NegativeDimensions_ThrowsException()
        {
            var negativeDimensionsRectangle = new Rectangle(new Point(0, 0), -10, -22);
            Assert.IsFalse(negativeDimensionsRectangle.GetArea() < 0);
        }

        [Test]//1(Triangle)
        public void Triangle_GetArea_CorrectForValidSides()
        {
            var triangle1 = new Triangle(new Point(0, 0), 10, 4, 5);
            double p = (triangle1.A + triangle1.B + triangle1.C) / 2;
            Assert.AreEqual(Math.Sqrt(p * (p - triangle1.A) * (p - triangle1.B) * (p - triangle1.C)), triangle1.GetArea());
        }

        [Test]//2(Triangle)
        public void Triangle_InvalidSides_ThrowsException()
        {
            var triangle2 = new Triangle(new Point(0, 0), 0, 4, 5);
            Assert.IsFalse(triangle2.GetPerimeter() < 0);
        }

        [Test]//3(Triangle)

        public void Triangle_GetPerimeter_CorrectValue()
        {
            var triangle1 = new Triangle(new Point(0, 0), 10, 4, 5);
            Assert.AreEqual(triangle1.A + triangle1.B + triangle1.C, triangle1.GetPerimeter());
        }

        [Test]//4(Triangle)
        public void Triangle_Position_SetCorrectly()
        {
            var triangle1 = new Triangle(new Point(0, 0), 10, 4, 5);
            Assert.AreEqual(0, triangle1.Position.X);
            Assert.AreEqual(0, triangle1.Position.Y);
        }

        [Test]//5(Triangle)
        public void Triangle_NullPosition_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Triangle(null, 3, 4, 5));
            Assert.Throws<ArgumentNullException>(() => new Triangle(null, 1, 1, 1));
        }

        [Test]//1(Polygon)
        public void Polygon_Empty_GetAreaReturnsZero()
        {
            var emptyPolygon = new Polygon();
            Assert.AreEqual(0, emptyPolygon.GetArea());
        }

        [Test]//2(Polygon)
        public void Polygon_Empty_GetPerimeterReturnsZero()
        {
            var emptyPolygon = new Polygon();
            Assert.AreEqual(0, emptyPolygon.GetPerimeter());
        }

        [Test]//3(Polygon)
        public void Polygon_AddShape_IncreasesTotalArea()
        {
            var triangle = new Triangle(new Point(0, 0), 10, 4, 5);
            var polygon = new Polygon();
            var area = polygon.GetArea();
            polygon.AddShape(triangle);
            Assert.AreNotEqual(area, polygon.GetArea());
        }

        [Test]//4(Polygon)
        public void Polygon_RemoveShape_DecreasesTotalArea()
        {
            var triangle = new Triangle(new Point(0, 0), 10, 4, 5);
            var polygon = new Polygon();
            polygon.AddShape(triangle);
            var area = polygon.GetArea();
            polygon.RemoveShape(triangle);
            Assert.AreNotEqual(area, polygon.GetArea());
        }

        [Test]//5(Polygon)
        public void Polygon_GetBoundingBox_CalculatesCorrectBounds()
        {
            var polygon = new Polygon();
            var NormRectangle = new Rectangle(new Point(3, 3), 4, 5);
            var Circle = new Circle(new Point(0, 0), radius: 2);
            polygon.AddShape(Circle);
            polygon.AddShape(NormRectangle);
            var bbox = polygon.GetBoundingBox();

            Assert.AreEqual(-2, bbox.BottomLeft.X);
            Assert.AreEqual(-2, bbox.BottomLeft.Y);
            Assert.AreEqual(5, bbox.TopRight.X);
            Assert.AreEqual(5.5, bbox.TopRight.Y);
        }

        [Test]//6(Polygon)
        public void Polygon_AddNullShape_ThrowsException()
        {
            var polygon = new Polygon();
            Assert.Throws<ArgumentNullException>(() => polygon.AddShape(null));
        }

        [Test]//7(Polygon)
        public void Polygon_RemoveNullShape_ThrowsException()
        {
            var polygon = new Polygon();
            Assert.Throws<ArgumentNullException>(() => polygon.RemoveShape(null));
        }

        [Test]//8(Polygon)
        public void Polygon_HasIntersection_ReturnsTrue_WhenOverlapping()
        {
            var circle = new Circle(new Point(0, 0), radius: 2);
            var polygon = new Polygon();
            var overlappingCircle = new Circle(new Point(2, 0), 2);
            polygon.AddShape(circle);
            polygon.AddShape(overlappingCircle);
            Assert.IsTrue(polygon.HasIntersection());
        }

        [Test]//9(Polygon)
        public void Polygon_HasIntersection_ReturnsFalse_WhenNoOverlap()
        {
            var polygon = new Polygon();
            var circle = new Circle(new Point(0, 0), radius: 2);
            var triangle = new Triangle(new Point(0, 0), 10, 4, 5);
            polygon.AddShape(circle);
            polygon.AddShape(triangle);
            Assert.IsTrue(polygon.HasIntersection());
        }

        [Test]//10(Polygon)
        public void Polygon_HasIntersection_SingleShape_ReturnsFalse()
        {
            var polygon = new Polygon();
            var rectangle = new Rectangle(new Point(3, 3), 4, 5);
            polygon.AddShape(rectangle);
            Assert.IsFalse(polygon.HasIntersection());
        }

        [Test]//11(Polygon)
        public void Polygon_HasIntersection_Empty_ReturnsFalse()
        {
            var polygon = new Polygon();
            Assert.IsFalse(polygon.HasIntersection());

        }

    }
}