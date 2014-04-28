using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeGame
{
    interface IFallingObjects
    {
        void falling(int timerCounter);
        void draw(Graphics g);
    }
}
