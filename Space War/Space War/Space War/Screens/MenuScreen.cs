using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Space_War.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_War.Screens
{
    class MenuScreen
    {
        private static MenuScreen instance;
        Rectangle fenêtre;
        public List<String> ElementsMenus;
        SpriteFont policeMenu;
        List<Rectangle> EmplacementsBoutons;
        List<Bouton> Boutons;
        TouchCollection étatTactile;
        public ScrollingBackground background1;
        public ScrollingBackground background2;

        private MenuScreen(Rectangle fenetre)
        {
            fenêtre = fenetre;
            ElementsMenus = new List<string> { "Play", "Exit" };
            policeMenu = Content_Manager.getInstance().Polices["PoliceMenu"];
            EmplacementsBoutons = new List<Rectangle> { };
            int i = 0;
            foreach (string element in ElementsMenus)
            {
                EmplacementsBoutons.Add(new Rectangle((int)(fenêtre.Width / 2-(policeMenu.MeasureString(element).X/2)),
                    (fenêtre.Height/2)-(policeMenu.LineSpacing*ElementsMenus.Count/2)+((policeMenu.LineSpacing)*i),(int)policeMenu.MeasureString(element).X,
                   (int)(policeMenu.MeasureString(element).Y)));
                i++;
            }
            Boutons = new List<Bouton> {new BoutonGame(EmplacementsBoutons[0],fenêtre), new BoutonExit(EmplacementsBoutons[1],fenêtre) };
            background1 = new ScrollingBackground("fond1", fenêtre,20);
            background2 = new ScrollingBackground("fond2", new Rectangle(0, -Content_Manager.getInstance().Textures["fond2"].Height, fenêtre.Width, fenêtre.Height),20);
         
        }

        public static MenuScreen getInstance(Rectangle fenetre)
        {
            if (instance == null)
                instance = new MenuScreen(fenetre);
            return instance;
        }


        public virtual void Update(GameTime gameTime)
        {
            étatTactile = TouchPanel.GetState();
            if (étatTactile.Count > 0)
            {
                foreach (TouchLocation location in étatTactile)
                {
                    Point touchLocation = new Point((int)location.Position.X, (int)location.Position.Y);
                    foreach (Bouton bouton in Boutons)
                    {
                        if (bouton.emplacementBouton.Contains(touchLocation))
                        {
                            bouton.Agir();
                        }
                    }
                }


                
            }

            if (background1.rectangle.Y > fenêtre.Height)
                background1.rectangle.Y = background2.rectangle.Y - background1.texture.Height;
            if (background2.rectangle.Y > fenêtre.Height)
                background2.rectangle.Y = background1.rectangle.Y - background2.texture.Height;

            background1.Update();
            background2.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            background1.Draw(spriteBatch);
            background2.Draw(spriteBatch);
            int i=0;
            foreach (string element in ElementsMenus)
            {
                spriteBatch.DrawString(policeMenu, element, new Vector2(fenêtre.Width / 2 - (policeMenu.MeasureString(element).X / 2)+3,
                   (fenêtre.Height / 2) - (policeMenu.LineSpacing * ElementsMenus.Count / 2) + ((policeMenu.LineSpacing) * i)-1), Color.White);
                spriteBatch.DrawString(policeMenu, element, new Vector2(fenêtre.Width / 2-(policeMenu.MeasureString(element).X/2),
                    (fenêtre.Height/2)-(policeMenu.LineSpacing*ElementsMenus.Count/2)+((policeMenu.LineSpacing)*i)), Color.Red);
                i++;
            }

            spriteBatch.DrawString(Content_Manager.getInstance().Polices["PoliceTitre"], "SPACE WAR", new Vector2(fenêtre.Width / 2 - (Content_Manager.getInstance().Polices["PoliceTitre"].MeasureString("SPACE WAR").X / 2), 50), Color.Orange);
        }
    }
}
