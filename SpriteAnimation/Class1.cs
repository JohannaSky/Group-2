using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class Class1
    {

        protected Rectangle srcRect;
        protected int frame;
        protected double frameTimer, frameInterval = 100;


        public Class1()
        {
            srcRect = new Rectangle(0, 0, Game1.tex.Width / 12, Game1.tex.Height / 2);
        }


        public void FrameTimer(GameTime gameTime)
        {
            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer <= 0)
            {
                frameTimer = frameInterval;
                frame++;
                srcRect.X = (frame % 12) * Game1.tex.Width/12;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Game1.tex, new Rectangle(100, 100, 100, 120), srcRect, Color.White);
        }


    }
}
