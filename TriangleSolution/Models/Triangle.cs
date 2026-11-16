using System;

namespace Triangles.Models
{
    public class Triangle
    {
        private double side1;
        private double side2;
        private double side3;

        public Triangle()
        {
        }

        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public double Side1
        {
            get { return side1; }
            set { side1 = value; }
        }
        public double Side2
        {
            get { return side2; }
            set { side2 = value; }
        }
        public double Side3
        {
            get { return side3; }
            set { side3 = value; }
        }

        public static bool AreEqual(double a, double b)
        {
            return Math.Abs(a - b) < 0.00001 * Math.Abs(a);
        }

        public double[] GetSortedSides()
        {
            double[] sides = { side1, side2, side3 };
            Array.Sort(sides);
            return sides;
        }

        public bool IsValid()
        {
            double[] s = GetSortedSides();
            return s[0] > 0 && s[1] > 0 && s[2] > 0 && (s[0] + s[1] > s[2]);
        }

        public double Perimeter()
        {
            return side1 + side2 + side3;
        }

        public double Area()
        {
            double p = Perimeter() / 2.0;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }

        public bool IsRightAngled()
        {
            double[] s = GetSortedSides();
            return AreEqual(s[0] * s[0] + s[1] * s[1], s[2] * s[2]);
        }

        public bool IsEquilateral()
        {
            double[] s = GetSortedSides();
            return AreEqual(s[0], s[1]) && AreEqual(s[1], s[2]) && AreEqual(s[0], s[2]);
        }

        public bool IsIsosceles()
        {
            double[] s = GetSortedSides();
            return AreEqual(s[0], s[1]) || AreEqual(s[1], s[2]);
        }

        public bool IsCongruentTo(Triangle other)
        {
            double[] s1 = GetSortedSides();
            double[] s2 = other.GetSortedSides();
            return AreEqual(s1[0], s2[0]) && AreEqual(s1[1], s2[1]) && AreEqual(s1[2], s2[2]);
        }

        public bool IsSimilarTo(Triangle other)
        {
            double[] s1 = GetSortedSides();
            double[] s2 = other.GetSortedSides();
            double p1 = Perimeter();
            double p2 = other.Perimeter();

            return AreEqual(s1[0] / p1, s2[0] / p2) &&
                   AreEqual(s1[1] / p1, s2[1] / p2) &&
                   AreEqual(s1[2] / p1, s2[2] / p2);
        }

        public string GetInfo()
        {
            double[] s = GetSortedSides();
            double p = Perimeter();
            double area = Area();

            return string.Format(
                "Triangle:{0}({1}, {2}, {3}){0}Reduced:{0}({4:F2}, {5:F2}, {6:F2}){0}{0}Area = {7:F2}{0}Perimeter = {8}",
                Environment.NewLine,
                s[0],
                s[1],
                s[2],
                s[0] / p,
                s[1] / p,
                s[2] / p,
                area,
                p
            );
        }
    }
}