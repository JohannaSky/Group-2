using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public GameStateManager(ContentManager content)
        {
            startMenu = new StartMenu(this);
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
