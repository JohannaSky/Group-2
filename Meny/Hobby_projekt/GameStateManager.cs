using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Hobby_projekt
{
    class GameStateManager
    {
        StartMenu startMenu;

        public enum GameState
        {
            startMenu,
            play,
            exit
        }
        public GameState gamestate = GameState.startMenu;

        public GameStateManager(ContentManager content, GraphicsDeviceManager graphics)
        {
            startMenu = new StartMenu(this, graphics);
            startMenu.LoadMenu(content);
        }

        public void Update()
        {
            switch (gamestate)
            {
                case GameState.startMenu:
                    startMenu.Update();
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gamestate)
            {
                case GameState.startMenu:
                    startMenu.Draw(spriteBatch);
                    break;
            }
        }

    }
}
