using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DodgeGame
{
    public class Player
    {

        public Player()
        {
            x = 150;
            y = 225;
            width = 25;
            height = 125;

            person = new Rectangle(x, y, width, height);
            brush = new SolidBrush(Color.Chocolate);
        }

        public void drawPerson(Graphics g)
        {
            g.FillRectangle(brush, person);
        }

        public void drawPerson()
        {
           // person.X 
        }

        public void moveLeft()
        {
            drawPerson();
            person.X -= 10;
        }

        public void moveRight()
        {
            drawPerson();
            person.X += 10;
        }
        
        public Rectangle person;
        private SolidBrush brush;
        private int x, y, width, height;
    }
}
