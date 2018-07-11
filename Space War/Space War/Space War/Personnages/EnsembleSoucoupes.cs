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
    class EnsembleSoucoupes:Personnages
    {
        private Soucoupe soucoupeCentre;
        private SoucoupeGauche soucoupeGauche;
        private SoucoupeDroite soucoupeDroite;
        private int hauteurEcran;
        private int largeurEcran;
        Rectangle fenêtre;
        private Vector2 positionDepart;
        private int hauteurDeplacement;
        Random random = new Random();
        ArmeSoucoupe[] armesSoucoupes = new ArmeSoucoupe[3];


        public EnsembleSoucoupes(Soucoupe soucoupemilieu, SoucoupeGauche soucoupegauche,SoucoupeDroite soucoupedroite,Rectangle fenetre, String nomTexture)
        {
           
            soucoupeCentre = soucoupemilieu;
            soucoupeGauche = soucoupegauche;
            soucoupeDroite = soucoupedroite;
            hauteurEcran = fenetre.Height;
            largeurEcran = fenetre.Width;
            fenêtre = fenetre;
            soucoupeCentre.Texture = Content_Manager.getInstance().Textures[nomTexture];
            soucoupeDroite.Texture = Content_Manager.getInstance().Textures[nomTexture];
            soucoupeGauche.Texture = Content_Manager.getInstance().Textures[nomTexture];
        }

        public override void Apparaitre(Vector2 position, List<Personnages> ennemis)
        {
            hauteurDeplacement = random.Next(2, 5);
            positionDepart = new Vector2(largeurEcran / 2 - soucoupeCentre.Texture.Width / 2, 5);
            soucoupeCentre.Apparaitre(new Vector2(positionDepart.X, positionDepart.Y - soucoupeCentre.Texture.Height - 5),ennemis,hauteurDeplacement);
            soucoupeGauche.Apparaitre(positionDepart,ennemis,hauteurDeplacement);
            soucoupeDroite.Apparaitre(new Vector2(positionDepart.X, positionDepart.Y - 2*soucoupeCentre.Texture.Height - 2*5), ennemis,hauteurDeplacement);
        }

        public virtual void Initialize()
        {
           
            for (int i = 0; i < armesSoucoupes.Length; i++)
            { 
                armesSoucoupes[i] = new ArmeSoucoupe("armeEnnemi", fenêtre);
                armesSoucoupes[i].Initialize();
               
            }
            soucoupeCentre.Initialize(armesSoucoupes[0]);
            soucoupeGauche.Initialize(armesSoucoupes[1]);
            soucoupeDroite.Initialize(armesSoucoupes[2]);
        }
    }
}
