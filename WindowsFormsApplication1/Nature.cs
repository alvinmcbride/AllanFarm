#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace Farm
{
    internal class Nature : Drawing
    {
        private readonly List<AnimalStorage> MyAnimalStorageList = new List<AnimalStorage>();
        private const int ImageWidth = 96;
        private const int ImageHeight = 96;
        public bool SunVisible = true;
        public int plane_x = 540;
        public int[] GrassHeights = new int[1100]; 

        

        public void Draw(PaintEventArgs e)
        {
            Graphics = e.Graphics;

            //Grass
            Rectangle(Brushes.LightGreen, 0, 450, 1250, 1000, false);

            // Loop by 10 until 1100
            Random rgrass = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int x = 0; x < 1100; x += 10)
            {
                int g1 = rgrass.Next(430, 450);
                if (GrassHeights[x] == 0)
                    GrassHeights[x] = g1;
                Line(new Pen(Color.Green, 2), 10 + x, 450, 10 + x, GrassHeights[x]);
            }

            DrawAnimals();
            DrawPlane();

            if (SunVisible)
                //Sun
                Ellipse(Brushes.Yellow, -100, -100, 200, 200);
            else
            {
                SolidBrush transparantBrush = new SolidBrush(Color.FromArgb(230,Color.Black));
                Rectangle(transparantBrush, 0, 0, 1080, 1080);
            }
            
            
        }

        

        private void DrawAnimals()
        {
            if (MyAnimalStorageList.Count == 0)
            {
                // Create random objects for x, y and image
                Random rx = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
                Random ry = new Random((int) DateTime.Now.Ticks & 0x0000FCFF);
                Random rImage = new Random((int) DateTime.Now.Ticks & 0x0000CFFF);

                

                // Create 10 random animals
                for (int x = 0; x < 10; x++)
                {
                    Rectangle r;

                    // Pick a random image from 1-4
                    int imageNum = rImage.Next(1, 5);

                    int counter = 0;
                    // Make sure that images do not overlap with each other
                    do
                    {
                        // Pick random x from 0 - 999
                        int x1 = rx.Next(0, 1000 - ImageWidth);

                        // Pick random y from 500 - 999
                        int y1 = ry.Next(500, 1000 - ImageHeight);

                        // Create a Rectangle with information
                        r = new Rectangle(x1, y1, ImageWidth, ImageHeight);

                        // Only try 1000 times to find unique location
                        if (counter++ > 1000)
                            break;
                    } while (IsInvalidLocation(r));  // Make sure no overlap


                    // Create new animalStorage object from Rectangle
                    AnimalStorage animalStorage = new AnimalStorage
                    {
                        MyRectangle = r,
                        Animalnum = imageNum
                    };

                    // Add to list of AnimalStorage
                    MyAnimalStorageList.Add(animalStorage);

                    DrawAnimals(animalStorage);
                }
            }
            else
            {
                foreach(AnimalStorage an in MyAnimalStorageList)
                    DrawAnimals(an);
            }
        }

        private bool IsInvalidLocation(Rectangle rectangle)
        {
            return MyAnimalStorageList.Any(an => an != null && rectangle.IntersectsWith(an.MyRectangle));
        }

        private void DrawAnimals(AnimalStorage animalStorage)
        {
            Image image;

            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            dir = dir + "\\images\\";

            if (animalStorage.Animalnum == 1)
                image = Image.FromFile(dir + "squirrel-icon.png");
            else if (animalStorage.Animalnum == 2)
                image = Image.FromFile(dir + "Cat-Brown-icon.png");
            else if (animalStorage.Animalnum == 3)
                image = Image.FromFile(dir + "Dragon-icon.png");
            else
                image = Image.FromFile(dir + "Giraffe-icon.png");

            Graphics.DrawImage(image, animalStorage.MyRectangle);
        }

        private void DrawPlane()
        {
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            dir = dir + "\\images\\";

            Image p = Image.FromFile(dir + "plane.png");
            Rectangle r = new Rectangle(plane_x,50,32,32);
            Graphics.DrawImage(p,r);

           
            
                
                
            


        }


    }
}