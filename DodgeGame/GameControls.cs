using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DodgeGame
{
    class GameControls
    {
        public GameControls()
        {

        }

        public void resetScore()
        {
            runningScore = 0;
            return;
        }

        public void resetLives()
        {
            lives = 3;
            return;
        }

        Keys goLeft = DodgeGame.Properties.Settings.Default.LeftKey;
        Keys goRight = DodgeGame.Properties.Settings.Default.RightKey;
        public int lives = 3;
        public int runningScore;
    }
}
