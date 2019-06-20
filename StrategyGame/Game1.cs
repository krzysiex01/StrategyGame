using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Player player1;
        public Player player2;
        private UserInterface userInterface;
        private TexturePack texturePack;
        private FontPack fontPack;
        public int Size { get; set; }
        public int Fps { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Size = 1000;
            Content.RootDirectory = "Content";
            //IsFixedTimeStep = true;
            IsFixedTimeStep = false;
            graphics.PreferredBackBufferWidth = 1000;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 480;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            //TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0/Fps);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player1 = new Player(Size,1);
            player2 = new Player(Size,2);
            texturePack = new TexturePack(this);
            fontPack = new FontPack(this);
            userInterface = new UserInterface(player1,player2,texturePack,fontPack);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
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

            GameEventEngine.Update(gameTime);

            //Interface class update
            userInterface.Update(gameTime);

            //Player update logic
            player1.Update(player2,gameTime);
            player2.Update(player1,gameTime);
            player1.DestroyNoHp();
            player2.DestroyNoHp();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Drawing code
            
            //some temporary background
            spriteBatch.Begin();
            spriteBatch.Draw(texturePack.background, new Rectangle(0,0,1000,480),Color.White);
            spriteBatch.End();

            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            userInterface.Draw(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
