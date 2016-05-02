using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_X
{
    class Player
    {
        
        KeyboardState ks, oldKs;
        Vector2 speed, pos;
        Texture2D character;
        bool isFalling;
        static public bool isOnGround, ridingPlattformForward, ridingPlattformBackward;
        Map maps;
        ParallaxScroll paralaxScroll;
        Rectangle hitBox;
        Rectangle srcRect;
        int frame;
        float characterWidth, characterHeight;
        double frameTimer, frameInterval;
        SpriteEffects characterFx;
        public Player(ContentManager content, GameWindow window)
        {
            this.character = Game1.character;
            pos = new Vector2(100, 800);
            isOnGround = true;
            ridingPlattformForward = false;
            ridingPlattformBackward = false;
            maps = new Map();        
            isFalling = false;
            characterWidth = character.Width / 120;
            characterHeight = character.Height / 20;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y - (int)characterHeight, (int)characterWidth, 1);
            paralaxScroll = new ParallaxScroll(content, window);
            frameTimer = 100;
            frameInterval = 100;
            characterFx = SpriteEffects.None;
            srcRect = new Rectangle(0, 0, character.Width / 12, character.Height / 2);       
        }
        public void Update(GameTime gameTime)
        {
            maps.Update();
            paralaxScroll.Update();
            oldKs = ks;
            ks = Keyboard.GetState();
            
            if(isOnGround == false)
            {
                speed.Y += 0.2f;
            }
            if(speed.Y > 0)
            {
                isFalling = true;
            }
            if(ks.IsKeyDown(Keys.Right))
            {
                characterFx = SpriteEffects.None;
                speed.X = 5f;
                frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                if (frameTimer <= 0)
                {
                    frameTimer = frameInterval;
                    frame++;
                    srcRect.X = (frame % 12) * character.Width / 12;
                }
            }
            else if(ks.IsKeyDown(Keys.Left) && pos.X > 0)
            {
                characterFx = SpriteEffects.FlipHorizontally;
                speed.X = -5f;
                frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
                if (frameTimer <= 0)
                {
                    frameTimer = frameInterval;
                    frame++;
                    srcRect.X = (frame % 12) * character.Width / 12;
                }
            }
            else
            {
                speed.X = 0;
                srcRect = new Rectangle(0, 0, character.Width / 12, character.Height / 2);
                frameTimer = 100;
            }

            if(ks.IsKeyDown(Keys.Up) && isOnGround == true)
            {
                speed.Y = -7;
                isOnGround = false;
            }

            maps.GetCollide(hitBox, isFalling);
            if(isOnGround == true)
            {
                speed.Y = 0;
            }
            if(ridingPlattformForward == true)
            {
                speed.X += 6;
            }
            if(ridingPlattformBackward == true)
            {
                speed.X -= 6;
            }
                                                          
            pos += speed;
            if (pos.Y + character.Height / 20 >= Game1.screenHeight)
            {
                isOnGround = true;
                speed.Y = 0;
            }
            if(speed.Y <= 0)
            {
                isFalling = false;
            }

            //for (int i = 0; i < maps.GetMovingPlattforms().Length; i++)
            //{
            //    if(maps.GetMovingPlattforms()[i].GetOnPlattform() == true)
            //    {
            //        pos = maps.GetMovingPlattforms()[i].GetPos();
            //    }
            //}

                hitBox = new Rectangle((int)pos.X, (int)pos.Y, (int)characterWidth, (int)characterHeight);
                
        }
        public void Draw(SpriteBatch sb)
        {
            paralaxScroll.Draw(sb);
            maps.Draw(sb);
            sb.Draw(character, pos, srcRect, Color.White, 0, new Vector2(characterWidth / 2, characterHeight / 2), 1/10f, characterFx, 1);
        }
        public Vector2 GetPos()
        {
            return pos;
        }

    }
}

    
