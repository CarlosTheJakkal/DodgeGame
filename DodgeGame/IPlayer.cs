using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame
{
    public interface IPlayer
    {
        void drawPlayer(Graphics g);
        void moveLeft();
        void moveRight();
    }
}
