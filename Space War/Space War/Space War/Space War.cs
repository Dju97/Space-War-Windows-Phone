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

namespace Space_War
{
    /// <summary>
    /// Type principal pour votre jeu
    /// </summary>
    public class SpaceWar : Microsoft.Xna.Framework.Game
    {
        //FIELDS
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle fenêtre;

        //Managers

        public SpaceWar()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;

            fenêtre = Window.ClientBounds;

            // La fréquence d’image est de 30 i/s pour le Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Augmenter la durée de la batterie sous verrouillage.
            InactiveSleepTime = TimeSpan.FromSeconds(1);        
        }
        
        /// <summary>
        /// Permet au jeu d’effectuer l’initialisation nécessaire pour l’exécution.
        /// Il peut faire appel aux services et charger tout contenu
        /// non graphique. Calling base.Initialize énumère les composants
        /// et les initialise.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Ajouter votre logique d’initialisation ici
            base.Initialize();
        }

        /// <summary>
        /// LoadContent est appelé une fois par partie. Emplacement de chargement
        /// de tout votre contenu.
        /// </summary>
        protected override void LoadContent()
        {
            // Créer un SpriteBatch, qui peut être utilisé pour dessiner des textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: utilisez this.Content pour charger votre contenu de jeu ici
            Content_Manager.getInstance().LoadTextures(Content);

        }

        /// <summary>
        /// UnloadContent est appelé une fois par partie. Emplacement de déchargement
        /// de tout votre contenu.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Déchargez le contenu non ContentManager ici
        }

        /// <summary>
        /// Permet au jeu d’exécuter la logique de mise à jour du monde,
        /// de vérifier les collisions, de gérer les entrées et de lire l’audio.
        /// </summary>
        /// <param name="gameTime">Fournit un aperçu des valeurs de temps.</param>
        protected override void Update(GameTime gameTime)
        {
            // Permet au jeu de se fermer
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                ScreenManager.getInstance(fenêtre).ChangeCurrentScreen(ScreenManager.Screens.Menu);

            // TODO: Ajoutez votre logique de mise à jour ici
            base.Update(gameTime);
            ScreenManager.getInstance(fenêtre).Update(gameTime);
           
            //Replay
        }

        /// <summary>
        /// Appelé quand le jeu doit se dessiner.
        /// </summary>      
        /// <param name="gameTime">Fournit un aperçu des valeurs de temps.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
            spriteBatch.Begin();
            ScreenManager.getInstance(fenêtre).Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }

      }
}
