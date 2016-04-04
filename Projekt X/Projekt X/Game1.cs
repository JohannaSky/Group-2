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
        Texture2D map, character;
        KeyboardState button;
        Vector2 pos;
        Rectangle[] hitBoxes;
        Rectangle charHitBox;
        bool collide;
        Vector2 lastPos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1430;
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
            pos = new Vector2(850, 550);
            BuildWalls();
            charHitBox = new Rectangle((int)pos.X, (int)pos.Y, character.Width, character.Height);
            collide = false;
            
        }


        protected override void UnloadContent()
        {
           
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            CharacterMove();

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(map, Vector2.Zero, Color.White);
            spriteBatch.Draw(character, pos, Color.White);
            spriteBatch.End();
    
            base.Draw(gameTime);
        }
        public void BuildWalls()
        {
            hitBoxes = new Rectangle[27];
            hitBoxes[0] = new Rectangle(0, 0, 190, 130);
            hitBoxes[1] = new Rectangle(76, 127, 44, 53);
            hitBoxes[2] = new Rectangle(0, 127, 25, 260);
            hitBoxes[3] = new Rectangle(0, 370, 382, 18);
            hitBoxes[4] = new Rectangle(440, 370, 503, 18);
            hitBoxes[5] = new Rectangle(925, 328, 18, 42);
            hitBoxes[6] = new Rectangle(925, 137, 18, 130);
            hitBoxes[7] = new Rectangle(925, 137, 475, 53);
            hitBoxes[8] = new Rectangle(1345, 190, 55, 355);
            hitBoxes[9] = new Rectangle(1382, 545, 18, 500);
            hitBoxes[10] = new Rectangle(113, 1027, 1269, 18);
            hitBoxes[11] = new Rectangle(111, 388, 18, 639);
            hitBoxes[12] = new Rectangle(0, 0, 1390, 25);
            hitBoxes[13] = new Rectangle(1380, 15, 20, 122);
            hitBoxes[14] = new Rectangle(1061, 533, 322, 12);
            hitBoxes[15] = new Rectangle(1061, 533, 82, 135);
            hitBoxes[16] = new Rectangle(1061, 730, 12, 296);
            hitBoxes[17] = new Rectangle(1074, 994, 308, 36);
            hitBoxes[18] = new Rectangle(130, 782, 427, 244);
            hitBoxes[19] = new Rectangle(330, 449, 13, 332);
            hitBoxes[20] = new Rectangle(1090, 259, 151, 211);
            hitBoxes[21] = new Rectangle(1296, 550, 84, 137);
            hitBoxes[22] = new Rectangle(133, 597, 91, 84);
            hitBoxes[23] = new Rectangle(347, 727, 197, 54);
            hitBoxes[24] = new Rectangle(359, 488, 326, 89);
            hitBoxes[25] = new Rectangle(594, 577, 91, 92);
            hitBoxes[26] = new Rectangle(369, 609, 188, 62);

        }
        public void CharacterMove()
        {
            button = Keyboard.GetState();
            charHitBox = new Rectangle((int)pos.X, (int)pos.Y, character.Width, character.Height);
            collide = false;

            for (int i = 0; i < hitBoxes.Length; i++)
            {
                if (hitBoxes[i].Intersects(charHitBox))
                {
                    collide = true;
                    pos = lastPos;
                }
            }
            if (collide == false)
            {
                lastPos = pos;
            }
            if (button.IsKeyDown(Keys.Up) && collide == false)
            {
                pos.Y -= 2;
            }
            if (button.IsKeyDown(Keys.Down) && collide == false)
            {
                pos.Y += 2;
            }
            if (button.IsKeyDown(Keys.Right) && collide == false)
            {
                pos.X += 2;
            }
            if (button.IsKeyDown(Keys.Left) && collide == false)
            {
                pos.X -= 2;
            }
        }
    }
}
