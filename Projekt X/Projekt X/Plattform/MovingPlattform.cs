using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_X
{
    class MovingPlattform
    {
        KeyboardState ks, oldKs;
        Texture2D tex;
        public int plattformSize;
        Tiles[] tiles;
        float x, y;
        
        Vector2 pos, startPos, moveTo;

        int speed;
        bool direction, onPlattform; 

        public MovingPlattform(int plattformSize, Texture2D tex, float x, float y, Vector2 moveTo)
        {
            direction = true;
            onPlattform = false;

            this.plattformSize = plattformSize;
            tiles = new Tiles[plattformSize];
            this.x = x;
            this.y = y;

            this.startPos = new Vector2(x, y);
            this.pos = new Vector2(x, y);

            this.tex = tex;
            this.moveTo = moveTo;

            this.speed = 3;
            for (int i = 0; i < plattformSize; i++)
            {
                tiles[i] = new Tiles(tex, new Rectangle((int)pos.X + (i * tex.Width), (int)pos.Y, tex.Width, tex.Height));
            }
           
        }
        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < plattformSize; i++)
            {
                tiles[i].Draw(sb);
            }
        }
        public void Update()
        {
            PlattformMovement();
            for (int i = 0; i < plattformSize; i++)
            {
                tiles[i].SetRect(new Rectangle((int)pos.X + (i * tex.Width), (int)pos.Y, tex.Width, tex.Height));
            }

        }
        public void PlattformMovement()
        {
            if (direction == true)
            {
                if (Vector2.Distance(moveTo, pos) > speed)
                {
                    Vector2 targetVector = Vector2.Normalize(moveTo - pos);
                    pos += targetVector * speed;
                }
                else if (Vector2.Distance(moveTo, pos) <= speed)
                {
                    pos = moveTo;
                    direction = false;
                }
            }
            else
            {
               
                if (Vector2.Distance(startPos, pos) > speed)
                {
                    Vector2 targetVector = Vector2.Normalize(startPos - pos);
                    pos += targetVector * speed;
                }
                else if (Vector2.Distance(startPos, pos) <= speed)
                {
                    pos = startPos;
                    direction = true;
                }
            }

            
        }
        public void SetOnPlattform(bool onPlattform)
        {
            this.onPlattform = onPlattform;
        }
        public bool GetOnPlattform()
        {
            return onPlattform;
        }
        public Tiles GetTile(int i)
        {
            return tiles[i];
        }
        public int getSize()
        {
            return this.plattformSize;
        }
        public Vector2 GetPos()
        {
            return pos;
        }
        public Rectangle GetRect()
        {
            return new Rectangle((int)pos.X, (int)pos.Y , plattformSize * tiles[0].tex.Width, tiles[0].tex.Height);
        }
        

    }
}
