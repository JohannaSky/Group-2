using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_X
{
    class PhysicalObject
    {
        public Texture2D sprite;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 acceleration;

        public PhysicalObject(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }
        public PhysicalObject(Texture2D sprite, Vector2 position, Vector2 velocity)
        {
            this.sprite = sprite;
            this.position = position;
            this.velocity = velocity;
        }
        public PhysicalObject(Texture2D sprite, Vector2 position, Vector2 velocity, Vector2 acceleration)
        {
            this.sprite = sprite;
            this.position = position;
            this.velocity = velocity;
            this.acceleration = acceleration;
            acceleration = new Vector2(0, 0);
        }
        public virtual void Update(float elapsedSeconds)
        {
            position += elapsedSeconds * (velocity + acceleration * elapsedSeconds / 2);
            velocity += acceleration * elapsedSeconds;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, positionToPixel(position), Color.White);
        }
        static public Vector2 positionToPixel(Vector2 vector)
        {
            return Constants.positionToPixel(vector);
        }
    }
}
