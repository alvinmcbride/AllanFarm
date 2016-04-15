using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Farm
{
    internal class House : Drawing
    {
        private int _DoorWidth = 100;
        public string DoorState = "CLOSED";
        public bool IsDoorClosing;
        public bool IsDoorOpening;

        public void Draw(PaintEventArgs e)
        {
            Graphics = e.Graphics;

            //Front
            //Front base
            Rectangle(Brushes.Red, 180, 200, 250, 250);

            //Front roof
            var point1 = new PointF(180F, 200.0F);
            var point2 = new PointF(290.0F, 130.0F);
            var point3 = new PointF(430.0F, 200.0F);

            PointF[] myPoints = {point1, point2, point3};
            Polygon(Brushes.Gray, myPoints);


            //Side
            //Side base
            Rectangle(Brushes.Red, 430, 200, 450, 250);

            //Side roof
            // Create points that define polygon.
            PointF[] myPoints2 =
            {
                new PointF(290F, 130.0F)
                , new PointF(790F, 130.0F)
                , new PointF(880F, 200F)
                , new PointF(430F, 200F)
            };

            Polygon(Brushes.Gray, myPoints2);

            //Inside
            Rectangle(Brushes.Black, 250, 300, 100, 150);

            // Door
            DrawDoor();


            //Draw String
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            PointF drawPoint = new PointF(150.0F, 150.0F);
            
           //Graphics.DrawString(_DoorWidth.ToString(), drawFont, drawBrush, drawPoint);
           
        }

        public void DoorPress()
        {
            if (DoorState == "CLOSED")
                IsDoorOpening = true;
            else if (DoorState == "OPENED")
                IsDoorClosing = true;
        }

        private void DrawDoor()
        {
            //if (IsDoorClosing && _DoorWidth > 80)
            //    Debugger.Break();

           if (IsDoorOpening)
                _DoorWidth -= 2;

            if (IsDoorClosing)
                _DoorWidth += 2;

            if (_DoorWidth >= 100)
            {
                _DoorWidth = 100;
                IsDoorClosing = false;
                DoorState = "CLOSED";
            }

            if (_DoorWidth <= 0)
            {
                _DoorWidth = 0;
                IsDoorOpening = false;
                DoorState = "OPENED";
            }
            Rectangle(Brushes.Honeydew, 250, 300, _DoorWidth, 150);
            if (_DoorWidth == 100)
                //Door Knob
                Ellipse(Brushes.Black, 325, 375, 10, 10);
        }

        
    }
}