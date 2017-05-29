using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Tester
{
    class MenuManager
    {

        public Game1 game;
        List<Button> buttons = new List<Button>();

        MenuManager(Game1 g)
        {
            game = g;
        }


        public void MenuUpdate()
        {

        }

        public void MenuDraw(SpriteBatch spriteBatch)
        {
            //foreach(buttons)
        }


        public void InitButtons()
        {
            //Start
            buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width/2-400, 100, 400, 100), game.textures["start"]));
            //Exit
            buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 400, 250, 400, 100), game.textures["start"]));
            //Options
            buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 400, 400, 400, 100), game.textures["start"]));
        }
    }
}
