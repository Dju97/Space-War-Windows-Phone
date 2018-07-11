using Microsoft.Xna.Framework;
using Space_War.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_War
{
    class Armes:Mere
    {
        public int Degats;
        protected int hauteurEcran;
        protected int largeurEcran;       

        public virtual void Toucher(Personnages cible)
        {
            cible.RecevoirDegats(Degats);
            this.Disparaitre();
        }

        public override void Agir(Personnages cible1)
        {
            base.Agir(cible1);
            if (EstSorti(hauteurEcran, largeurEcran))
                this.Disparaitre();
            if (Collisionne(cible1))
                this.Toucher(cible1);
        }

    }
}
