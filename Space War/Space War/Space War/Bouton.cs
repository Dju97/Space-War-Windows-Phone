using Microsoft.Xna.Framework;
using Space_War.Managers;
using Space_War.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_War
{
    class Bouton
    {
        public Rectangle emplacementBouton;
        protected Rectangle fenêtre;

        public virtual void Agir()
        {
        }
    }

    class BoutonGame : Bouton
    {
         public BoutonGame(Rectangle emplacement, Rectangle fenetre)
        {
            emplacementBouton = emplacement;
            fenêtre = fenetre;
        }
        public override void Agir()
        {
            ScreenManager.getInstance(fenêtre).ChangeCurrentScreen(ScreenManager.Screens.Game);
            GameScreen.getInstance(fenêtre).Initialize();
        }
    }

    class BoutonExit : Bouton
    {
        public BoutonExit(Rectangle emplacement, Rectangle fenetre)
        {
            emplacementBouton = emplacement;
            fenêtre = fenetre;
        }
        public override void Agir()
        {
            SpaceWar Game = new SpaceWar();
            Game.Exit();
        }
    }
}
