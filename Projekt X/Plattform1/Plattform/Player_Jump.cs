using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Plattformkod
{
    class Player_Jump : Player
    {
        protected KeyboardState keyboardState;
        protected GameWindow window;
        protected Vector2 speed;
        protected int pY, pX;
        protected bool isOnGround;
        private Vector2 lastFramePosition;
        public Player_Jump(Texture2D tex, Vector2 pos, int sourceRectY, int sourceRectX, Rectangle hitBox, GameWindow window)
            : base(tex, pos, sourceRectY, sourceRectX)
        {
            this.window = window;
            this.speed = new Vector2(0, 0);
            this.screenX = window.ClientBounds.Width;
            this.screenY = window.ClientBounds.Height;

        }
        public override void Update()
        {
            keyboardState = Keyboard.GetState();

            lastFramePosition = position;
            speed.X = 0;
            if (!isOnGround)
            {
                speed.Y += 0.2f;

            }

            if (keyboardState.IsKeyDown(Keys.Right) && (position.X + (texture.Width / 2.0f)) < pX)
            {
                speed.X = 5;

            }

            if (keyboardState.IsKeyDown(Keys.Left) && (position.X - (texture.Width / 2.0f)) > 0)
            {
                speed.X = -5;
            }
            if (keyboardState.IsKeyDown(Keys.Space) && isOnGround)
            {
                isOnGround = false;
                speed.Y = -5;



            }
            position += speed;
            hitbox.X = (int)(position.X >= 100 ? position.X + 0.5f : position.X - 0.5f);
            hitbox.Y = (int)(position.Y >= 0 ? position.Y + 0.5f : position.Y - 0.5f);
            if (hitbox.X + hitbox.Height > pX)
            {
                position.Y = pX - hitbox.Height;
                isOnGround = true;
                speed.Y = 0;
            }
        }
        public void SetPlayerToLastFramePosition()
        {
            position = lastFramePosition;
        }

        public void Fall()
        {
            isOnGround = false;
        }
        public override void HandleCollision(GameObject p)
        {

            if (speed.X > 0 && Hitbox().Right > p.Hitbox().Left && Hitbox().Center.Y > p.Hitbox().Top && Hitbox().Center.X < p.Hitbox().Right) 
            {

                speed.X = -1;

            }
            else if (Hitbox().Left < p.Hitbox().Right && Hitbox().Center.Y > p.Hitbox().Top) 
            {



                speed.X = 1;

                speed.Y = 1;

            }
            else
            {
                isOnGround = true;
                speed.Y = 0;
                base.HandleCollision(p);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, Color.White);

        }

        public int screenHeight { get; set; }

        public int screenWidth { get; set; }

        public int screenX { get; set; }

        public int screenY { get; set; }
    }
}
