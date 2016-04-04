using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hobby_projekt
{
    class MenuButton
    {

        private string text;
        private SpriteFont spriteFont;
        private Color currentColor;
        private Vector2 position = Vector2.Zero;
        private Vector2 origin = Vector2.Zero;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Color Color
        {
            get;
            set;
        }

        public Color HighlightColor
        {
            get;
            set;
        }

        public string Text
        {
            get
            { return text; }

            set
            {
                text = value;
                Vector2 textSize = MeasureString();
                origin.X = textSize.X / 2;
                origin.Y = textSize.Y / 2;
            }
        }

        public MenuButton(SpriteFont spriteFont, string text)
        {
            Color = Color.Black;
            currentColor = Color;
            HighlightColor = Color.Lime;
            this.spriteFont = spriteFont;
            Text = text;
        }

        public Vector2 MeasureString()
        {
            return spriteFont.MeasureString(text);
        }

        public void Select()
        {
            currentColor = HighlightColor;
        }

        public void UnSelect()
        {
            currentColor = Color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, text, position, currentColor, 0, origin, 1, SpriteEffects.None, 0);
        }

    }
}
