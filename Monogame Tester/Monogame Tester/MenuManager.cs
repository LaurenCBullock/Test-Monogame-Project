using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        public controlMode control;

        KeyboardState curKeyState;
        KeyboardState prevKeyState;
        public MouseState curMouseState;
        public MouseState prevMouseState;
        public int buttonCount = -1;
        public int hoverIndex = -1;
        //public gameState state { get { return state; } set { state = value; } }
        List<Button> buttons = new List<Button>();

        public MenuManager(Game1 g)
        {
            game = g;
            InitButtons();
            control = controlMode.Mouse;

        }

        //Calls methods to make buttons do stuff and things. Also starts up any special functionality a menu may have.
       public void MenuUpdate()
        {
            curKeyState = Keyboard.GetState();
            if (CheckKeyboard(Keys.Down))
            {
                control = controlMode.Keyboard;
                if (hoverIndex < buttons.Count - 1)
                    hoverIndex++;
                else
                    hoverIndex = 0;
            }
            else if (CheckKeyboard(Keys.Up))
            {
                control = controlMode.Keyboard;
                if (hoverIndex <= 0)
                    hoverIndex = buttons.Count - 1;
                else
                    hoverIndex--;
            }
            prevKeyState = curKeyState;
            if (hoverIndex != -1)
            {
                foreach (Button b in buttons)
                {
                    if (b.Equals(buttons[hoverIndex]))
                        b.hover = true;
                    else
                        b.hover = false;
                }
            }

            //Switch to cycle control between buttons of current game state.
            switch (game.curState)
            {
                case gameState.Menu:
                    for(int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].ButtonClicked();
                        buttons[i].ButtonHover();
                    }
                    break;
                case gameState.Options:
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].ButtonClicked();
                        buttons[i].ButtonHover();
                    }
                    break;
                case gameState.PauseMenu:
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].ButtonClicked();
                        buttons[i].ButtonHover();
                    }
                    break;
                case gameState.Game:
                    break;
                case gameState.KickMenu:
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
                    foreach(Button b in buttons)
                    {
                        b.DrawButton(spriteBatch);
                    }
                    break;
                case gameState.Options:
                    foreach (Button b in buttons)
                    {
                        b.DrawButton(spriteBatch);
                    }
                    break;
                case gameState.PauseMenu:
                    foreach (Button b in buttons)
                    {
                        b.DrawButton(spriteBatch);
                    }
                    break;
                default:
                    break;
            }
        }

        //Initializes le buttons. 
        public void InitButtons()
        {
            Console.WriteLine("InitButtons called");
            switch (game.curState)
            {
                case gameState.Menu:
                    //Start
                    buttons.Clear();
                    Console.WriteLine("Menu init");
                    buttonCount = -1;
                    hoverIndex = -1;
                    buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 200, 100, 400, 100), game.textures["blankBttn"], gameState.Game, this));
                    //Options
                   buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 200, 250, 400, 100), game.textures["blankBttn"], gameState.Options, this));
                    //Exit
                    buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 200, 400, 400, 100), game.textures["blankBttn"], gameState.Exit, this));
                    hoverIndex = -1;
                    break;
                case gameState.Options:
                    Console.WriteLine("Options init");
                    buttons.Clear();
                    buttonCount = -1;
                    hoverIndex = -1;
                    //Controls
                    buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 200, 100, 400, 100), game.textures["blankBttn"], gameState.Controls, this));
                    //Back
                    buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 200, 250, 400, 100), game.textures["blankBttn"], gameState.Menu, this));
                    break;
                case gameState.PauseMenu:
                    Console.WriteLine("Pause Menu init");
                    buttons.Clear();
                    buttonCount = -1;
                    hoverIndex = -1;
                    buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 200, 100, 400, 100), game.textures["blankBttn"], gameState.Options, this));
                    //Back
                    buttons.Add(new Button(new Rectangle(game.GraphicsDevice.Viewport.Width / 2 - 200, 250, 400, 100), game.textures["blankBttn"], gameState.Game, this));
                    break;
                default:
                    Console.WriteLine(game.curState);
                    break;
            }
        }

        public bool CheckKeyboard(Keys key)
        {
            return (curKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key));
        }
    }
}
