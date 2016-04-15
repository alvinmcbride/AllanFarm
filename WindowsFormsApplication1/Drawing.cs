using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Drawing
    {
        protected Graphics Graphics;

        public void Rectangle(Brush brush, int x, int y, int width, int height, bool drawBorder = true, Pen p = null)
        {
            Graphics.FillRectangle(brush, x, y, width, height);
            if (p == null)
                p = new Pen(Color.Black, 2);
            
            if (drawBorder)
                Graphics.DrawRectangle(p, x, y, width, height);
        }

        public void Ellipse(Brush brush, int x, int y, int width, int height, bool drawBorder = true, Pen p = null)
        {
            Graphics.FillEllipse(brush, x, y, width, height);

            if (p == null)
                p = new Pen(Color.Black, 2);

            if (drawBorder)
                Graphics.DrawEllipse(p, x, y, width, height);
        }

        public void Polygon(Brush brush, PointF[] myPoints, bool drawBorder = true, Pen p = null)
        {
            Graphics.FillPolygon(brush, myPoints);

            if (p == null)
                p = new Pen(Color.Black, 2);

            if (drawBorder)
                Graphics.DrawPolygon(p, myPoints);
        }

        public void Line(Pen p, int x, int y, int x2, int y2)
        {
            Graphics.DrawLine(p, x, y, x2, y2);
        }
    }
}
