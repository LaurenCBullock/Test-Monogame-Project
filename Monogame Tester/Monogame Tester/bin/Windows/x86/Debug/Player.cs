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
    class Player
    {
        public Game1 game;
        playerState state = playerState.Idle;
        int xMove = 300;
        Rectangle hitbox;

        public int XMove { get { return xMove; } set { xMove = value; } }
        public Rectangle Hitbox { get { return hitbox; } set { hitbox = value; } }
        public playerState State { get { return state; } set { state = value; } }

        public Player(Game1 g)
        {
            game = g;
        }

        public void PlayerDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(game.textures["player"], hitbox = new Rectangle(xMove, 225, 200, 375), Color.White);
        }

        public void PlayerMovement()
        {
            if (Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                state = playerState.Idle;
                //Console.WriteLine("Idle");
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                state = playerState.Kick;
                Console.WriteLine("Kick");
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                state = playerState.WalkLeft;
                xMove -= 5;
                Console.WriteLine("Left");
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                state = playerState.WalkRight;
                xMove += 5;
                Console.WriteLine("Right");
            }
            if(xMove > 600)
            {
                xMove = 600;
            }
            else if (xMove < 0)
            {
                xMove = 0;
            }
        }
    }
}
