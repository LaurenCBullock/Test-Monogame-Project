using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Tester
{
    class Ball
    {
        public Game1 game;
        int xMove = -50;
        int yMove = 450;
        int size = 100;
        double increment = .1;
        Rectangle hitbox;
        bool kicked = false;
        int count = 0;

        public bool Kicked { get { return kicked; } set { kicked = value; } }

        public int XMove { get { return xMove; } set { xMove = value; } }
        public Rectangle Hitbox { get { return hitbox; } set { hitbox = value; } }

        public Ball(Game1 g)
        {
            game = g;
        }

        public void BallDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(game.textures["ball"], hitbox = new Rectangle(xMove, yMove, size, size), Color.White);
        }

        public void BallMovement()
        {
            yMove = 450;
            xMove += 2;
            double conversion = -Math.Abs(Math.Sin(increment) * 20)  ;
            yMove += (int)conversion;
            increment += .1 % 1;
        }

        
        public void BallKick()
        {
            double increment2 = .1;
            double conversion = -Math.Sin(increment2) * 20;
            yMove += (int)conversion;
            increment += .1 % 1;
            if (count == 3)
            {
                size -= 1;
            }
            count += 1;
            count = count % 6;
        }

    }
}
