using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace OOP_Project
{
    class Background : MainSprite
    {

        public Background(string Path, float position_y)
        {
            _initialize(new Vector2(0, position_y));
            texturesCollection.Add(Game1.content.Load<Texture2D>(Path));
            StandardImgFrame = 0;
        }

        public void Update() //scrolling
        {
            cordy += 4;
            if (cordy >= 200)
                cordy = -1015;
        }
        public void Draw(int scale)
        {
            Game1.spriteBatch.Draw(texturesCollection[StandardImgFrame], new Rectangle((int)cordx, (int)cordy, Game1.graphicsdevice.Viewport.Width, Game1.graphicsdevice.Viewport.Height + scale), Color.White);
        }
    }
}
