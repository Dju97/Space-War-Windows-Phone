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
using Microsoft.Devices.Sensors;
using Space_War.Managers;

namespace Space_War.Screens
{
    class GameScreen
    {
        
        private static GameScreen instance;
        //PERSONNAGES
        Héros Heros;
        Soucoupe ennemi;
        SoucoupeGauche ennemi2;
        SoucoupeDroite ennemi3;
        EnsembleSoucoupes ensemble1;
        List<Personnages> ennemis = new List<Personnages>();

        //GAME
        int score;
        Accelerometer accelerometre = new Accelerometer();
        Vector3 accelreading;
        Rectangle fenêtre;

        //backgrounds
        ScrollingBackground background1;
        ScrollingBackground background2;

        private GameScreen(Rectangle fenetre)
        {
            fenêtre = fenetre;
            Heros = new Héros();
            ennemi = new Soucoupe(fenêtre);
            ennemi2 = new SoucoupeGauche(fenêtre);
            ennemi3 = new SoucoupeDroite(fenêtre);
            ensemble1 = new EnsembleSoucoupes(ennemi, ennemi2, ennemi3, fenêtre, "soucoupe");
            accelerometre.CurrentValueChanged += accelerometre_CurrentValueChanged;
        }

        public static GameScreen getInstance(Rectangle fenetre)
        {
            if (instance == null)
                instance = new GameScreen(fenetre);
            return instance;
        }

        void accelerometre_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            accelreading.X = (float)e.SensorReading.Acceleration.X;
        }

        public virtual void Initialize()
        {
            // TODO: Ajouter votre logique d’initialisation ici
            Heros.InitializeHéros(fenêtre);
            ensemble1.Initialize();
            ensemble1.Apparaitre(new Vector2(fenêtre.Width / 2, 5), ennemis);
            accelerometre.Start();
            score = 0;
            background1 = new ScrollingBackground("fond1", MenuScreen.getInstance(fenêtre).background1.rectangle, 10);
            background2 = new ScrollingBackground("fond2", MenuScreen.getInstance(fenêtre).background2.rectangle, 10);
        }

        public virtual void UnloadContent()
        {
            accelerometre.Stop();
            ennemis.Clear();
        }

        public virtual void Update(GameTime gameTime)
        {
            /******************************CODE POUR LE HEROS***************************
             ***************************************************************************/

            if (Heros.isVisible)
            {
                score += 1;
            }
            else
            {
                ScreenManager.getInstance(fenêtre).ChangeCurrentScreen(ScreenManager.Screens.Menu);
            }
            Heros.UpdateHeros(ennemis, accelreading.X, gameTime);

            /******************************CODE POUR LES ENNEMIS************************
             ***************************************************************************/

            foreach (Personnages perso in ennemis)
            {
                perso.Update(Heros, gameTime);
            }

            for (int i = ennemis.Count - 1; i >= 0; i--)
            { 
                if (!ennemis[i].isVisible && !ennemis[i].explose && !ennemis[i].ArmePerso.isVisible)
                {
                    ennemis.RemoveAt(i);
                    score += 100;
                }

            }
            /******************************CODE POUR LE BACKGROUND*********************
            ***************************************************************************/

            if (background1.rectangle.Y > fenêtre.Height)
                background1.rectangle.Y = background2.rectangle.Y - background1.texture.Height;
            if (background2.rectangle.Y > fenêtre.Height)
                background2.rectangle.Y = background1.rectangle.Y - background2.texture.Height;

            background1.Update();
            background2.Update();

            /******************************CODE POUR LE TEST***************************
            ***************************************************************************/
            if (ennemis.Count == 0)
            {
                ensemble1.Apparaitre(Vector2.Zero, ennemis);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            /******************************CODE POUR LE BACKGROUND*********************
            ***************************************************************************/
            background1.Draw(spriteBatch);
            background2.Draw(spriteBatch);

            /******************************CODE POUR LE HEROS***************************
             ***************************************************************************/
            Heros.Draw(spriteBatch, gameTime);
            
            for (int i = 0; i < Heros.NbreDeVies; i++)
            {
                spriteBatch.Draw(Content_Manager.getInstance().Textures["vie"], new Vector2(375 - (i + 1) * 30, 10), Color.White);
            }

            /******************************CODE POUR LES ENNEMIS************************
             ***************************************************************************/

            foreach (Personnages perso in ennemis)
            {
                perso.Draw(spriteBatch, gameTime);
            }
            spriteBatch.DrawString(Content_Manager.getInstance().Polices["PoliceScore"], Convert.ToString(score), new Vector2(400, 0), Color.Orange);
            
           
            
        }

    }
}
