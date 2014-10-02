using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Lab5WP
{
    class Player
    {
        private int posX, posY, width, height;
        private Rectangle playerRect;
        private SolidBrush playerColor;

        public Rectangle GetPlayerRect
        {
            get { return playerRect; }
        }

        public Player()
        {
            posX = 455;
            posY = 700;
            width = 100;
            height = 20;

            playerRect = new Rectangle(posX, posY, width, height);
            playerColor = new SolidBrush(Color.FromName("Gold"));
        }

        public void drawPlayer(Graphics e)
        {
            e.FillRectangle(playerColor, playerRect);
        }

        public void movePlayer(int displacement, bool moveLeft)
        {
            if(moveLeft) //left, otherwise right
            {
                displacement *= -1;
            }
            playerRect.X += displacement;
        }
    }
}
