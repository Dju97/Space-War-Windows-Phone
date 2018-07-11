using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Space_War.Screens;
using Microsoft.Xna.Framework.Graphics;

namespace Space_War.Managers
{
    class ScreenManager
    {
        public enum Screens
        {
            Menu,
            Game,
        }

        Rectangle fen�tre;
        private Screens CurrentScreen;
        public bool isTransitionOn;
        private static ScreenManager instance;

        private ScreenManager(Rectangle fenetre)
        {
            fen�tre = fenetre;
            CurrentScreen = Screens.Menu;
            isTransitionOn = false;
        }

        public void ChangeCurrentScreen(Screens Screen)
        {
            switch (CurrentScreen)
            {
                case Screens.Menu:
                    CurrentScreen = Screen;
                    break;
                case Screens.Game:
                    GameScreen.getInstance(fen�tre).UnloadContent();
                    CurrentScreen = Screen;
                    break;
            }
        }

        public static ScreenManager getInstance(Rectangle fenetre)
        {
            if (instance == null)
                instance = new ScreenManager(fenetre);
            return instance;
        }


        public void Update(GameTime GameTime)
        {
            if (!isTransitionOn)
            {
                switch (CurrentScreen)
                {
                    case Screens.Game:
                        GameScreen.getInstance(fen�tre).Update(GameTime);
                        break;
                    case Screens.Menu:
                        MenuScreen.getInstance(fen�tre).Update(GameTime);
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (CurrentScreen)
            {
                case Screens.Game:
                    GameScreen.getInstance(fen�tre).Draw(spriteBatch, gameTime);
                    break;
                case Screens.Menu:
                    MenuScreen.getInstance(fen�tre).Draw(spriteBatch, gameTime);
                    break;
            }
        }
           
    }


}
