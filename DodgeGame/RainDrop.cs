using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DodgeGame
{
    public class RainDrop
    {
        public RainDrop(Random randomRainDrop)
        {
            x = randomRainDrop.Next(0, 345);
            y = 5;
            width = 3;
            height = 3;
            
            pen = new Pen(Color.Aquamarine, 10);
            
            rainRec = new Rectangle(x, y, width, height);
        }

        public void falling(int timerCounter)
        {
            if (timerCounter % 4 == 0)
            {
                rainRec.Y += 10;
            }
        }

        public void draw(Graphics g)
        {
            g.DrawPie(pen, rainRec, 60, 60);
        }

        private Pen pen;
        private int x, y, width, height;
        public Rectangle rainRec;
    
    }
}
