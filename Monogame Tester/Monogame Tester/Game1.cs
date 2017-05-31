//Puff! :D

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Monogame_Tester
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public gameState curState;
        //Texture2D bg;

        public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        GameLogic logic;
        public MenuManager menuManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;  // Set Width of Window
            graphics.PreferredBackBufferHeight = 600;   // Set Height of Window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            logic = new GameLogic(this);

            
            curState = gameState.Menu;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textures.Add("bg", Content.Load<Texture2D>("bg"));
            textures.Add("goal", Content.Load<Texture2D>("goal"));
            textures.Add("goalie", Content.Load<Texture2D>("goalie"));
            textures.Add("player", Content.Load<Texture2D>("player"));
            textures.Add("ball", Content.Load<Texture2D>("ball"));
            textures.Add("blankBttn", Content.Load <Texture2D>("start"));

            menuManager = new MenuManager(this);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            menuManager.MenuUpdate();
            switch (curState)
            {
                case gameState.Menu:
                    
                    break;
                case gameState.Game:
                    logic.GameUpdate();
                    break;
                default:
                    break;
            }

            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            menuManager.MenuDraw(spriteBatch);
            switch (curState)
            {
                case gameState.Menu:
                   
                    break;
                case gameState.Game:
                    logic.GameDraw(spriteBatch);
                    break;
                default:
                    break;

            }
            
            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Quit()
        {
            this.Exit();
        }
    }
}
