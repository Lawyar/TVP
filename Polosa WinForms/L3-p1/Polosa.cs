using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace L3_p1
{
    class Polosa
    {
        Rectangle r;
        Random rand;
        Color c;

        public Polosa(int x, int y, int w, int h)
        {
            r = new Rectangle(x, y, w, h);
        }

        internal void Paint(Graphics g)
        {
            SolidBrush brush = new SolidBrush(c);
            g.FillRectangle(brush, r);
            g.DrawRectangle(Pens.Black, r);
        }

        internal bool isInside(int x, int y)
        {
            if (x < r.Left || x > r.Right)
                return false;
            if (y < r.Top || y > r.Bottom)
                return false;
            return true;
        }

        internal bool Overlap(Polosa p)
        {
            return r.IntersectsWith(p.r);
        }

        public void set_color(int r, int g, int b)
        {
            rand = new Random();
            c = Color.FromArgb(r, g, b);
        }
    }
}
