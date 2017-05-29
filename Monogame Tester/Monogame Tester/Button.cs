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
        Boolean hover;
       
        public Button(Rectangle r, Texture2D t)
        {
            hitbox = r;
            buttonTexture = t;
            hover = false;
        }


        public void ButtonHover()
        {
            Rectangle mouseRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            if(mouseRect.Intersects(hitbox))
            {
                hover = true;
            }
            else
            {
                hover = false;
            }
        }

        public void DrawButton(SpriteBatch spriteBatch)
        {
            if (hover == true)
                spriteBatch.Draw(buttonTexture, hitbox, Color.Aqua);
            else
                spriteBatch.Draw(buttonTexture, hitbox, Color.White);
        }
    }
}
