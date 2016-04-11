using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_X_movement
{
    class Player
    {
        KeyboardState ks, oldKs;
        Vector2 speed, pos;
        Texture2D character;
        bool isOnGround, isFalling;
        Plattform[] plattforms;
        Rectangle hitBox;
        public Player(Texture2D character, Plattform[] plattforms)
        {
            this.character = character;
            pos = new Vector2(300, 300);
            isOnGround = true;
            this.plattforms = plattforms;
            isFalling = false;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y - character.Height, character.Width, 1);
        }
        public void Update()
        {
            
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
            if(ks.IsKeyDown(Keys.Right) && ((pos.X + character.Width) < 800))
            {
                speed.X = 3;
            }
            else if(ks.IsKeyDown(Keys.Left) && pos.X > 0)
            {
                speed.X = -3;
            }
            else
            {
                speed.X = 0;
            }

            if(ks.IsKeyDown(Keys.Up) && isOnGround == true)
            {
                speed.Y = -12;
                isOnGround = false;
            }

  
                for (int i = 0; i < plattforms.Length; i++)
                {

                        if (plattforms[i].GetRect().Intersects(hitBox))
                        {
                                if (isFalling == true)
                                {
                                isOnGround = true;
                                speed.Y = 0;
                            
                                break;
                            }
                        }
                        else
                        {
                            isOnGround = false;
                        }
                    
                  
                
            }
            pos += speed;
            if (pos.Y + character.Height >= 580)
            {
                isOnGround = true;
                speed.Y = 0;
            }
            if(speed.Y <= 0)
            {
                isFalling = false;
            }
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, character.Width, character.Height);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(character, pos, Color.White);
        }
    }
}
