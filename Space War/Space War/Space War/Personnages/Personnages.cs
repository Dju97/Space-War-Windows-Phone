using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Space_War.Managers;
namespace Space_War
{
    class Personnages : Mere
    {
        //Champs

        protected int tour;
        public bool explose;
        private int compteurExplosion;
        int FrameColumn;

        //Paramètres

        public int NbreDeVies;

        protected int NbreDeViesDefaut;

        public Armes ArmePerso = new Armes();

        protected int FréquenceTir;

        private Texture2D textureExplosion = Content_Manager.getInstance().Textures["explosion"];

        //Methodes
        protected virtual Rectangle Exploser()
        {
            
            switch(compteurExplosion)
            {
                case 0:
                    FrameColumn = 1;
                    break;
                case 80:
                    FrameColumn = 2;
                    break;
                case 160:
                    FrameColumn = 3;
                    break;
                case 240:
                    FrameColumn = 4;
                    break;
                case 320:
                    FrameColumn = 5;
                    break;
                case 400:
                    FrameColumn = 6;
                    break;
                case 480:
                    FrameColumn = 7;
                    break;
                case 560:
                    FrameColumn = 8;
                    //Fonction disparaitre 
                    isVisible = false;
                    break;
                case 640:
                    FrameColumn = 9;
                    break;
                case 720:
                    FrameColumn = 10;
                    break;
                case 800:
                    FrameColumn = 11;
                    break;
                case 880:
                    FrameColumn = 12;
                    break;
                case 960:
                    FrameColumn = 13;
                    break;
                case 1040:
                    FrameColumn = 14;
                    break;
                case 1120:
                    FrameColumn = 15;
                    break;
                case 1200:
                    FrameColumn = 16;
                    break;
                case 1280 :
                    FrameColumn = 0;
                    explose = false;
                    Position = new Vector2(-100, 0);
                    break;
            }
                compteurExplosion += 40;
                return new Rectangle((FrameColumn - 1) * 80, 0, 80, 80);
        }

        protected virtual void Tirer()
        {
            ArmePerso.Apparaitre(new Vector2(Position.X + Texture.Width/2,Position.Y+Texture.Height));
        }

        public virtual void RecevoirDegats(int degats)
        {
            if (NbreDeVies > 0)
            {
                NbreDeVies -= degats;
                if (NbreDeVies <= 0)
                {
                    this.Disparaitre();
                }
            }
        }

        public override void Agir(Personnages cible1)
        {
                base.Agir(cible1);
                if (ArmePerso.isVisible)
                {
                ArmePerso.Agir(cible1);
                }
                tour += 1;
                if (tour == FréquenceTir && !explose && isVisible)
                {
                    if (!explose && isVisible)
                    {
                        tour = 0;
                        this.Tirer();
                    }
                    else
                        tour = 0;
                }
        }

        public virtual void Apparaitre(Vector2 Position, List<Personnages> ennemis)
        {
            base.Apparaitre(Position);
            NbreDeVies = NbreDeViesDefaut;
            ennemis.Add(this);
            compteurExplosion = 0;
            ArmePerso.isVisible = false;
            tour = 0;
        }
        
        protected override void Disparaitre()
        {
            explose = true;
        }

        public override void Draw(SpriteBatch spritebatch, GameTime gametime)
        {
            if (isVisible == true)
            {
                spritebatch.Draw(Texture, Position, Color.White);
            }
            ArmePerso.Draw(spritebatch, gametime);

            if (explose)
            {
                spritebatch.Draw(textureExplosion, new Vector2(Position.X-10,Position.Y-15), Exploser(), Color.White);
            }
        }

    }
}
