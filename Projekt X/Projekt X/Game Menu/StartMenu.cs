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
    class StartMenu
    {
        MouseState mouseState, previousMouseState;
        KeyboardState keyboardState;
        KeyboardState previousKeyboardState;
        SpriteFont spriteFont;
        List<MenuButton> menuButtonList = new List<MenuButton>();
        int selected = 0;
        MenuButton selectedMenuButton;
        GameStateManager stateManager;

        GraphicsDeviceManager graphics;

        Rectangle buttonRect_1, buttonRect_2, mouseRect;
        Vector2 stringSize_1, stringSize_2, mouseRect_Size;

        const string playString = "Start", exitString = "Exit";

        public StartMenu(GameStateManager stateManager, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.stateManager = stateManager;
            this.spriteFont = Game1.spriteFont;
        }

        public void LoadMenu(ContentManager content)
        {
            previousMouseState = Mouse.GetState();

            
            menuButtonList.Add(new MenuButton(spriteFont, playString));
            menuButtonList.Add(new MenuButton(spriteFont, exitString));

            stringSize_1 = menuButtonList[0].MeasureString();
            stringSize_2 = menuButtonList[1].MeasureString();

            mouseRect_Size = new Vector2(20, 20);

            int lineSpacing = 9;
            Vector2 startPosition = new Vector2(Game1.screenWidth / 2, Game1.screenHeight / 2);
            foreach (MenuButton button in menuButtonList)
            {
                button.Position = startPosition;
                startPosition.Y += button.MeasureString().Y + lineSpacing;
            }

            selectedMenuButton = menuButtonList[0];
            selectedMenuButton.Select();

            buttonRect_1 = new Rectangle((int)menuButtonList[0].Position.X - (int)stringSize_1.X / 2, (int)menuButtonList[0].Position.Y - (int)stringSize_1.Y / 2,
                (int)stringSize_1.X, (int)stringSize_1.Y);
            buttonRect_2 = new Rectangle((int)menuButtonList[1].Position.X - (int)stringSize_2.X / 2, (int)menuButtonList[1].Position.Y - (int)stringSize_2.Y / 2,
                (int)stringSize_2.X, (int)stringSize_2.Y);
        }

        public bool CheckKeyboard(Keys key)
        {
            return (keyboardState.IsKeyDown(key) && !previousKeyboardState.IsKeyDown(key));
        }

        public void Update()
        {
            keyboardState = Keyboard.GetState();

            mouseState = Mouse.GetState();
            mouseRect = new Rectangle((int)(mouseState.X), (int)(mouseState.Y),
                (int)mouseRect_Size.X, (int)mouseRect_Size.Y);

            if (buttonRect_1.Intersects(mouseRect))
            {
                selectedMenuButton.UnSelect();
                selectedMenuButton = menuButtonList[0];
                selectedMenuButton.Select();
            }

            if (buttonRect_2.Intersects(mouseRect))
            {
                selectedMenuButton.UnSelect();
                selectedMenuButton = menuButtonList[1];
                selectedMenuButton.Select();
            }

            else if (CheckKeyboard(Keys.Up))
            {
                if (selected > 0)
                    selected--;

                selectedMenuButton.UnSelect();
                selectedMenuButton = menuButtonList[selected];
                selectedMenuButton.Select();
            }

            else if (CheckKeyboard(Keys.Down))
            {
                if (selected < menuButtonList.Count - 1)
                    selected++;

                selectedMenuButton.UnSelect();
                selectedMenuButton = menuButtonList[selected];
                selectedMenuButton.Select();
            }

            if (CheckKeyboard(Keys.Enter)
                || buttonRect_1.Intersects(mouseRect) && mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released
                || buttonRect_2.Intersects(mouseRect) && mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                string selectedButtonString = selectedMenuButton.Text;

                switch (selectedButtonString)
                {
                    case playString:
                        stateManager.gamestate = GameStateManager.GameState.play;
                        break;

                    case exitString:
                        stateManager.gamestate = GameStateManager.GameState.exit;
                        break;
                }
            }
            previousKeyboardState = keyboardState;
            previousMouseState = mouseState;
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < menuButtonList.Count; i++)
            {
                menuButtonList[i].Draw(sb);
            }


        }

    }
}
