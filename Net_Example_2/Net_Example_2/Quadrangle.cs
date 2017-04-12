using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net_Example_2
{
    class Quadrangle
    {
        // Координаты вершин 
        public readonly Point A;
        public readonly Point B;
        public readonly Point C;
        public readonly Point D;

        // Стороны
        public readonly double AB_length;
        public readonly double BC_length;
        public readonly double CD_length;
        public readonly double AD_length;

        // Диагонали
        public readonly double BD_length;
        public readonly double AC_length;

        public readonly double Perimetr;
        public readonly double S;

        // Конструктор
        public Quadrangle(Point a, Point b, Point c, Point d)
        {
            // Создаём точки для фигуры
            this.A = new Point(a.x, a.y);
            this.B = new Point(b.x, b.y);
            this.C = new Point(c.x, c.y);
            this.D = new Point(d.x, d.y);

            // Считаем стороны
            AB_length = GetSideLength(A, B);
            BC_length = GetSideLength(B, C);
            CD_length = GetSideLength(C, D);
            AD_length = GetSideLength(A, D);

            // Считаем диагонали
            BD_length = GetSideLength(B, D);
            AC_length = GetSideLength(A, C);

            // Считаем периметр
            Perimetr = AB_length + BC_length + CD_length + AD_length;

            // Считаем площадь
            S = Math.Sqrt(
                (Perimetr / 2 - AB_length) *
                (Perimetr / 2 - BC_length) *
                (Perimetr / 2 - CD_length) *
                (Perimetr / 2 - AD_length)
                );
        }

        public Quadrangle(){

        }

        private double GetSideLength(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        }

        public static bool IsIsoscelesTrapezoid(Quadrangle quadrangle)
        {
            return quadrangle.AC_length == quadrangle.BD_length && 
                quadrangle.AD_length != quadrangle.BC_length;
        }

        public virtual string GetInfoAboutFigure() {
            string information = "AB = " + AB_length + "\nBC = " + BC_length + "\nCD = " + CD_length + "\nAD = " + AD_length + 
                "\nBD = " + BD_length + "\nAC = " + AC_length + "\nP = " + Perimetr + "\nS = " + S;
            return information;
        }
    }
}
