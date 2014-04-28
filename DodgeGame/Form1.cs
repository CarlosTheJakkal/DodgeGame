using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

namespace DodgeGame
{
    public partial class Form1 : Form
    {
        GameControls game = new GameControls();
        List<FallingObjects> storm = new List<FallingObjects>();
        Random randomX = new Random();
        Graphics g;
        Player player = new Person();
        RainDrop rainDrop;
        int timerCounter = 0;
        bool left;
        bool right;
        
        public Form1()
        {
            InitializeComponent();
            rainDrop = new RainDrop(randomX);
            storm.Add(rainDrop);
            livesLabel.Text = Convert.ToString(game.lives);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scoreLabel.Text = Convert.ToString(game.runningScore);
            
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
                rainDrop = new RainDrop(randomX);
                storm.Add(rainDrop);
            }

            //move raindrops down here
            foreach(FallingObjects fo in storm)
            {
                fo.falling(timerCounter);
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

                if (game.lives == 0)
                {
                    game.resetScore();
                    game.resetLives();
                    livesLabel.Text = Convert.ToString(game.lives);
                    storm.Clear();
                }
            }

            if (e.KeyData == DodgeGame.Properties.Settings.Default.LeftKey && right == false)
            {
                if (!(player.player.X < 10))
                {
                    left = true;
                    right = false;
                }
            }

            if (e.KeyData == DodgeGame.Properties.Settings.Default.RightKey && left == false)
            {
                if (!(player.player.X > 300))
                {
                    right = true;
                    left = false;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            foreach (FallingObjects fo in storm)
            {
                fo.draw(g);
            }
            
            player.drawPlayer(g);
        }

        public void collision()
        {
            for(int i = 0; i < storm.Count; i++)
            {
                if (storm[i].foRec.Y > 290)
                {
                    storm.Remove(storm[i]);
                    storm.Add(new RainDrop(randomX));
                    game.runningScore += 10;
                }

                if (player.player.IntersectsWith(storm[i].foRec))
                {
                    storm.Remove(storm[i]);
                    storm.Add(new RainDrop(randomX));
                    game.lives--;
                    livesLabel.Text = Convert.ToString(game.lives);
                    
                    if (game.lives == 0)
                    {
                        timer1.Enabled = false;
                        spaceBarLabel.Text = "GAME OVER! Your score was " + game.runningScore;
                        
                    }
                }
            }
        }       
    }
}
