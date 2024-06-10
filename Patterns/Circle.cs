using System;

namespace Patterns
{
    /// <summary>
    /// Класс, представляющий круг.
    /// </summary>
    public class Circle : IPattern
    {
        private readonly double _radius;

        /// <summary>
        /// Конструктор класса Circle, принимающий радиус круга.
        /// </summary>
        /// <param name="_radius">Радиус круга, который должен быть положительным числом.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если радиус меньше или равен нулю.</exception>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть положительным числом.", nameof(radius));
            }
            _radius = radius;
        }

        /// <summary>
        /// Метод для вычисления площади круга.
        /// </summary>
        /// <returns>Площадь круга.</returns>
        public double GetSquare() => Math.PI * _radius * _radius;
    }
}
