using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Lab5WP
{
    public partial class Form1 : Form
    {
        Graphics paper;
        Player player = new Player();
        Ball ball = new Ball();
        Bricks bricks = new Bricks(12,8);
        SoundPlayer sp2 = new SoundPlayer(Lab5WP.Properties.Resources.Death);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            player.drawPlayer(paper);
            ball.drawBall(paper);
            bricks.DrawBricks(paper);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {     
                case Keys.Left:
                    if(player.GetPlayerRect.X > 0)
                    {
                        player.movePlayer(10, true);
                    }
                    break;
                case Keys.Right:
                     if(player.GetPlayerRect.X < this.ClientRectangle.Width - player.GetPlayerRect.Width)
                    {
                        player.movePlayer(10, false);
                    };
                    break;
                case Keys.Space:
                    timer1.Enabled = true;
                    break;
            }

            this.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.CheckForPWCollision(this.ClientRectangle,player.GetPlayerRect);
            ball.MoveBall();
            Point speeds = new Point();
            speeds = bricks.CheckForBallCollision(ball.xSpeed, ball.ySpeed, ball.GetBallRect);
            ball.setBallSpeeds(speeds.X, speeds.Y);

            if(ball.GetBallRect.Y >= this.ClientRectangle.Height)
            {
                sp2.Play();
                timer1.Enabled = false;
                MessageBox.Show(":( :( :( :(", "game over", MessageBoxButtons.OK);
            }
            this.Invalidate();
        }
    }
}
