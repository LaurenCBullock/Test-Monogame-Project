using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Tester
{

    public enum gameState
    {
        Menu,
        Game,
        GameOver,
        Options,
        Controls,
        Exit
    }

    public enum controlMode
    {
        Mouse,
        Keyboard
    }

    enum buttonState
    {
        Hover,
        Up,
        Down
    }

    enum playerState
    {
        Idle,
        WalkLeft,
        WalkRight,
        Kick
    }

    class Globals
    {
    }
}
