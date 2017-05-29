using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Tester
{
    class Goal
    {
        Rectangle hitbox = new Rectangle(75, 50 , 650, 350);
        public Game1 game;

        public Goal(Game1 g)
        {
            game = g;
        }

        public void GoalDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(game.textures["goal"], hitbox, Color.White);
        }

    }
}
