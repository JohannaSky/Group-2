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
        public Player(ContentManager content, GameWindow window)
        {
            this.character = Game1.character;
            pos = new Vector2(100, 800);
            isOnGround = true;
            ridingPlattformForward = false;
            ridingPlattformBackward = false;
            maps = new Map();        
            isFalling = false;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y - character.Height, character.Width, 1);
            paralaxScroll = new ParallaxScroll(content, window);
            
        }
        public void Update()
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
                speed.X = 5f;
            }
            else if(ks.IsKeyDown(Keys.Left) && pos.X > 0)
            {
                speed.X = -5f;
            }
            else
            {
                speed.X = 0;
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
            if (pos.Y + character.Height >= Game1.screenHeight)
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

                hitBox = new Rectangle((int)pos.X, (int)pos.Y, character.Width, character.Height);
                
        }
        public void Draw(SpriteBatch sb)
        {
            paralaxScroll.Draw(sb);
            maps.Draw(sb);
            sb.Draw(character, pos, Color.White);
        }
        public Vector2 GetPos()
        {
            return pos;
        }

    }
}

    
