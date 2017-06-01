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
    class GameLogic
    {
        public Game1 game;
        Player player;
        Goal goal;
        List<Ball> ball;
        Goalie goalie;

        public GameLogic(Game1 g)
        {
            game = g;
            goal = new Goal(g);
            ball = new List<Ball>();
            for (int i = 0; i < 10; i++)
            {
                ball.Add(new Ball(g));
            }
            player = new Player(game);
            goalie = new Goalie(game, ball[0]);
        }
        
        public void GameDraw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(game.textures["bg"], new Rectangle( 0,0,800,600),Color.White);
            goal.GoalDraw(spritebatch);
            goalie.GoalieDraw(spritebatch);
            if (ball.Count > 0)
            {
                ball[0].BallDraw(spritebatch);
            }
            player.PlayerDraw(spritebatch);
            //spritebatch.DrawString(game.Tahoma, "" + player.Points, new Vector2(0,0), Color.White);
            
        }

        public void GameUpdate(double time)
        {
            
            player.PlayerMovement();
            goalie.GoalieUpdate();
            if (ball.Count > 0)
            {
                if (player.Hitbox.Intersects(ball[0].Hitbox) && player.State == playerState.Kick)
                {
                    if (ball[0].Kicked == false)
                    {
                        ball[0].Kicked = true;
                        goalie.PrevState = goalie.Curstate;
                        if (goalie.XMove > ball[0].XMove)
                        {
                            goalie.Curstate = GoalieState.ChaseBallRight;
                        }
                        else if (ball[0].XMove > goalie.XMove)
                        {
                            goalie.Curstate = GoalieState.ChaseBallLeft;
                        }
                    }

                }
                if (ball[0].Kicked == true)
                {

                    ball[0].BallKick((float)time);
                }
                else
                {
                    ball[0].BallMovement();
                }
                if (ball[0].Hitbox.Size.X == 80 && ball[0].Hitbox.Intersects(goal.Hitbox))
                {
                    if (ball[0].Hitbox.Intersects(goalie.Hitbox))
                    {
                        //Console.WriteLine("Lose");
                        ball.Remove(ball[0]);
                        goalie.Curstate = goalie.PrevState;
                    }
                    else
                    {
                       // Console.WriteLine("Win");
                        player.Points += 20;
                        ball.Remove(ball[0]);
                        goalie.Curstate = goalie.PrevState;
                    }
                    

                }
                else if (ball[0].Hitbox.Size.X == 80 || ball[0].Hitbox.X > 800)
                {
                    //Console.WriteLine("Lose");
                    ball.Remove(ball[0]);
                    goalie.Curstate = goalie.PrevState;
                }
            }
            
        }

        
    }
}
