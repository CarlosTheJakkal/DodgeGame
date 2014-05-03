using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DodgeGame
{
    // Abstract FallingObjects class that implements the interface IFallingObjects
    public abstract class FallingObjects : IFallingObjects
    {
        public abstract void falling(int timerCounter);
        public abstract void draw(Graphics g);

        public Pen pen;
        public int x, y, width, height;
        public Rectangle foRec; 
    }
}
