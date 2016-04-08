using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Plattformkod
{
    class Plattform : GameObjects
    {
        Texture2D texture;
        Rectangle hitbox;
        Vector2 position; 

        public Plattform(Texture2D texture, Vector2 pos, Rectangle hitBox) : base(texture, pos, hitBox)
        {
            this.texture = texture;
            this.position = pos;
            this.hitbox = hitBox; 
            
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White); 
        }

    }
}
