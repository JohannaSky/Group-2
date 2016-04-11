using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Plattformkod
{
    abstract class GameObjects
    {
        public Texture2D tex;
        public Vector2 pos = Vector2.Zero;
        protected Rectangle sourceRectangle;
        public float rotation = 0.0f;
        public float scale = 1;
        public Vector2 Origin = Vector2.Zero;
       public Rectangle hitBox;
        public bool isAlive;

        public GameObjects(Texture2D tex, Vector2 pos)
        {
            this.tex = tex;
            this.pos = pos;
            isAlive = true;
        }
        public virtual bool isColliding(GameObjects p)
        {
            return hitBox.Intersects(p.hitBox);
        }
        public virtual void HandleCollision(GameObjects other)
        {
            hitBox.Y = other.hitBox.Y - hitBox.Height + 1;
            pos.Y = hitBox.Y;
        }

        public virtual Rectangle Hitbox()
        {
            return hitBox = new Rectangle((int)pos.X, (int)pos.Y, 30, 30);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(tex, hitBox, Color.Blue);
        }
    }
}
