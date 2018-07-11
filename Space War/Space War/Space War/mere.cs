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
    class Mere
    {
        public Texture2D Texture;

        protected float Vitesse;

        protected Vector2 Position;

        protected Vector2 Direction;

        public bool isVisible;//Permet de savoir si l'élément est visible sur l'écran 

        public virtual void Update(Personnages cible1,GameTime gametime)
        {
            this.Agir(cible1);
        }

        public virtual void Draw(SpriteBatch spritebatch, GameTime gametime)
        {
            if (isVisible == true)
            {
                spritebatch.Draw(Texture, Position, Color.White);
            }

        }

        public virtual void Apparaitre(Vector2 _Position)//Permet de faire apparaître l'élément à une certaine position
        {
            Position = _Position;
            isVisible = true; 
        }

        protected virtual void Disparaitre()//Permet de faire disparaître l'élément
        {
            isVisible = false;
            Position = new Vector2(-100,0);
        }

        public virtual void Agir(Personnages cible1)//Fais agir et bouger l'élément si celui-ci est visible
        {
            Position += Direction * Vitesse;
        }

        protected virtual bool Collisionne(Mere objet)//A revoir tres vite
        {
            if(objet.Texture.Height == 213 )
            return (new Rectangle((int)Position.X,(int)Position.Y,Texture.Width,Texture.Height).Intersects(new Rectangle((int)objet.Position.X,(int)objet.Position.Y,objet.Texture.Width/3,objet.Texture.Height/3)));   
            else
            return (new Rectangle((int)Position.X,(int)Position.Y,Texture.Width,Texture.Height).Intersects(new Rectangle((int)objet.Position.X,(int)objet.Position.Y,objet.Texture.Width,objet.Texture.Height)));   

        }

        protected virtual bool EstSorti(int hauteurEcran, int largeurEcran)
        {
            return (Position.X < 0 || Position.X > largeurEcran - Texture.Width || Position.Y > hauteurEcran - Texture.Width || Position.Y < 0);
        }

    }
}
