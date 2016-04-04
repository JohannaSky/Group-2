using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Plattformkod
{
    class Player:GameObjects
    {
        protected KeyboardState ks; 
        Texture2D texture;
        Vector2 position;
        Vector2 speed;
    
        bool isOnGround;

        public Player(Texture2D tex, Vector2 pos, Rectangle hitbox): base(tex, pos, hitbox)
        {
            this.texture = tex;
            this.position = pos;
           
            this.speed = new Vector2(0, 0);
        }
        public void Update()
        {
            ks = Keyboard.GetState();
            speed.X = 0;
            if (!isOnGround)
            {
                speed.Y += 0.2f;

            }

            if (ks.IsKeyDown(Keys.Right) && (position.X + (texture.Width / 2.0f)) < 800)
            {
                speed.X += 5;

            }

            else if (ks.IsKeyDown(Keys.Left) && (position.X - (texture.Width / 2.0f)) > 0)
            {
                speed.X += -5;
            }
            if (ks.IsKeyDown(Keys.Space) && isOnGround)
            {
                isOnGround = false;
                speed.Y = -2;

                Game1.Collision = false;

            }
            position += speed;
            hitBox.X = (int)(pos.X >= 0 ? pos.X + 0.5f : pos.X - 0.5f);
            hitBox.Y = (int)(pos.Y >= 0 ? pos.Y + 0.5f : pos.Y - 0.5f);
            if (hitBox.X + hitBox.Height > 5)
           {
                pos.Y = 5 - hitBox.Height;
                isOnGround = true;
                speed.Y = 0;
           }

        }
        public override void HandleCollision(GameObjects p)
        {

            if (speed.X > 0 && Hitbox().Right > p.Hitbox().Left && Hitbox().Center.Y > p.Hitbox().Top && Hitbox().Center.X < p.Hitbox().Right) //Högerkollision
            {

                speed.X = -1;

            }
            else if (Hitbox().Left < p.Hitbox().Right && Hitbox().Center.Y > p.Hitbox().Top) //Vänsterkollision
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
        //public virtual bool isColliding(GameObjects p)
        //{
        //    return hitBox.Intersects(p.hitBox);
        //}
        //public virtual void HandleCollision(GameObjects other)
        //{
        //    hitBox.Y = other.hitBox.Y - hitBox.Height + 1;
        //    pos.Y = hitBox.Y;
        //}

        //public virtual Rectangle Hitbox()
        //{
        //    return new Rectangle((int)pos.X, (int)pos.Y, 30, 3);
        //}
        public void Fall()
        {
            isOnGround = false;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }


}
