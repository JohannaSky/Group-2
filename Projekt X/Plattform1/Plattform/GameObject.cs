using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Plattformkod
{
    abstract class GameObject
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle sourceRectangle;
        protected Rectangle hitbox;
        protected bool isAlive;

        public GameObject(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            isAlive = true;
        }
        public virtual bool isColliding(GameObject gameObject)
        {
            return hitbox.Intersects(gameObject.hitbox);
        }
        public virtual void HandleCollision(GameObject other)
        {
            hitbox.Y = other.hitbox.Y - hitbox.Height + 1;
            position.Y = hitbox.Y;
        }

        public virtual Rectangle Hitbox()
        {
            return hitbox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
           
        }
    }
}
