using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Space_War.Managers
{
    
    class Content_Manager
    {
        private static Content_Manager instance;
        public Dictionary<String,Texture2D> Textures;
        public Dictionary<String, SpriteFont> Polices;
        ContentManager CM;

        private Content_Manager()
        {
            Textures = new Dictionary<string,Texture2D>();
            Polices = new Dictionary<string, SpriteFont>();

        }

        public static Content_Manager getInstance()
        {
            if (instance == null)
                instance = new Content_Manager();
            return instance;
        }

        public void LoadTextures(ContentManager Content)
        {
            CM = Content;
            /******************************************************************************
             * AJOUTER LES TEXTURES ICI
             * *****************************************************************************/
            AddTexture("TousAvions", "Heros");
            AddTexture("arme heros", "armeHeros");
            AddTexture("arme ennemi", "armeEnnemi");
            AddTexture("coeur", "vie");
            AddTexture("explosion");
            AddTexture("ennemi","soucoupe");
            AddTexture("Backgrounds/fond_EtoilesPetit", "fond1");
            AddTexture("Backgrounds/fond_EtoilesPetit2", "fond2");

            /******************************************************************************
              * AJOUTER LES POLICES ICI
              * *****************************************************************************/
            AddPolice("Polices/PoliceScore","PoliceScore");
            AddPolice("Polices/SpriteFont1","PoliceMenu");
            AddPolice("Polices/PoliceTitre","PoliceTitre");
        }

        private void AddTexture(String file)
        {
            Texture2D newTexture = CM.Load<Texture2D>(file);
            Textures.Add(file, newTexture);
        }

        private void AddTexture(String file, String name)
        {
            Texture2D newTexture = CM.Load<Texture2D>(file);
            Textures.Add(name, newTexture);
        }

        private void AddPolice(String file)
        {
            SpriteFont newPolice = CM.Load<SpriteFont>(file);
            Polices.Add(file, newPolice);
        }

        private void AddPolice(String file,String name)
        {
            SpriteFont newPolice = CM.Load<SpriteFont>(file);
            Polices.Add(name, newPolice);
        }
    }
}
