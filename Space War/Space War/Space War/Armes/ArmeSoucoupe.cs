using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Space_War.Managers;

namespace Space_War
{
    class ArmeSoucoupe:Armes
    {
        public ArmeSoucoupe(String nomTexture,Rectangle fenetre)
        {
            Texture = Content_Manager.getInstance().Textures[nomTexture];
            hauteurEcran = fenetre.Height;
            largeurEcran = fenetre.Width;
        }


        public virtual void Initialize()
        {
            Direction = new Vector2(0, 1);
            Vitesse = 13;
            Degats = 1;
        }
    }
}
