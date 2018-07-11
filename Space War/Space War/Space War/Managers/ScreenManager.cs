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

        Rectangle fenêtre;
        private Screens CurrentScreen;
        public bool isTransitionOn;
        private static ScreenManager instance;

        private ScreenManager(Rectangle fenetre)
        {
            fenêtre = fenetre;
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
                    GameScreen.getInstance(fenêtre).UnloadContent();
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
                        GameScreen.getInstance(fenêtre).Update(GameTime);
                        break;
                    case Screens.Menu:
                        MenuScreen.getInstance(fenêtre).Update(GameTime);
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (CurrentScreen)
            {
                case Screens.Game:
                    GameScreen.getInstance(fenêtre).Draw(spriteBatch, gameTime);
                    break;
                case Screens.Menu:
                    MenuScreen.getInstance(fenêtre).Draw(spriteBatch, gameTime);
                    break;
            }
        }
           
    }


}
