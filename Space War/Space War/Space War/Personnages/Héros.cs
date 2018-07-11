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
    class Héros:Personnages
    {
        private TouchCollection touchesold = new TouchCollection();
        int FrameColumn;
        int FrameLigne;
        int screenWidth;
        ArmeBaseHéros[] armesHéros = new ArmeBaseHéros[15]; 

        public Héros()
        {
            Texture = Content_Manager.getInstance().Textures["Heros"];
        }

        public virtual void InitializeHéros(Rectangle fenetre)
        {
            for (int i = 0; i < armesHéros.Length; i++)
            {
                armesHéros[i] = new ArmeBaseHéros(fenetre, "armeHeros");
                armesHéros[i].Initialize();             
                
            }
            Direction = new Vector2(1,0);
            NbreDeViesDefaut = 3;
            NbreDeVies = NbreDeViesDefaut;
            Position = new Vector2(screenWidth/2-116/2,fenetre.Height-71  );
            isVisible = true;
            FrameColumn = 2;
            screenWidth = fenetre.Width;
            touchesold = TouchPanel.GetState();

        }

        public virtual void UpdateHeros(List<Personnages> cibles, float accelreading, GameTime gameTime)
        {
            AgirHéros(cibles,accelreading);
        }

        private void TirerHéros(ArmeBaseHéros armeperso)
        {
            armeperso.Apparaitre(new Vector2(Position.X+116/2,Position.Y));
        }

        public virtual void AgirHéros(List<Personnages> cibles, float accelreading)
        {
            
            TouchCollection touches = TouchPanel.GetState();
            if (touches.Count > touchesold.Count)
            {

                for (int i = (armesHéros.Length-1); i >= 0; i--)
                {
                    if (i != 0 && armesHéros[i - 1].isVisible == true && armesHéros[i].isVisible == false)
                    {
                        this.TirerHéros(armesHéros[i]);
                        break;
                    }
                    else if (i == 0 && armesHéros[i].isVisible == false)
                    {
                        this.TirerHéros(armesHéros[i]);
                        break;
                    }
                }

            }
            touchesold = touches;

            for (int i = 0; i < armesHéros.Length; i++)
            {
                if (armesHéros[i].isVisible)
                {
                    armesHéros[i].AgirHéros(cibles);
                }
                    
            }

            if (accelreading > 0)
            {
                Direction = new Vector2(1, 0);
                if (Position.X >= screenWidth-116)
                {
                    Direction = Vector2.Zero;
                    Position = new Vector2(screenWidth-116,Position.Y);
                    FrameColumn = 1;
                    FrameLigne = 1;
                }

                else if (accelreading > 0.3)
                {
                    FrameLigne = 3;
                    if (accelreading < 0.4)
                        FrameColumn = 1;
                    else if (accelreading > 0.4 && accelreading < 0.5)
                        FrameColumn = 2;
                    else
                        FrameColumn = 3;
                }
                else
                {
                    FrameLigne = 1;
                    FrameColumn = 1;
                }
                   
                 
            }

            else if (accelreading < 0)
            {
                Direction = new Vector2(-1, 0);
                if (Position.X <= 0)
                {
                    Direction = Vector2.Zero;
                    FrameColumn = 1;
                    FrameLigne = 1;
                    Position = new Vector2(0, Position.Y);
                }

                else if (accelreading < -0.3)
                {
                    FrameLigne = 2;
                    if (accelreading > -0.4)
                        FrameColumn = 1;
                    else if (accelreading < 0.4 && accelreading > 0.5)
                        FrameColumn = 2;
                    else
                        FrameColumn = 3;
                }
                else
                {
                    FrameLigne = 1;
                    FrameColumn = 1;
                }

            }

            else//à voir si il faut remplacer par compris dans [-0.1;0.1]
            {
                Direction = Vector2.Zero;
            }

            Vitesse = Math.Abs(30*accelreading);
            Position += Direction * Vitesse;
        }

        public override void Draw(SpriteBatch spritebatch, GameTime gametime)
        {
            if (isVisible)
            {
                spritebatch.Draw(Texture, Position, new Rectangle((FrameColumn - 1) * (Texture.Width / 3), (FrameLigne - 1) * (Texture.Height / 3), Texture.Width / 3, Texture.Height / 3), Color.White);
            }
            for (int i = 0; i < armesHéros.Length; i++)
            {
                armesHéros[i].Draw(spritebatch, gametime);
            }

        }

        protected override void Disparaitre()
        {
            isVisible = false;
            Position = new Vector2(-100, 0);
        }
    }
}
