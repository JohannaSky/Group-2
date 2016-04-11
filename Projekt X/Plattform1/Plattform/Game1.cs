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
       
        Texture2D plattformTex;
        Texture2D playerTex;
        
        string text;
        KeyboardState keyboardState;
       
        List<string> strings = new List<string>();
        List<GameObject> ObjectList = new List<GameObject>();

        MovingPlattform movingPlattform;

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
            int screenWidth = 800;
            int screenHeight = 1200;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            MapReader();
         
            playerTex = Content.Load<Texture2D>("Player");
            plattformTex = Content.Load<Texture2D>("enemy");
     
            Map();   
        }

        public void MapReader()
        {
            StreamReader sr = new StreamReader("PlattFormMap.txt");
            text = sr.ReadLine();
            strings.Add(text);
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }

            sr.Close();
        }


        private void Map()
        {
            for (int i = 0; i < strings.Count; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                    
                {
                    if (strings[i][j] == 'P')
                    {
                        
                        Player player = new Player_Jump(playerTex, new Vector2(j * 30, i * 30), 0, 0, new Rectangle(j * 30, i * 30, 30, 30), Window);
                        ObjectList.Add(player);
                    }

                    if (strings[i][j] == 'x')
                    {
                        Plattform plattform = new Plattform(plattformTex, new Vector2(j * 30, i * 30), 0, 0);
                        ObjectList.Add(plattform);
                    }

                    if (strings[i][j] == 'm')
                    {
                        movingPlattform = new MovingPlattform(playerTex, new Vector2(j * 30, i * 30), 0, 0);
                        ObjectList.Add(movingPlattform);
                    }
                }
            }
        }
        
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            movingPlattform.Update(gameTime);
             keyboardState = Keyboard.GetState();
  
               bool Collision = false;

               foreach (GameObject gameObject in ObjectList)
               {
                 
                   if (gameObject is Player)
                   {
                       
                       foreach (GameObject other in ObjectList)
                       {
                           if (other is Plattform)
                           {
                               if (gameObject.isColliding(other))
                               {
                                   gameObject.HandleCollision(other);
                                   Collision = true;

                               }
                           }
                       }
                     
                       if(gameObject is Player)
                           foreach (GameObject plattform in ObjectList)
                           {
                               if (plattform is Plattform)
                               {
                                   if (gameObject.Hitbox().Intersects(plattform.Hitbox()))
                                   {
                                       ((Player_Jump)gameObject).SetPlayerToLastFramePosition();

                                   }
                               }
                           }

                       (gameObject as Player).Update();
                       if (Collision == false)
                       {
                           (gameObject as Player_Jump).Fall();
                            
                       }
                   }

                   foreach (GameObject gameObj in ObjectList)
                   {
                       if (gameObj is MovingPlattform)
                       {
                           foreach (GameObject gObject in ObjectList)
                           {
                               if (gObject is Plattform && gameObj != gObject)
                               {
                                   (gameObj as MovingPlattform).CollidePlatform((gObject as Plattform));
                               }
                           }
                       }
                   }
               }

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();
            base.Update(gameTime);
           

        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
                     foreach (GameObject o in ObjectList)
                     {
                         o.Draw(spriteBatch); 
                     }
            spriteBatch.End(); 
  
            base.Draw(gameTime);
        }
    }
}

   



