using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace Lab5WP
{
    class Bricks
    {
        private List<Rectangle> elements = null;
        private int numOfElements, width, height, marginX, marginY;
        private SolidBrush primaryColor = new SolidBrush(Color.FromName("LightBlue"));
        public Bricks(int columns, int lines)
        {
            numOfElements = lines * columns;
            Rectangle[] allElements = new Rectangle[numOfElements]; // temp
            marginX = 2;
            marginY = 55;
            width = 82;
            height = 43;
            int iIndex = 1;
            int distanceMarginY = marginY; //tempVar

            for(int i = 0; i < lines ; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    allElements[iIndex - 1].X = marginX + marginX * j + width * j;
                    allElements[iIndex - 1].Y = distanceMarginY;
                    allElements[iIndex - 1].Width = width;
                    allElements[iIndex - 1].Height = height;
                    iIndex++;
                }
                distanceMarginY += 45;
            }
            elements = new List<Rectangle>(allElements);
        }

        public Rectangle GetBrick(int index)
        {
            return elements[index];
        }

        public void DestroyBrick(int index)
        {
            elements.RemoveAt(index);
            numOfElements -= 1;
        }

        public void DrawBricks(Graphics e)
        {
            for(int i = 0 ; i < numOfElements; i++)
            {
                if (i > 11 & i < 24 | i > 35 & i < 48 | i > 59 & i < 72 | i > 83 & i < 98)
                {
                    primaryColor.Color = Color.FromName("LightPink");
                }

                else
                {
                    primaryColor.Color = Color.FromName("LightBlue");
                }

                e.FillRectangle(primaryColor, elements[i]);
            }
        }
        public Point CheckForBallCollision(int speedX, int speedY, Rectangle ballRect)
        {
            for(int i = 0; i < numOfElements; i++)
            {
                if(elements[i].IntersectsWith(ballRect))
                {
                    SoundPlayer sp = new SoundPlayer(Lab5WP.Properties.Resources.HitSomething);
                    sp.Play();
                    speedY *= -1;
                    elements.RemoveAt(i);
                    numOfElements--;
                }
            }

            Point startPoint = new Point(speedX, speedY);
            return startPoint;
        }

    }
}
