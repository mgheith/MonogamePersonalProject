using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogamePersonalProject.Engine;
using System;

namespace MonogamePersonalProject
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public SpriteBatch SpriteBatch { get { return _spriteBatch; } }
        /* Variables for window rescaling */
        private const int WINDOW_SCALE = 4;
        private RenderTarget2D _newRenderTarget;
        private Rectangle _actualScreenRectangle;
        private GameEngine _gameEngine;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Code for Window rescaling
            _graphics.PreferredBackBufferWidth = 256 * WINDOW_SCALE;
            _graphics.PreferredBackBufferHeight = 240 * WINDOW_SCALE;
            this.IsFixedTimeStep = true;//false;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);
        }

        /// <summary>
        /// Initialize all components required to run the game
        /// </summary>
        protected override void Initialize()
        {
            // code for window rescaling
            _newRenderTarget = new RenderTarget2D(GraphicsDevice, 255, 240);
            _actualScreenRectangle = new Rectangle(0, 0, 255 * WINDOW_SCALE, 240 * WINDOW_SCALE);

            //Set up Global GraphicsDevice for use
            Globals.graphicsDevice = _graphics.GraphicsDevice;

            //Load new GameEngine
            _gameEngine = new GameEngine(this);

            base.Initialize();
        }

        /// <summary>
        /// Add all sprite loading content here
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Game update logic (60 ticks per second)
        /// </summary>
        /// <param name="gameTime">Game time (idk)</param>
        protected override void Update(GameTime gameTime)
        {
            // Game Logic Here
            base.Update(gameTime);
        }

        /// <summary>
        /// Game rendering logic (60 ticks per second)
        /// </summary>
        /// <param name="gameTime">Game time (idk)</param>
        protected override void Draw(GameTime gameTime)
        {
            _gameEngine.Run();

            /* Draw all sprites on a new render target */
            GraphicsDevice.SetRenderTarget(this._newRenderTarget);
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp);
            // Game Drawing Here
            _spriteBatch.End();

            /* Rescale the window and draw sprite batch with new scale */
            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_newRenderTarget, _actualScreenRectangle, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}