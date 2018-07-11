using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_War.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_War
{
    class ScrollingBackground
    {
        public Texture2D texture;
        public Rectangle rectangle;
        int Vitesse;

        public ScrollingBackground(String nomtexture, Rectangle newRectangle, int vitesse)
        {
            texture = Content_Manager.getInstance().Textures[nomtexture];
            rectangle = newRectangle;
            Vitesse = vitesse;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public void Update()
        {
            rectangle.Y += Vitesse;       
        }
    }
}
