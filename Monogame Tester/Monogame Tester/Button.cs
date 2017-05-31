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
    class Button
    {
        Rectangle hitbox;
        Texture2D buttonTexture;
        MenuManager manager;
        int myIndex;
        gameState state;
        public Boolean hover;
       
        //Button controlling gameState
        public Button(Rectangle r, Texture2D t, gameState s, MenuManager m)
        {
            hitbox = r;
            buttonTexture = t;
            state = s;
            manager = m;
            myIndex = manager.buttonCount++;
            hover = false;
        }

        //Button that does not control a game state. Duhhhhh
        public Button(Rectangle r, Texture2D t, MenuManager m)
        {
            hitbox = r;
            buttonTexture = t;
            manager = m;
            hover = false;
        }

        //Draws le Button
        public void DrawButton(SpriteBatch spriteBatch)
        {
            if (hover == true)
                spriteBatch.Draw(buttonTexture, hitbox, Color.Aqua);
            else
                spriteBatch.Draw(buttonTexture, hitbox, Color.White);
        }

        //Determines if mouse is hovering over a button
        public void ButtonHover()
        {
            Rectangle mouseRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            if (mouseRect.Intersects(hitbox))
            {
                manager.control = controlMode.Mouse;
                hover = true;
                manager.hoverIndex = myIndex;
            }
            else if (manager.control == controlMode.Mouse)
            {
                hover = false;
            }
        }

        //Determins if the mouse was clicked over a hovered button
        public void ButtonClicked()
        {
            Rectangle mouseRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);

            if (manager.control == controlMode.Mouse)
            {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseRect.Intersects(hitbox))
                    {
                        Console.WriteLine("Test1");
                        manager.game.curState = state;
                        manager.InitButtons();
                    }
            }
            else if(manager.control == controlMode.Keyboard)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && hover == true)
                {
                    Console.WriteLine("Test2");
                    manager.game.curState = state;
                    manager.InitButtons();
                }
            }
            
        }
    }
}
