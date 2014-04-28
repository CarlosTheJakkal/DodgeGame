using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DodgeGame
{
    public abstract class Player : IPlayer
    {
        public abstract void drawPlayer(Graphics g);
        public abstract void moveLeft();
        public abstract void moveRight();
        
        public Rectangle player;
        public SolidBrush brush;
        public int x, y, width, height;
    }
}
