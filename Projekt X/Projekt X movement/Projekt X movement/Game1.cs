using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projekt_X_movement
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static Texture2D character;
        Player player;
        Plattform[] plattforms;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
        }

   
        protected override void Initialize()
        {
      

            base.Initialize();
        }


        protected override void LoadContent()
        {
    
            spriteBatch = new SpriteBatch(GraphicsDevice);
            character = Content.Load<Texture2D>("karaktär");
            plattforms = new Plattform[2];
            plattforms[0] = new Plattform(3, character, 150, 300);
            plattforms[1] = new Plattform(3, character, 100, 100);


            player = new Player(character, plattforms);
        }


        protected override void UnloadContent()
        {
  
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            player.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            player.Draw(spriteBatch);
            for (int i = 0; i < 2; i++)
            {
                plattforms[i].Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
