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
        FallingObjects rainDrop;
        int timerCounter = 0;
        bool left;
        bool right;
        
        public Form1()
        {
            InitializeComponent();
            // First rain drop can only be created here due to the random element.
            rainDrop = new RainDrop(randomX);
            // We add the rain drop to the Fallin Objects List container
            storm.Add(rainDrop);
            // This initializes the players lives to the form
            livesLabel.Text = Convert.ToString(game.lives);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            scoreLabel.Text = Convert.ToString(game.runningScore);
            
            // Here we control the players left movement
            if (left)
            {
                    player.moveLeft();
                    left = false;
            }

            // Here we control the players right movement
            if (right)
            {
                    player.moveRight();
                    right = false;
            }

            // after each 40th tick of the timer, we create a new rain drop and add it to the list.
            if (timerCounter % 40 == 0)
            {
                rainDrop = new RainDrop(randomX);
                storm.Add(rainDrop);
            }

            // on each tick, we move the falling objects down here
            foreach(FallingObjects fo in storm)
            {
                fo.falling(timerCounter);
            }
            
            //the collission function detects any collisions between objects, and then does some appropriate processing
            collision();

            timerCounter = timerCounter + 1;
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)   
        {
            // we start the game by pressing the space bar key. Restartability is also controlled by the space bar key.
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

            // This detects the key pressed and if it is the key for the left movement, it will move the player left.
            // Not being able to go past the edge of the screen is also controlled here.
            if (e.KeyData == game.goLeft && right == false)
            {
                if (!(player.player.X < 10))
                {
                    left = true;
                    right = false;
                }
            }
            
            // This detects the key pressed and if it is the key for the right movement, it will move the player right.
            // Not being able to go past the edge of the screen is also controlled here.
            if (e.KeyData == game.goRight && left == false)
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
            // This function paints the form.
            g = e.Graphics;

            foreach (FallingObjects fo in storm)
            {
                fo.draw(g);
            }
            
            player.drawPlayer(g);
        }

        public void collision()
        {
            // For all of the falling objects in the list, we check for collision.
            
            for(int i = 0; i < storm.Count; i++)
            {
                // First with collision with the bottom of the screen. If the rain drop hits the bottom of the screen
                // score is added, the rain drop is destroyed and a new random rain drop is created.
                if (storm[i].foRec.Y > 290)
                {
                    storm.Remove(storm[i]);
                    storm.Add(new RainDrop(randomX));
                    game.runningScore += 10;
                }

                // Then for collision with the player. If the rain drop hits the player, a life is removed. 
                // If no more lives are left, then the game is over. When a drop hits the player, the drop is also destroyed 
                // and a new rain drop is created in a random place.
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
