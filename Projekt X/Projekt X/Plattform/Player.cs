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
        bool isOnGround, isFalling;
        Plattform[] plattforms;
        ParallaxScroll paralaxScroll;
        Rectangle hitBox;
        public Player(/*, Plattform[] plattforms,*/ ContentManager content, GameWindow window)
        {
            this.character = Game1.character;
            pos = new Vector2(300, 300);
            isOnGround = true;
           
            plattforms = new Plattform[2];
            plattforms[0] = new Plattform(3, character, 100, 1000);
            plattforms[1] = new Plattform(3, character, 100, 900);
            
            isFalling = false;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y - character.Height, character.Width, 1);
            paralaxScroll = new ParallaxScroll(content, window);
        }
        public void Update()
        {
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
            if (pos.Y + character.Height >= Game1.screenHeight)
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
            paralaxScroll.Draw(sb);
            for (int i = 0; i < plattforms.Length; i++)
            {
                plattforms[i].Draw(sb);
            }
            sb.Draw(character, pos, Color.White);

        }
    }
}

    
