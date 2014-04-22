using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DodgeGame
{
    public partial class Form1 : Form
    {
        List<RainDrop> rainStorm = new List<RainDrop>();
        Random randomRain = new Random();
        Graphics g;
        Player player = new Player();
        RainDrop rainDrop;
        int runningScore;
        int lives = 3;
        int timerCounter = 0;
        bool left;
        bool right;
        
        public Form1()
        {
            InitializeComponent();
            rainDrop = new RainDrop(randomRain);
            rainStorm.Add(rainDrop);
            livesLabel.Text = Convert.ToString(lives);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scoreLabel.Text = Convert.ToString(runningScore);

            if (left)
            {
                    player.moveLeft();
                    left = false;
            }

            if (right)
            {
                    player.moveRight();
                    right = false;
            }

            if (timerCounter % 40 == 0)
            {
                rainDrop = new RainDrop(randomRain);
                rainStorm.Add(rainDrop);
            }

            //move raindrops down here
            foreach(RainDrop r in rainStorm)
            {
                r.falling(timerCounter);
            }
            
            //collision detection here
            collision();

            timerCounter = timerCounter + 1;
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)   
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                spaceBarLabel.Text = "";
                left = false;
                right = false;
            }

            if (e.KeyData == Keys.Left && right == false)
            {
                if (!(player.person.X < 10))
                {
                    left = true;
                    right = false;
                }
            }

            if (e.KeyData == Keys.Right && left == false)
            {
                if (!(player.person.X > 300))
                {
                    right = true;
                    left = false;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            foreach (RainDrop r in rainStorm)
            {
                r.draw(g);
            }
            
            player.drawPerson(g);
        }

        public void collision()
        {
            for(int i = 0; i < rainStorm.Count; i++)
            {
                if (rainStorm[i].rainRec.Y > 290)
                {
                    rainStorm.Remove(rainStorm[i]);
                    rainStorm.Add(new RainDrop(randomRain));
                    runningScore += 10;
                }

                if (player.person.IntersectsWith(rainStorm[i].rainRec))
                {
                    rainStorm.Remove(rainStorm[i]);
                    rainStorm.Add(new RainDrop(randomRain));
                    lives--;
                    livesLabel.Text = Convert.ToString(lives);
                    
                    if (lives == 0)
                    {
                        timer1.Enabled = false;
                        spaceBarLabel.Text = "GAME OVER! Your score was " + runningScore;
                        
                    }
                }
            }
        }
    }
}
