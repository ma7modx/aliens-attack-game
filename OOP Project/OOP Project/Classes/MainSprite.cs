using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System.IO;
namespace OOP_Project
{
    public class MainSprite
    {

        public double cordx;
        public double cordy;
        public double velocity_x { get; set; }
        public double velocity_y { get; set; }

        public int height { get; set; }
        public int width { get; set; }

        public int StandardImgFrame { get; set; }// num of frames
        public int imageframes { get; set; }// starting frame 
        public List<Texture2D> texturesCollection = new List<Texture2D>();// image frames

        public bool Exist { get; set; }
        public int Health { get; set; }


        public void _initialize(string img, Vector2 coordinates, float velocity_x, float velocity_y)
        {
            this.velocity_x = velocity_x;
            this.velocity_y = velocity_y;
            cordx = coordinates.X;
            cordy = coordinates.Y;
            texturesCollection.Add(Game1.content.Load<Texture2D>(img));
        }
        public void _initialize(Vector2 coordinates)
        {
            velocity_x = 0;
            velocity_y = 0;
            cordx = coordinates.X;
            cordy = coordinates.Y;

        }
        public void _initialize(Vector2 coordinates, float velocity_x, float velocity_y, int imageframes, int StandardImgFrame)
        {
            this.imageframes = imageframes; // num of frames
            this.StandardImgFrame = StandardImgFrame; // starting frame
            this.velocity_x = velocity_x;
            this.velocity_y = velocity_y;
            cordx = coordinates.X;
            cordy = coordinates.Y;
        }

        public int limitBounders() // dont exceed screen
        {
            if (cordx >= Game1.graphicsdevice.Viewport.Width - width) // width of the sprite 
            {
                cordx = Game1.graphicsdevice.Viewport.Width - width;
              
            }
            if (cordy >= Game1.graphicsdevice.Viewport.Height - height) // height ...
            {
                cordy = Game1.graphicsdevice.Viewport.Height - height;
               
            }
            if (cordx <= 0)
            {
                cordx = 0;
                
            }
            if (cordy <= 0)
            {
                cordy = 0;
              
            }
            return 0;
        }
        public void _Draw() // draw wthout rotation
        {
            limitBounders();

            Game1.spriteBatch.Draw(texturesCollection[StandardImgFrame], new Rectangle((int)cordx, (int)cordy, width, height), Color.White);
        }

        private double Lzawya = 0;
        public void _Draw(Vector2 Origin, double rotatingSpeed, float scale, bool DoRotation) // draw wth rotation
        {
            //  limitBounders();
            Rectangle sourceRectangle = new Rectangle(0, 0, texturesCollection[StandardImgFrame].Width, texturesCollection[StandardImgFrame].Height);
            // Game1.spriteBatch.Draw(texturesCollection[StandardImgFrame], coordinates, sourceRectangle, Color.White, rotating, Origin, 300, SpriteEffects.None, 1);

            if (DoRotation)
            {
                Lzawya += rotatingSpeed;
                Events.Rotate1(ref cordx, ref cordy, Lzawya, new Vector2(2f, 1f));
            }

            // Game1.spriteBatch.Draw(texturesCollection[StandardImgFrame], coordinates, sourceRectangle, Color.White, angle, Origin, scale, SpriteEffects.None , 1);
            Game1.spriteBatch.Draw(texturesCollection[StandardImgFrame], new Vector2((float)cordx, (float)cordy), Color.White);
        }


    }
}
