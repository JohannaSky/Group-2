using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_X
{
    class Plattform
    {
        public int plattformSize;
        Tiles[] tiles;
        int x;
        int y;
        public Plattform(int plattformSize, Texture2D tex, int x, int y)
        {
            this.plattformSize = plattformSize;
            tiles = new Tiles[plattformSize];
            this.x = x;
            this.y = y;
            for (int i = 0; i < plattformSize; i++)
            {
                tiles[i] = new Tiles(tex, new Rectangle(x + (i * tex.Width), y, tex.Width, tex.Height));
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
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public Rectangle GetRect()
        {
            return new Rectangle(x - 3, y - 3, plattformSize * tiles[0].tex.Width, tiles[0].tex.Height);
        }

    }
}
