using System;

namespace Patterns
{
    /// <summary>
    /// Класс, представляющий треугольник.
    /// </summary>
    public class Triangle : IPattern
    {
        private readonly double _sideA, _sideB, _sideC;

        /// <summary>
        /// Конструктор класса Triangle, принимающий длины сторон треугольника.
        /// </summary>
        /// <param name="sideA">Длина первой стороны треугольника.</param>
        /// <param name="sideB">Длина второй стороны треугольника.</param>
        /// <param name="sideC">Длина третьей стороны треугольника.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если указанные стороны не могут образовать треугольник.</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA >= sideB + sideC || sideB >= sideC + sideA || sideC >= sideA + sideB)
            {
                throw new ArgumentException("Указанные стороны не могут образовать треугольник.");
            }
            (_sideA, _sideB, _sideC) = (sideA, sideB, sideC);
        }

        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным.
        /// </summary>
        /// <returns>True, если треугольник прямоугольный, иначе False.</returns>
        public bool IsRectangular()
        {
            (double squaredA, double squaredB, double squaredC) = (_sideA * _sideA, _sideB * _sideB, _sideC * _sideC);
            return squaredA == squaredB + squaredC || squaredB == squaredC + squaredA || squaredC == squaredA + squaredB;
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        public double GetSquare()
        {
            double semiPerimeter = (_sideA + _sideB + _sideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
        }
    }
}
