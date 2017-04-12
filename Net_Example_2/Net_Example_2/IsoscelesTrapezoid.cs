using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net_Example_2
{
    class IsoscelesTrapezoid : Quadrangle
    {
        // Зачем ?!

        public readonly double height;
        public readonly double middleLine;

        public IsoscelesTrapezoid(Point a, Point b, Point c, Point d)
            : base(a, b, c, d)
        {
            height = Math.Sqrt(Math.Pow(AB_length, 2) - (Math.Pow(AD_length - BC_length, 2) / 4));
            middleLine = (AD_length + BC_length) / 2;
        }

        public override string GetInfoAboutFigure()
        {
            string information = "AB = " + AB_length + "\nBC = " + BC_length + "\nCD = " + CD_length + "\nAD = " + AD_length +
                "\nBD = " + BD_length + "\nAC = " + AC_length + "\nHeight = " + this.height + 
                "\nMiddleLine = "+ middleLine+ "\nP = " + Perimetr + "\nS = " + S;
            return information;
        }
    }
}
