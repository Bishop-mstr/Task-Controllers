using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Triangles.Models;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        public string Info(Triangle tr)
        {
            if (tr == null || !tr.IsValid()) throw new ArgumentException("Invalid triangle");
            return tr.GetInfo();
        }

        public string Area(Triangle tr)
        {
            if (tr == null || !tr.IsValid()) throw new ArgumentException("Invalid triangle");
            return string.Format("{0:F4}", tr.Area());
        }

        public double Perimeter(Triangle tr)
        {
            if (tr == null || !tr.IsValid()) throw new ArgumentException("Invalid triangle");
            return tr.Perimeter();
        }

        public bool IsRightAngled(Triangle tr)
        {
            if (tr == null || !tr.IsValid()) throw new ArgumentException("Invalid triangle");
            return tr.IsRightAngled();
        }

        public bool IsEquilateral(Triangle tr)
        {
            if (tr == null || !tr.IsValid()) throw new ArgumentException("Invalid triangle");
            return tr.IsEquilateral();
        }

        public bool IsIsosceles(Triangle tr)
        {
            if (tr == null) throw new ArgumentException("Invalid triangle");
            return tr.IsIsosceles();
        }

        public bool AreCongruent(Triangle tr1, Triangle tr2)
        {
            if (tr1 == null || tr2 == null) throw new ArgumentException("Invalid triangle");
            return tr1.IsCongruentTo(tr2);
        }

        public bool AreSimilar(Triangle tr1, Triangle tr2)
        {
            if (tr1 == null || tr2 == null) throw new ArgumentException("Invalid triangle");
            return tr1.IsSimilarTo(tr2);
        }

        public string InfoGreatestPerimeter(Triangle[] tr)
        {
            if (tr == null || tr.Length == 0) throw new ArgumentException("Invalid triangles");
            foreach (Triangle t in tr)
            {
                if (t == null || !t.IsValid()) throw new ArgumentException("Invalid triangle");
            }

            Triangle best = tr[0];
            for (int i = 1; i < tr.Length; i++)
            {
                if (tr[i].Perimeter() > best.Perimeter())
                {
                    best = tr[i];
                }
            }
            return best.GetInfo();
        }

        public string InfoGreatestArea(Triangle[] tr)
        {
            if (tr == null || tr.Length == 0) throw new ArgumentException("Invalid triangles");
            foreach (Triangle t in tr)
            {
                if (t == null || !t.IsValid()) throw new ArgumentException("Invalid triangle");
            }

            Triangle best = tr[0];
            for (int i = 1; i < tr.Length; i++)
            {
                if (tr[i].Area() > best.Area())
                {
                    best = tr[i];
                }
            }
            return best.GetInfo();
        }

        public string NumbersPairwiseNotSimilar(Triangle[] tr)
        {
            if (tr == null || tr.Length == 0) throw new ArgumentException("Invalid triangles");
            foreach (Triangle t in tr)
            {
                if (t == null || !t.IsValid()) throw new ArgumentException("Invalid triangle");
            }

            List<string> pairs = new List<string>();
            for (int i = 0; i < tr.Length; i++)
            {
                for (int j = i + 1; j < tr.Length; j++)
                {
                    if (!tr[i].IsSimilarTo(tr[j]))
                    {
                        pairs.Add($"({i + 1}, {j + 1})");
                    }
                }
            }
            return string.Join(Environment.NewLine, pairs);
        }
    }
}