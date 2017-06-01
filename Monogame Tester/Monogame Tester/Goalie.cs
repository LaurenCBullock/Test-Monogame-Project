using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Tester
{
    class Goalie
    {
        public Game1 game;
        public Ball ball;
        Rectangle hitbox;
        int xMove = 337;
        int yMove = 150;
        GoalieState prevState;
        GoalieState curstate = GoalieState.WalkRight;

        public Rectangle Hitbox { get { return hitbox; } set { hitbox = value; } }
        public GoalieState Curstate { get { return curstate; } set { curstate = value; } }
        public GoalieState PrevState { get { return prevState; } set { prevState = value; } }
        public int XMove { get { return xMove; } set { xMove = value; } }

        public Goalie(Game1 g, Ball b)
        {
            game = g;
            ball = b;
        }

        public void GoalieDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(game.textures["goalie"], hitbox = new Rectangle(xMove, yMove, 125, 250), Color.White);
        }

        public void GoalieUpdate()
        {
            //Console.WriteLine(xMove);
            if(curstate == GoalieState.WalkRight && xMove <= 725 - 125)
            {
                xMove += 2;
            }
            else if (curstate == GoalieState.WalkRight && xMove > 725 -125)
            {
                curstate = GoalieState.WalkLeft;
            }
            else if (curstate == GoalieState.WalkLeft && xMove >= 75)
            {
                xMove -= 2;
            }
            else if (curstate == GoalieState.WalkLeft && xMove < 75)
            {
                curstate = GoalieState.WalkRight;
            }
            else if ( curstate == GoalieState.ChaseBallLeft || curstate == GoalieState.ChaseBallRight)
            {
                ChaseBall();
            }

        }

        public void ChaseBall()
        {
            int movement = 0;
            if (curstate == GoalieState.ChaseBallRight)
            {
                movement = (xMove - ball.XMove) * 6 / Math.Abs(xMove - ball.XMove);
                xMove -= Math.Abs(movement);
                if (XMove < 75)
                {
                    xMove = 75;
                }
            }
            else if(curstate == GoalieState.ChaseBallLeft)
            {
                movement = (hitbox.X - ball.Hitbox.X) * 6 / (hitbox.X - ball.Hitbox.X);
                xMove += Math.Abs(movement);
                if (XMove > 725 - 125)
                {
                    xMove = 725 - 125;
                }

            }
            Console.WriteLine(movement);
            //int movement = (hitbox.X - ball.Hitbox.X) * 6 / (hitbox.X - ball.Hitbox.X);
            //xMove += movement;
        }
    }
}
