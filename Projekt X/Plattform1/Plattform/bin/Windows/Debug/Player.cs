using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Plattformkod
{
    abstract class Player : GameObject
    {

        public Player(Texture2D texture, Vector2 position, int sourceRectY, int sourceRectX)
            : base(texture, position)
        {
            this.texture = texture;
           
            sourceRectangle = new Rectangle(sourceRectY, sourceRectX, 30, 30);
        }

        public abstract void Update();

    }

}
