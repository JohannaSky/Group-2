using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_X
{
    class Plattform
    {
        KeyboardState ks, oldKs;
        Texture2D tex;
        public int plattformSize;
        
        Tiles[] tiles;
        float x;
        float y;
        public Plattform(int plattformSize, Texture2D tex, float x, float y )
        {
            this.plattformSize = plattformSize;
            
            tiles = new Tiles[plattformSize];
            this.x = x;
            this.y = y;
            this.tex = tex;
                for (int i = 0; i < plattformSize; i++)
                {
                    tiles[i] = new Tiles(tex, new Rectangle((int)x + (i * tex.Width), (int)y, tex.Width, tex.Height));
                }
            
           
        }
        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < plattformSize; i++)
            {
                tiles[i].Draw(sb);
            }
        }
        public Tiles GetTile(int i)
        {
            return tiles[i];
        }
        public int getSize()
        {
            return this.plattformSize;
        }
        public float getX()
        {
            return this.x;
        }
        public float getY()
        {
            return this.y;
        }
        public Rectangle GetRect()
        {
        
                return new Rectangle((int)x, (int)y, plattformSize * tiles[0].tex.Width, tiles[0].tex.Height);
    
        }
    }
}
