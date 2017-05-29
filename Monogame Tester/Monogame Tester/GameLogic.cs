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
        Ball ball;

        public GameLogic(Game1 g)
        {
            game = g;
            ball = new Ball(g);
            player = new Player(game);
        }
        
        public void GameDraw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(game.textures["bg"], new Rectangle( 0,0,800,600),Color.White);
            ball.BallDraw(spritebatch);
            player.PlayerDraw(spritebatch);
            
        }

        public void GameUpdate()
        {
            
            player.PlayerMovement();
            if (player.Hitbox.Intersects(ball.Hitbox) && player.State == playerState.Kick)
            {
                ball.Kicked = true;
            }
            if (ball.Kicked == true)
            {
                ball.BallKick(game.gametime);
            }
            else
            {
                ball.BallMovement();
            }
        }

        
    }
}
