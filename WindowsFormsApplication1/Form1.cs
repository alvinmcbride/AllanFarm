#region

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace Farm
{
    public partial class Form1 : Form
    {
        private House _House;
        private Nature _Nature;
        

        public Form1()
        {
            InitializeComponent();

            
            BackColor = Color.SkyBlue;
            _House = new House();
            _Nature = new Nature();



            // Stop flickering
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }

        public override sealed Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            _House.Draw(e);

            _Nature.Draw(e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                _Nature.SunVisible = !_Nature.SunVisible;
                Invalidate();
            }
            // Check what key was pressed
            if (e.KeyCode == Keys.D)
            {
                // Call door press function
                _House.DoorPress();

                // Enable timer
                DoorTimer.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_House.IsDoorOpening || _House.IsDoorClosing)
                Invalidate();
            else
                DoorTimer.Enabled = false;
        }

        /*private void PlaneTimer_Tick(object sender, EventArgs e)
        {
            _Nature.plane_x += 5;
            Invalidate();
            if (_Nature.plane_x > 1080)
            {
                _Nature.plane_x -= 1200;
            }
            
        }
        */
    }
}