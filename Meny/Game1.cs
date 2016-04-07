using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hobby_projekt
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameStateManager gameStateManager;

        public static int screenWidth;
        public static int screenHeight;

        public static Texture2D texture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            graphics.IsFullScreen = true;
            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            IsMouseVisible = true;
            texture = Content.Load<Texture2D>("images");


            gameStateManager = new GameStateManager(Content);
        }
        
        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || gameStateManager.gamestate == GameStateManager.GameState.exit)
                Exit();

            gameStateManager.Update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gameStateManager.Draw(spriteBatch);

            base.Draw(gameTime);
            spriteBatch.End();
            
        }
    }
}
