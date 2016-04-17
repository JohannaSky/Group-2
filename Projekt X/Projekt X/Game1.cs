using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Projekt_X
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameStateManager gameStateManager;
        MapMenu mapMenu;
        ParallaxScroll parallaxScroll;
        Player player;
        Camera camera;
        
        public static int screenWidth = 1430;
        public static int screenHeight = 1080;
        public static Texture2D map, character, foregroundTex, middlegroundTex, backgroundTex, block;
        public static SpriteFont spriteFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.ApplyChanges();
            
        }

        protected override void Initialize()
        {
          

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = Content.Load<Texture2D>("Karta");
            character = Content.Load<Texture2D>("Karaktär");
            foregroundTex = Content.Load<Texture2D>("fore");
            middlegroundTex = Content.Load<Texture2D>("middle");
            backgroundTex = Content.Load<Texture2D>("back");
            block = Content.Load<Texture2D>("block");

            spriteFont = Content.Load<SpriteFont>("font");
            IsMouseVisible = true;
            player = new Player(Content, Window);
            mapMenu = new MapMenu();
            gameStateManager = new GameStateManager(Content, graphics);
            parallaxScroll = new ParallaxScroll(Content, Window);
            camera = new Camera(player, new Rectangle(0,0,1430, 1080), new Rectangle(0 ,0, 50000, 3000));
        }


        protected override void UnloadContent()
        {
           
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            //mapMenu.MapMenuMovement();
            //gameStateManager.Update();
            player.Update();
            camera.Update();
            /*#region paralax
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Game1.cameraX += 2;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Game1.cameraX -= 2;
            }
            // TODO: Add your update logic here
            parallaxScroll.Update();
            #endregion*/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.TranslationMatrix);
            //mapMenu.Draw(spriteBatch);
            //gameStateManager.Draw(spriteBatch);
            //parallaxScroll.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
    
            base.Draw(gameTime);
        }
        

    }
}
