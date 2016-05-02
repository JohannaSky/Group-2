using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt_X
{
    class Map
    {
        Plattform[] mapOne;
        MovingPlattform[] mapOneMovement;
        Texture2D texOne;

        public Map()
        {
            this.texOne = Game1.block;
            CreateMapOne();
        }
        public void Update()
        {
            for (int i = 0; i < mapOneMovement.Length; i++)
            mapOneMovement[i].Update();
        }
        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < mapOne.Length; i++)
            {
                mapOne[i].Draw(sb);
            }
            for (int i = 0; i < mapOneMovement.Length; i++)
                mapOneMovement[i].Draw(sb);
        }
        private void CreateMapOne()
        {
            mapOne = new Plattform[63];
            mapOneMovement = new MovingPlattform[14];
            int bottomlevel = Game1.screenHeight - texOne.Height;
            

            mapOneMovement[0] = new MovingPlattform(4, texOne, 100, 600, new Vector2(600, 600));
            //Del1Mark
            mapOne[0] = new Plattform(15, texOne, 0, bottomlevel);
            mapOne[1] = new Plattform(10, texOne, texOne.Width * 18, bottomlevel);
            mapOne[2] = new Plattform(1, texOne, texOne.Width * 55, bottomlevel);
            mapOne[3] = new Plattform(4, texOne, texOne.Width * 69, bottomlevel);
            mapOne[4] = new Plattform(1, texOne, texOne.Width * 87, bottomlevel);
            mapOne[5] = new Plattform(28, texOne, texOne.Width * 99, bottomlevel);
            mapOneMovement[0] = new MovingPlattform(1, texOne, texOne.Width * 56, bottomlevel, new Vector2(texOne.Width * 68, bottomlevel));
            mapOneMovement[1] = new MovingPlattform(1, texOne, texOne.Width * 73, bottomlevel, new Vector2(texOne.Width * 86, bottomlevel));
            //Del1OvanMark
            mapOne[6] = new Plattform(1, texOne, texOne.Width * 29, HeightPos(3));
            mapOne[7] = new Plattform(1, texOne, texOne.Width * 46, HeightPos(3));
            mapOne[8] = new Plattform(4, texOne, texOne.Width * 47, HeightPos(5));
            mapOne[9] = new Plattform(4, texOne, texOne.Width * 51, HeightPos(7));
            mapOne[10] = new Plattform(4, texOne, texOne.Width * 88, HeightPos(3));
            mapOne[11] = new Plattform(4, texOne, texOne.Width * 92, HeightPos(5));
            mapOne[12] = new Plattform(4, texOne, texOne.Width * 96, HeightPos(3));
            mapOne[13] = new Plattform(3, texOne, texOne.Width * 98, HeightPos(7));
            mapOne[14] = new Plattform(4, texOne, texOne.Width * 101, HeightPos(9));
            mapOne[15] = new Plattform(1, texOne, texOne.Width * 106, HeightPos(9));
            mapOne[16] = new Plattform(1, texOne, texOne.Width * 125, HeightPos(9));
            mapOne[17] = new Plattform(1, texOne, texOne.Width * 126, HeightPos(11));
            mapOne[18] = new Plattform(1, texOne, texOne.Width * 145, HeightPos(11));
            mapOne[19] = new Plattform(1, texOne, texOne.Width * 147, HeightPos(7));
            mapOne[20] = new Plattform(1, texOne, texOne.Width * 165, HeightPos(7));
            mapOne[21] = new Plattform(1, texOne, texOne.Width * 166, HeightPos(9));
            mapOne[22] = new Plattform(1, texOne, texOne.Width * 185, HeightPos(9));
            mapOne[23] = new Plattform(19, texOne, texOne.Width * 186, HeightPos(11));
            mapOne[24] = new Plattform(3, texOne, texOne.Width * 194, HeightPos(14));
            mapOne[25] = new Plattform(3, texOne, texOne.Width * 204, HeightPos(12));

            mapOneMovement[2] = new MovingPlattform(1, texOne, texOne.Width * 30, HeightPos(3), new Vector2(texOne.Width * 45, HeightPos(3)));
            mapOneMovement[3] = new MovingPlattform(1, texOne, texOne.Width * 107, HeightPos(9), new Vector2(texOne.Width * 124, HeightPos(9)));
            mapOneMovement[4] = new MovingPlattform(1, texOne, texOne.Width * 127, HeightPos(11), new Vector2(texOne.Width * 144, HeightPos(11)));
            mapOneMovement[5] = new MovingPlattform(1, texOne, texOne.Width * 148, HeightPos(7), new Vector2(texOne.Width * 164, HeightPos(7)));
            mapOneMovement[6] = new MovingPlattform(1, texOne, texOne.Width * 167, HeightPos(9), new Vector2(texOne.Width * 184, HeightPos(9)));


            //Del2Mark
            mapOne[26] = new Plattform(11, texOne, texOne.Width * 212, bottomlevel);
            mapOne[27] = new Plattform(42, texOne, texOne.Width * 271, bottomlevel);
            //Del2OvanMark
            mapOne[28] = new Plattform(3, texOne, texOne.Width * 209, HeightPos(7));
            mapOne[29] = new Plattform(3, texOne, texOne.Width * 222, HeightPos(7));
            mapOne[30] = new Plattform(3, texOne, texOne.Width * 224, HeightPos(3));
            mapOne[31] = new Plattform(3, texOne, texOne.Width * 226, HeightPos(5));
            mapOne[32] = new Plattform(3, texOne, texOne.Width * 230, HeightPos(7));
            mapOne[33] = new Plattform(3, texOne, texOne.Width * 234, HeightPos(9));
            mapOne[34] = new Plattform(10, texOne, texOne.Width * 237, HeightPos(11));
            mapOne[35] = new Plattform(1, texOne, texOne.Width * 247, HeightPos(9));
            mapOne[36] = new Plattform(1, texOne, texOne.Width * 258, HeightPos(9));
            mapOne[37] = new Plattform(1, texOne, texOne.Width * 259, HeightPos(7));
            mapOne[38] = new Plattform(1, texOne, texOne.Width * 270, HeightPos(7));
            mapOne[39] = new Plattform(3, texOne, texOne.Width * 272, HeightPos(5));
            mapOne[40] = new Plattform(1, texOne, texOne.Width * 284, HeightPos(5));
            mapOne[41] = new Plattform(1, texOne, texOne.Width * 291, HeightPos(5));
            mapOne[42] = new Plattform(20, texOne, texOne.Width * 293, HeightPos(2));
            mapOne[43] = new Plattform(20, texOne, texOne.Width * 293, HeightPos(3));
            mapOne[44] = new Plattform(53, texOne, texOne.Width * 293, HeightPos(7));
            mapOne[45] = new Plattform(3, texOne, texOne.Width * 301, HeightPos(8));
            mapOne[46] = new Plattform(1, texOne, texOne.Width * 306, HeightPos(10));
            mapOne[47] = new Plattform(1, texOne, texOne.Width * 323, HeightPos(10));
            mapOne[48] = new Plattform(11, texOne, texOne.Width * 334, HeightPos(8));
            mapOne[49] = new Plattform(9, texOne, texOne.Width * 335, HeightPos(9));
            mapOne[50] = new Plattform(7, texOne, texOne.Width * 336, HeightPos(10));
            mapOne[51] = new Plattform(5, texOne, texOne.Width * 337, HeightPos(11));

            mapOneMovement[7] = new MovingPlattform(1, texOne, texOne.Width * 212, HeightPos(7), new Vector2(texOne.Width * 221, HeightPos(7)));
            mapOneMovement[8] = new MovingPlattform(1, texOne, texOne.Width * 248, HeightPos(9), new Vector2(texOne.Width * 257, HeightPos(9)));
            mapOneMovement[9] = new MovingPlattform(1, texOne, texOne.Width * 260, HeightPos(7), new Vector2(texOne.Width * 269, HeightPos(7)));
            mapOneMovement[10] = new MovingPlattform(1, texOne, texOne.Width * 285, HeightPos(5), new Vector2(texOne.Width * 291, HeightPos(5)));
            mapOneMovement[11] = new MovingPlattform(1, texOne, texOne.Width * 307, HeightPos(10), new Vector2(texOne.Width * 321, HeightPos(10)));

            //Del3Mark
            mapOne[52] = new Plattform(85, texOne, texOne.Width * 350, bottomlevel);
            //Del3OvanMark
            mapOne[53] = new Plattform(13, texOne, texOne.Width * 361, HeightPos(2));
            mapOne[54] = new Plattform(6, texOne, texOne.Width * 365, HeightPos(3));
            mapOne[55] = new Plattform(1, texOne, texOne.Width * 373, HeightPos(5));
            mapOne[56] = new Plattform(1, texOne, texOne.Width * 387, HeightPos(5));
            mapOne[57] = new Plattform(19, texOne, texOne.Width * 390, HeightPos(5));
            mapOne[58] = new Plattform(1, texOne, texOne.Width * 411, HeightPos(5));
            mapOne[59] = new Plattform(1, texOne, texOne.Width * 425, HeightPos(5));
            mapOne[60] = new Plattform(5, texOne, texOne.Width * 427, HeightPos(5));
            mapOne[61] = new Plattform(7, texOne, texOne.Width * 429, HeightPos(2));
            mapOne[62] = new Plattform(5, texOne, texOne.Width * 432, HeightPos(3));

            mapOneMovement[12] = new MovingPlattform(1, texOne, texOne.Width * 374, HeightPos(5), new Vector2(texOne.Width * 386, HeightPos(5)));
            mapOneMovement[13] = new MovingPlattform(1, texOne, texOne.Width * 412, HeightPos(5), new Vector2(texOne.Width * 424, HeightPos(5)));

        }
        private int HeightPos(int x)
        {
            return Game1.screenHeight - texOne.Height * x;
        }
        public void GetCollide(Rectangle hitBox, bool isFalling)
        {

            for (int i = 0; i < mapOne.Length; i++)
            {

                if (mapOne[i].GetRect().Intersects(hitBox) && isFalling == true)
                {
                    if (mapOne[i].GetRect().Y >= hitBox.Y + 40) //Justera höjden som spelaren behöver uppnå för att kunna stå på plattformen här
                    {
                        Player.isOnGround = true;
                        break;
                    }
                }
                else
                {
                    Player.isOnGround = false;
                }

            }
            for (int i = 0; i < mapOneMovement.Length; i++)
            {
                if (mapOneMovement[i].GetRect().Intersects(hitBox) && isFalling == true)
                {
                    if (mapOneMovement[i].GetRect().Y >= hitBox.Y + 40) //Justera höjden som spelaren behöver uppnå för att kunna stå på plattformen här
                    {
                        Player.isOnGround = true;
                        mapOneMovement[i].SetOnPlattform(true);
                        break;
                    }
                }
                else
                {
                    mapOneMovement[i].SetOnPlattform(false);
                }

            }
        }
        public MovingPlattform[] GetMovingPlattforms()
        {
            return mapOneMovement;
        }
    }
}
