namespace Patterns.Test
{
    public class Tests
    {
        private Circle _circle1, _circle2;
        private Triangle _triangle1, _triangle2;
        private Rectangle _rectangle;

        [SetUp]
        public void Setup()
        {
            _circle1 = new Circle(15);
            _circle2 = new Circle(2);
            _triangle1 = new Triangle(3, 4, 5);
            _triangle2 = new Triangle(2, 2, 2);
            _rectangle = new Rectangle(5, 7);
        }

        [Test]
        public void TestCircleSquare()
        {
            Assert.That(_circle1.GetSquare(), Is.EqualTo(Math.PI * 15 * 15));
            Assert.That(_circle2.GetSquare(), Is.EqualTo(Math.PI * 2 * 2));
        }

        [Test]
        public void TestTriangleSquare()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_triangle1.GetSquare(), Is.EqualTo(6));
                Assert.That(_triangle2.GetSquare(), Is.EqualTo(Math.Sqrt(3) / 4 * 2 * 2));
            });
        }

        [Test]
        public void TestTriangleIsRectangular()
        {
            Assert.That(_triangle1.IsRectangular(), Is.True);
            Assert.That(_triangle2.IsRectangular(), Is.False);
        }

        public class Rectangle : IPattern
        {
            private readonly double _length, _width;
            public Rectangle(double length, double width)
            {
                (_length, _width) = (length, width);
            }
            public double GetSquare() => _length * _width;
        }

        [Test]
        public void TestRectangleSquare()
        {
            Assert.That(_rectangle.GetSquare(), Is.EqualTo(35));
        }

        [Test]
        public void TestIPatternSquare()
        {
            IPattern pattern = _rectangle;
            Assert.That(pattern.GetSquare(), Is.EqualTo(35));
        }
    }
}
