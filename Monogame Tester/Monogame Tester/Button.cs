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
        gameState state;
        Boolean hover;
       
        //Button controlling gameState
        public Button(Rectangle r, Texture2D t, gameState s, MenuManager m)
        {
            hitbox = r;
            buttonTexture = t;
            state = s;
            manager = m;
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
                hover = true;
            else
                hover = false;
        }

        //Determins if the mouse was clicked over a hovered button
        public void ButtonClicked()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Pressed && hover == true)
            {
                manager.game.curState = state;
            }
        }
    }
}
