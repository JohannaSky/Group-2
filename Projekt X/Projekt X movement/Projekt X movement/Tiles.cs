using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_X_movement
{
    class Tiles
    {
        public Texture2D tex;
        public Rectangle hitBox;

        public Tiles(Texture2D tex, Rectangle hitBox)
        {
            this.tex = tex;
            this.hitBox = hitBox;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, hitBox, Color.White);
        }
    }
}


