using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DodgeGame
{
    public class RainDrop : FallingObjects
    {
        public RainDrop(Random randomRainDrop)
        {
            x = randomRainDrop.Next(0, 345);
            y = 5;
            width = 3;
            height = 3;
            
            pen = new Pen(Color.Aquamarine, 10);
            
            foRec = new Rectangle(x, y, width, height);
        }

        public override void falling(int timerCounter)
        {
            if (timerCounter % 4 == 0)
            {
                foRec.Y += 10;
            }
        }

        public override void draw(Graphics g)
        {
            g.DrawPie(pen, foRec, 60, 60);
        }
    }
}
