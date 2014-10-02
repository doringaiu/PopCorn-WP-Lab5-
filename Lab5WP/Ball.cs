using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Media;

namespace Lab5WP
{
    class Ball
    {
        private int posX, posY, width, height;
        public int xSpeed, ySpeed;
        private Rectangle ballRect;
        private SolidBrush ballColor;
        private SoundPlayer sp = new SoundPlayer(Lab5WP.Properties.Resources.HitSomething);

        public Rectangle GetBallRect
        {
            get { return ballRect; }
        }

        public Ball()
        {
            posX = 495;
            posY = 682;
            width = 15;
            height = 15;
            xSpeed = -2;
            ySpeed = -2;
            ballRect = new Rectangle(posX, posY, width, height);
            ballColor = new SolidBrush(Color.FromName("White"));
        }

        public void setBallSpeeds(int x,int y)
        {
            xSpeed = x;
            ySpeed = y;
        }

        public void drawBall(Graphics e)
        {
            e.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.FillEllipse(ballColor, ballRect);
        }

        public void MoveBall()
        {
            ballRect.X += xSpeed;
            ballRect.Y += ySpeed;
        }

        public void CheckForPWCollision(Rectangle clientRect, Rectangle playerRect)
        {
            if(ballRect.X <= clientRect.X | ballRect.X >= clientRect.X + clientRect.Width - 6)
            {
                xSpeed *= -1;
                sp.Play();
            }
            if(ballRect.Y <= clientRect.Y)
            {
                ySpeed *= -1;
                sp.Play();
            }

            if(playerRect.IntersectsWith(ballRect))
            {   
                sp.Play();
                ySpeed *= -1;
            }
        }
    }
}
