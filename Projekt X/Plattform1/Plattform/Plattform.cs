using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Plattformkod
{
    class Plattform : GameObject
    {

        public Plattform(Texture2D texture, Vector2 pos, int SourceRectX, int SourceRectY) : base(texture, pos)
        {
            this.position = pos;
            sourceRectangle = new Rectangle(SourceRectX, SourceRectY, 30, 30);
            
            
        }

        public override Rectangle Hitbox()
        {
            return hitbox = base.Hitbox();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
           
        }

    }
}
