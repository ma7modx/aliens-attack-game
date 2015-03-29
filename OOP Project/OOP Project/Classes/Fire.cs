/*
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
namespace OOP_Project
{
    public class Fire : MainSprite
    {
        //
        

        public Fire(string image, Vector2 coordinates, float velocity_x, float velocity_y)
        {
            Exist = true;
            _initialize(coordinates, velocity_x, velocity_y, 1, 0);
            texturesCollection.Add(Game1.content.Load<Texture2D>(image));
        }
        public void Update()
        {
            cordx += velocity_x;
            cordy -= velocity_y;

        }

        public void Draw()
        {
            width = texturesCollection[StandardImgFrame].Width;
            height = texturesCollection[StandardImgFrame].Height;
            _Draw();
        }

        private bool OutOfBorders(int width, int height)
        {
            if (cordx >= Game1.graphicsdevice.Viewport.Width - width) // width of the sprite 
                return true;
            if (cordy >= Game1.graphicsdevice.Viewport.Height - height) // height ...
                return true;
            if (cordx <= 0)
                return true;
            if (cordy <= 0)
                return true;
            return false;
        }

        public static void FiresUpdate(ref List<Fire> bullets, MainPlane versus)
        {
         
            for (int x = 0; x < bullets.Count; ++x)
            {
                Fire fire = bullets[x];
              
                if (Events.pixelCollesion(versus.texturesCollection[versus.StandardImgFrame], fire.texturesCollection[fire.StandardImgFrame], new Vector2((float)versus.cordx, (float)versus.cordy), new Vector2((float)fire.cordx, (float)fire.cordy)))
                {
                    fire.Exist = false;
                   // Events.health -= 20;

                }
                if (fire.OutOfBorders(fire.width, fire.height) || !fire.Exist)
                {
                    bullets.Remove(fire);
                    fire.Exist = false;
                    x--;
                }
                else
                    fire.Update();
            }



        }

        public static void FiresUpdate(ref List<Fire> bullets, List<Enemies> versus)
        {
            for (int x = 0; x < bullets.Count; ++x)
            {
                Fire fire = bullets[x];
                
                foreach (Enemies q in versus)
                    if (Events.pixelCollesion(q.texturesCollection[q.StandardImgFrame], fire.texturesCollection[fire.StandardImgFrame], new Vector2((float)q.cordx, (float)q.cordy), new Vector2((float)fire.cordx, (float)fire.cordy)))
                    {
                        fire.Exist = false;

                        Events.score++;
                        q.enemhealth -= 30;

                        if (q.enemhealth <= 0)
                        {
                            q.Exist = false;
                            Events.score += 2;
                        }
                    }

                if (fire.OutOfBorders(fire.width, fire.height) || !fire.Exist)
                {

                    bullets.Remove(fire);
                    fire.Exist = false;
                    
                    Events.loadContent();
                    Events.update();
                    x--;
                }
                else
                    fire.Update();

            }
        }

        public static void PlaneVSEnemy(ref List<Enemies> versus)
        {
            for (int x = 0; x < versus.Count; ++x)
            {

                Enemies q = versus[x];
                if (Events.pixelCollesion(q.texturesCollection[q.StandardImgFrame], Game1.Airplane.texturesCollection[Game1.Airplane.StandardImgFrame], new Vector2((float)q.cordx, (float)q.cordy), new Vector2((float)Game1.Airplane.cordx, (float)Game1.Airplane.cordy)))
                {
                    q.Exist = false;
                  //  Events.health -= 20;
                }
                if (q.DeleteIt)
                {
                    versus.RemoveAt(x);
                    x--;
                }
            }
        }

        public static void FiresDraw(List<Fire> bullets)
        {
            foreach (Fire i in bullets)
                if (i.Exist)
                    i.Draw();
        }
    }
}
*/


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
namespace OOP_Project
{
    public class Fire : MainSprite
    {
        public Fire(string image, Vector2 coordinates, float velocity_x, float velocity_y)
        {
            Exist = true;
            _initialize(coordinates, velocity_x, velocity_y, 1, 0);
            texturesCollection.Add(Game1.content.Load<Texture2D>(image));
        }
        public void Update()
        {
            cordx += velocity_x;
            cordy -= velocity_y;
        }

        public void Draw()
        {
            width = texturesCollection[StandardImgFrame].Width;
            height = texturesCollection[StandardImgFrame].Height;
            _Draw();
        }

        private bool OutOfBorders(int width, int height)// exceed the screen
        {
            if (cordx >= Game1.graphicsdevice.Viewport.Width - width) // width of the sprite 
                return true;
            if (cordy >= Game1.graphicsdevice.Viewport.Height - height) // height ...
                return true;

            if (cordy <= 0)
                return true;
            return false;
        }

        public static void FiresUpdate(ref List<Fire> bullets, MainPlane versus)// collision between all anemies fires and Plane
        {
            for (int x = 0; x < bullets.Count; ++x)
            {
                Fire fire = bullets[x];

                if (Events.pixelCollesion(versus.texturesCollection[versus.StandardImgFrame], fire.texturesCollection[fire.StandardImgFrame], new Vector2((float)versus.cordx, (float)versus.cordy), new Vector2((float)fire.cordx, (float)fire.cordy)))
                {
                    fire.Exist = false;
                    Events.health -= 20;
                }

                if (fire.OutOfBorders(fire.width, fire.height) || !fire.Exist) // delete
                {
                    bullets.Remove(fire);
                    fire.Exist = false;
                    x--;
                }
                else // update
                    fire.Update();
            }

        }

        public static void FiresUpdate(ref List<Fire> bullets, List<Enemies> versus)// collision between plane fires and all enemies
        {
            for (int x = 0; x < bullets.Count; ++x)
            {
                Fire fire = bullets[x]; // plane's fires

                foreach (Enemies q in versus) // enemies
                    if (Events.pixelCollesion(q.texturesCollection[q.StandardImgFrame], fire.texturesCollection[fire.StandardImgFrame], new Vector2((float)q.cordx, (float)q.cordy), new Vector2((float)fire.cordx, (float)fire.cordy)))
                    {
                        fire.Exist = false;

                        Events.score++;
                        q.enemhealth -= 30;

                        if (q.enemhealth <= 0)
                        {
                            q.Exist = false;
                            Events.score += 2;
                        }
                    }

                if (fire.OutOfBorders(fire.width, fire.height) || !fire.Exist) // delete fire
                {
                    bullets.Remove(fire);
                    fire.Exist = false;
                    x--;
                }
                else // update
                    fire.Update();
            }
        }

        public static void PlaneVSEnemy(ref List<Enemies> versus) // collision plane wth enemies
        {
            for (int x = 0; x < versus.Count; ++x)
            {
                Enemies q = versus[x];
                if (Events.pixelCollesion(q.texturesCollection[q.StandardImgFrame], Game1.Airplane.texturesCollection[Game1.Airplane.StandardImgFrame], new Vector2((float)q.cordx, (float)q.cordy), new Vector2((float)Game1.Airplane.cordx, (float)Game1.Airplane.cordy)))
                {
                    q.Exist = false;
                    Events.health -= 20;
                }

                if (q.DeleteIt)
                {
                    versus.RemoveAt(x);
                    x--;
                }
                // there's update in the other classes
            }
        }

        public static void FiresDraw(List<Fire> bullets)
        {
            foreach (Fire i in bullets) // draw each bullet
                if (i.Exist)
                    i.Draw();
        }
    }
}
