using System.Collections.Generic;
using DataLibrary;
using DoudouLaCrapule.Sources;
using DoudouLaCrapule.Sources.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoudouLaCrapule
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player turtle;
        Sprite[] map;

        private RenderTarget2D nativeRT;
        private Rectangle nativeRectangle;
        private Rectangle screenRectangle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            nativeRectangle = new Rectangle(0, 0, 160, 144);
            screenRectangle = new Rectangle(0, 0, nativeRectangle.Width * 4, nativeRectangle.Height * 4);
            
            graphics.PreferredBackBufferWidth = screenRectangle.Width;
            graphics.PreferredBackBufferHeight = screenRectangle.Height;
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
            nativeRT = new RenderTarget2D(GraphicsDevice, 160, 144);

            var turtleAnimation = Content.Load<Animations>("turtleAnimation");
            var turtleAnimatedSprite = new AnimatedSprite(
                Content.Load<Texture2D>(turtleAnimation.AnimationsTexturePath), 
                new Point(32, 32), 
                new Point(turtleAnimation.FrameWidth, turtleAnimation.FrameHeight), 
                turtleAnimation, 
                Color.White);

            turtle = new Player(turtleAnimatedSprite);

            Map testMap = Content.Load<Map>("map01");

            Texture2D mapTexture = Content.Load<Texture2D>(testMap.TilesetPath);
            
            var tmpMap = new List<Sprite>();
            foreach(var tile in testMap.Tiles)
            {
                tmpMap.Add(
                    new Sources.Tile(
                        mapTexture,
                        new Point(tile.PositionX * testMap.TileWidth, tile.PositionY * testMap.TileHeight),
                        new Point(testMap.TileWidth, testMap.TileHeight),
                        new Rectangle(
                            new Point((tile.TileIndex % testMap.TilesetColumns) * testMap.TileWidth, (tile.TileIndex / testMap.TilesetColumns) * testMap.TileHeight),
                            new Point(testMap.TileWidth, testMap.TileHeight)),
                        Color.White)
                );
            }
            map = tmpMap.ToArray();

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

            turtle.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(nativeRT);
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            foreach (var tile in map)
            {
                tile.Draw(spriteBatch);
            }
            turtle.Draw(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            // RenderTarget2D inherits from Texture2D so we can render it just like a texture
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(nativeRT, screenRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
