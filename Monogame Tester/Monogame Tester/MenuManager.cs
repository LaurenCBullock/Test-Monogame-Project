using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Tester
{
    public class MenuManager
    {

        public Game1 game;
        //public gameState state { get { return state; } set { state = value; } }
        Dictionary<String, Button> buttons = new Dictionary<String, Button>();

        public MenuManager(Game1 g)
        {
            game = g;
            InitButtons();
        }

        //Calls methods to make buttons do stuff and things. Also starts up any special functionality a menu may have.
       public void MenuUpdate()
        {
            switch(game.curState)
            {
                case gameState.Menu:
                    buttons["start"].ButtonClicked();
                    buttons["options"].ButtonClicked();
                    buttons["exit"].ButtonClicked();
                    buttons["start"].ButtonHover();
                    buttons["options"].ButtonHover();
                    buttons["exit"].ButtonHover();
                    break;
                case gameState.Options:

                case gameState.Game:
                    break;
                default:
                    break;
            }
        }

        //Draws Menu of the current state.
        public void MenuDraw(SpriteBatch spriteBatch)
        {
            switch(game.curState)
            {
                case gameState.Menu:
                    buttons["start"].DrawButton(spriteBatch);
                    buttons["options"].DrawButton(spriteBatch);
                    buttons["exit"].DrawButton(spriteBatch);
                    break;
                case gameState.Options:
                    break;
                default:
                    break;
            }
        }

        //Initializes le buttons. 
        public void InitButtons()
        {
            //Start
            buttons.Add("start", new Button(new Rectangle(game.GraphicsDevice.Viewport.Width/2-400, 100, 400, 100), game.textures["blankBttn"], gameState.Game, this));
            //Options
            buttons.Add("options", new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 400, 400, 400, 100), game.textures["blankBttn"], gameState.Options, this));
            //Exit
            buttons.Add("exit", new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 400, 250, 400, 100), game.textures["blankBttn"], gameState.Exit, this));
            
        }
    }
}
