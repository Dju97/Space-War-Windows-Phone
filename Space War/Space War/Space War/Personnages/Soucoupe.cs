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

namespace Space_War
{
    class Soucoupe:Personnages
    {
        private int hauteurEcran;
        private int largeurEcran;
        private int hauteurDeplacement;
        //Contructeur de la classe, on passe en paramètre la taille et la largeur de l'ecran

        public Soucoupe(Rectangle fenetre)
        {
            hauteurEcran = fenetre.Height;
            largeurEcran = fenetre.Width;
        }
        public virtual void Initialize(Armes armePerso)
        {
            tour = 0;
            NbreDeViesDefaut = 3;
            NbreDeVies = NbreDeViesDefaut;
            FréquenceTir = 75;
            Direction = Vector2.Zero;
            ArmePerso = armePerso;
            Vitesse = 5;
            explose = false;
        }

        public virtual void Apparaitre(Vector2 Position, List<Personnages> ennemis, int HauteurDeplacement)
        {
            base.Apparaitre(Position, ennemis);
            hauteurDeplacement = HauteurDeplacement;
        }

        public override void Agir(Personnages cible1)
        {
            if (Position.Y < hauteurEcran / hauteurDeplacement)
                Direction = Vector2.UnitY;
            if (Position.Y > hauteurEcran / hauteurDeplacement)
            {
                Position = new Vector2(largeurEcran / 2 - Texture.Width / 2, hauteurEcran / hauteurDeplacement);
                Direction = new Vector2(-1, 0);
            }
            if (Position.Y == hauteurEcran / hauteurDeplacement)
            {
                if (Position.X < 20 + Texture.Width + 15)
                {
                    Direction = Vector2.UnitX;
                }
                if (Position.X > largeurEcran - 2*Texture.Width - 35)
                    Direction = -Vector2.UnitX;
            }
            base.Agir(cible1);
             

        }
    }
}
