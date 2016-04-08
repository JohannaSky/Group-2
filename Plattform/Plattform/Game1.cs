using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Plattformkod
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D plattformtex;
        Texture2D playertex; 
        string text;
        List<string> strings = new List<string>();
    
        List<GameObjects> ObjectList = new List<GameObjects>();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
  

            base.Initialize();
        }


        protected override void LoadContent()
        {
     
            spriteBatch = new SpriteBatch(GraphicsDevice);
            StreamReader sr = new StreamReader("PlattformMap.txt");
            text = sr.ReadLine();
            strings.Add(text);
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();
            plattformtex = Content.Load<Texture2D>("Enemy");
            playertex = Content.Load<Texture2D>("Player");

     
            Map();
        }

        protected override void UnloadContent()
        {
          
        }
        private void Map()
        {
            for (int i = 0; i < strings.Count; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    if (strings[i][j] == 'x')
                    {

                        Plattform p = new Plattform(plattformtex, new Vector2(j * 30, i * 30), new Rectangle(j * 30, i * 30, 30, 30));
                        ObjectList.Add(p);
                    }

                    if (strings[i][j] == 'P')
                    {
                        Player P = new Player(playertex, new Vector2(j * 30, i * 30), new Rectangle(j * 30, i * 30, 30, 30));
                        ObjectList.Add(P); 
                    }

                }


            }
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            bool Collision = false;
           
            foreach (GameObjects P in ObjectList)
            {

                if (P is Player)
                {

                    foreach (GameObjects other in ObjectList)
                    {
                        if (other is Plattform)
                        {
                            if (P.isColliding(other))
                            {
                                P.HandleCollision(other);
                                Collision = true;
                                
                            }
                        }
                      
                    }
                    (P as Player).Update();

                    if (Collision == false)
                    {
                        (P as Player).Fall();

                    }
                }
             
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (GameObjects o in ObjectList)
            {
                if (o is Plattform)
                    (o as Plattform).Draw(spriteBatch);
                if (o is Player)
                    (o as Player).Draw(spriteBatch);
            }

            
            spriteBatch.End();
    

            base.Draw(gameTime);
        }
    }
}
