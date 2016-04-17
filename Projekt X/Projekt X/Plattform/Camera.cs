using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_X
{
    class Camera
    {
        Player target;
        Rectangle ScreenBounds, LevelBounds;
        Matrix translationMatrix;
        public Matrix TranslationMatrix
        {
            get { return translationMatrix; }
        }
        public Camera(Player target, Rectangle ScreenBounds, Rectangle LevelBounds)
        {
            this.target = target;
            this.ScreenBounds = ScreenBounds;
            this.LevelBounds = LevelBounds;
        }
        public void Update()
        {
            float translationX = -MathHelper.Clamp(target.GetPos().X - ScreenBounds.Width / 2, 0, LevelBounds.Width - ScreenBounds.Width / 2);
            float translationY = MathHelper.Clamp(-(target.GetPos().Y - ScreenBounds.Height / 2), 0, LevelBounds.Height - ScreenBounds.Height / 2);
            translationMatrix = Matrix.CreateTranslation(translationX, translationY, 0);
        }
    }
}