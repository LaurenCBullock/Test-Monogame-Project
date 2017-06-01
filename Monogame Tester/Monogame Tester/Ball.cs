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

        //physics
        float positionX, positionY;     // Position of the character
        //float velocityX, velocityY;
        float velocityY = -20;
        float gravity = .5f;

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
            xMove += 4;
            double conversion = -Math.Abs(Math.Sin(increment) * 20)  ;
            yMove += (int)conversion;
            increment += .1 % 1;
        }

        
        public void BallKick(float time)
        {
            velocityY += (gravity * time/10);
            //velocityY += gravity * time;        // Apply gravity to vertical velocity
            //positionX += velocityX * time;      // Apply horizontal velocity to X position
            yMove += (int)(velocityY * time/10);      // Apply vertical velocity to X position
            if (count == 1)
            {
                size -= 1;
            }
            count += 1;
            count = count % 2;
        }

    }
}
