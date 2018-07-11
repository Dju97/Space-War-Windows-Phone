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
    class ArmeBaseHéros:Armes
    {
        //Contructeur de la classe, on passe en paramètre la taille et la largeur de l'ecran

        public ArmeBaseHéros(Rectangle fenetre, String nomTexture)
        {
            hauteurEcran = fenetre.Height;
            largeurEcran = fenetre.Width;
            Texture = Content_Manager.getInstance().Textures[nomTexture];
            ArmeBaseHéros[] tableauArme = new ArmeBaseHéros[5];
        }

        public virtual void AgirHéros(List<Personnages> cibles)
        {
            Position += Direction * Vitesse;
            if (EstSorti(hauteurEcran,largeurEcran))
                    this.Disparaitre();
            foreach (Personnages cible in cibles)
            {
                if (Collisionne(cible))
                {
                    Toucher(cible);
                }
            }

        }

        public virtual void Initialize()
        {
            isVisible = false;
            Direction = new Vector2(0,-1);
            Vitesse = 10;
            Degats = 1;
        }
    }
}
