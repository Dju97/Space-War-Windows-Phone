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
    class SoucoupeDroite : Personnages
    {
        public bool avance;
        //Contructeur de la classe, on passe en paramètre la taille et la largeur de l'ecran

        public virtual void Initialize(Armes armePerso)
        {
            tour = 0;
            NbreDeViesDefaut = 3;
            NbreDeVies = NbreDeViesDefaut;
            FréquenceTir = 75;
            Direction = Vector2.Zero;
            ArmePerso = armePerso;
            Vitesse = 5;
            avance = true;
        }

        public override void Agir(Personnages cible1)
        {
        }
    }
  }

