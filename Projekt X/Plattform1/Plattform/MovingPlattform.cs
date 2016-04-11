using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Plattformkod
{
    class MovingPlattform : Plattform
    {

        private float direction = -0.8f;

        public MovingPlattform(Texture2D texture, Vector2 position, int sourceRectX, int sourceRectY)
            : base(texture, position, sourceRectX, sourceRectY)
        {
        }

        public void Update(GameTime gameTime)
        {
            position.X += direction;
        }

     
        public void CollidePlatform(Plattform plattform)
        {
            if (Hitbox().Intersects(plattform.Hitbox()))
            {
               
                direction *= -1;
              
            }
        }

        public override Rectangle Hitbox()
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            return hitbox;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y), sourceRectangle, Color.White);
         
        }
    }
}
