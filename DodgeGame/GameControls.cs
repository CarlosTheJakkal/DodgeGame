using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DodgeGame
{
    // This class defines the controls for the game, inlcuding lives, score and the left and right keys.
    public class GameControls
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

        public Keys goLeft = DodgeGame.Properties.Settings.Default.LeftKey;
        public Keys goRight = DodgeGame.Properties.Settings.Default.RightKey;
        public int lives = 3;
        public int runningScore;
    }
}
