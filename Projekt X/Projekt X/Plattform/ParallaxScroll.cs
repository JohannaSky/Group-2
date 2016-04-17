using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Projekt_X
{
    class ParallaxScroll
    {
        List<Vector2> foreground, middleground, background;
        int foregroundSpacing, middlegroundSpacing, backgroundSpacing;
        float foregroundSpeed, middlegroundSpeed, backgroundSpeed;
        Texture2D[] tex;
        GameWindow window;
        public float scale = 1.0f;
        public ParallaxScroll(ContentManager Content, GameWindow window)
        {
            this.tex = new Texture2D[3];

            this.window = window;

            tex[0] = Content.Load<Texture2D>("fore");
            tex[1] = Content.Load<Texture2D>("middle");
            tex[2] = Content.Load<Texture2D>("back");

            foreground = new List<Vector2>();
            foregroundSpacing = window.ClientBounds.Width / 2;
            foregroundSpeed = 1.5f;
            for (int i = 0; i < (window.ClientBounds.Width / foregroundSpacing) + 5; i++)
            {
                foreground.Add(new Vector2(i * foregroundSpacing * 1.6f, window.ClientBounds.Height - tex[0].Height - tex[1].Height * 1));
                foreground.Add(new Vector2(i * foregroundSpacing * 1, window.ClientBounds.Height - tex[0].Height - tex[1].Height * 1.9f));
                foreground.Add(new Vector2(i * foregroundSpacing * 1.6f, window.ClientBounds.Height - tex[0].Height - tex[1].Height * 1.6f));
                foreground.Add(new Vector2(i * foregroundSpacing * 1.2f, window.ClientBounds.Height - tex[0].Height - tex[1].Height * 1.4f));
                foreground.Add(new Vector2(i * foregroundSpacing * 1.4f, window.ClientBounds.Height - tex[0].Height - tex[1].Height * 1.2f));
                foreground.Add(new Vector2(i * foregroundSpacing * 1.8f, window.ClientBounds.Height - tex[0].Height - tex[1].Height * 1.8f));
                foreground.Add(new Vector2(i * foregroundSpacing * 1.9f, window.ClientBounds.Height - tex[0].Height - tex[1].Height * 1.2f));

            }

            middleground = new List<Vector2>();
            middlegroundSpacing = tex[1].Width - 10;
            middlegroundSpeed = 0.5f;
            for (int i = 0; i < (window.ClientBounds.Width / middlegroundSpacing) + 2; i++)
            {
                middleground.Add(new Vector2(i * middlegroundSpacing, window.ClientBounds.Height - tex[0].Height * 10.78f));
            }

            background = new List<Vector2>();
            backgroundSpacing = tex[2].Width - 100;
            backgroundSpeed = -0.9f;
            for (int i = 0; i < (window.ClientBounds.Width); i++)
            {
                background.Add(new Vector2(i * backgroundSpacing, window.ClientBounds.Height - tex[2].Height + 25));
            }
        }
        public void Update()
        {
            #region foreground
            for (int i = 0; i < foreground.Count; i++)
            {
                foreground[i] = new Vector2(foreground[i].X - foregroundSpeed, foreground[i].Y);
                if (foreground[i].X <= -foregroundSpacing)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = foreground.Count - 1;
                    }
                    foreground[i] = new Vector2(foreground[j].X - foregroundSpacing - 1, foreground[i].Y);
                }
            }

            #endregion
            #region middleground
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                for (int i = 0; i < middleground.Count; i++)
                {
                    middleground[i] = new Vector2(middleground[i].X - middlegroundSpeed, middleground[i].Y);
                    if (middleground[i].X <= -middlegroundSpacing)
                    {
                        int j = i - 1;
                        if (j < 0)
                        {
                            j = middleground.Count - 1;
                        }
                        middleground[i] = new Vector2(middleground[j].X + middlegroundSpacing, middleground[i].Y);
                    }
                }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                for (int i = 0; i < middleground.Count; i++)
                {
                    middleground[i] = new Vector2(middleground[i].X + middlegroundSpeed, middleground[i].Y);
                    if (middleground[i].X <= -middlegroundSpacing)
                    {
                        int j = i - 1;
                        if (j < 0)
                        {
                            j = middleground.Count - 1;
                        }
                        middleground[i] = new Vector2(middleground[j].X + middlegroundSpacing, middleground[i].Y);
                    }
                }
            
            #endregion
            #region background
             //if (Keyboard.GetState().IsKeyDown(Keys.Right))
             //   for (int i = 0; i < background.Count; i++)
             //   {
             //       background[i] = new Vector2(background[i].X - backgroundSpeed, background[i].Y);
             //       if (background[i].X <= -backgroundSpacing)
             //       {
             //           int j = i - 1;
             //           if (j < 0)
             //           {
             //               j = background.Count - 1;
             //           }
             //           background[i] = new Vector2(background[j].X + backgroundSpacing - 1, background[i].Y);
             //       }

             //   }

            
            #endregion
        }
        public void Draw(SpriteBatch sb)
        {
            foreach (Vector2 v in background)
            {
                sb.Draw(tex[2], v, Color.White);
            }
            foreach (Vector2 v in middleground)
            {
                sb.Draw(tex[1], v, Color.White);
            }
            foreach (Vector2 v in foreground)
            {
                sb.Draw(tex[0], v, Color.White);
            }
        }
    }
}
