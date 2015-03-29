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
    public class Enemies : MainSprite
    {
        //
        
        public  int enemhealth=30;
        public bool DeleteIt { get; set; }
       
        Random fireDelay { get; set; }
        Vector2 GotoPosition { get; set; }
        List<Fire> bullets;
        public Vector2 vectOfEnemies;
        Random rand = new Random();
        int fireeDelay = 20;
        public float omlzawya = 0;
        public Enemies(string image, Vector2 coordinates, float velocity_x, float velocity_y, Vector2 GotoPosition)
        {
            DeleteIt = false;
            Exist = true;
            this.GotoPosition = GotoPosition;
            fireeDelay = rand.Next(100, 1000);
            _initialize(coordinates, velocity_x, velocity_y, 2, 0);
            texturesCollection.Add(Game1.content.Load<Texture2D>(image));
            texturesCollection.Add(Game1.content.Load<Texture2D>("Images//xxxx"));
            bullets = new List<Fire>();
        }

        bool DoRotation = false;
        public void Update(float IncInAngle, float SpeedOfSeeking)
        {

            velocity_y = SpeedOfSeeking;
            velocity_x = SpeedOfSeeking;
            float toolmosallas = Math.Abs((float)(cordx - GotoPosition.X));
            float ardmosallas = Math.Abs((float)(cordy - GotoPosition.Y));
          
            if ((int)toolmosallas <= SpeedOfSeeking && (int)ardmosallas <= SpeedOfSeeking) // rotate when ur reach ur position
            {
                DoRotation = true;
            }
            else if (toolmosallas == 0)
            {
                cordx += velocity_x;
            }
            else if (ardmosallas == 0)
            {
                cordy += velocity_y;
            }
            else if (!(cordx == GotoPosition.X || cordy == GotoPosition.Y) && DoRotation == false)
            {
                if ((toolmosallas) < (ardmosallas))
                {
                    if (!(cordx == GotoPosition.X))
                    {
                        if (cordx < GotoPosition.X)
                            cordx += (toolmosallas / ardmosallas) * velocity_x;
                        else
                            cordx -= (toolmosallas / ardmosallas) * velocity_x;
                    }

                    if (!(cordy == GotoPosition.Y))
                    {
                        if (cordy < GotoPosition.Y)
                            cordy += velocity_y;
                        else
                            cordy -= velocity_y;
                    }

                }
                else
                {
                    if (!(cordx == GotoPosition.X))
                    {
                        if (cordx < GotoPosition.X)
                            cordx += velocity_x;
                        else
                            cordx -= velocity_x;
                    }

                    if (!(cordy == GotoPosition.Y))
                    {
                        if (cordy < GotoPosition.Y)
                            cordy += (ardmosallas / toolmosallas) * velocity_y;
                        else
                            cordy -= (ardmosallas / toolmosallas) * velocity_y;
                    }

                }
            }

            KeyboardState key = Keyboard.GetState();

            if (!Exist)
                StandardImgFrame = 1;
            fireeDelay--;
            if ((int)fireeDelay <= 0 && Exist)
            {
                bullets.Add(new Fire("Images//2oo", new Vector2((float)cordx+30, (float)cordy), 0, -7)); // enemies fire image
                fireeDelay = rand.Next(100, 1000);

            }
            Fire.FiresUpdate(ref bullets, Game1.Airplane);

            if (bullets.Count <= 0 && Exist == false)
                DeleteIt = true;
        }

        // centre of rotation , hw fast thy're rotating
        public void Draw(Vector2 Origin, double rotatingSpeed)
        {
            width = texturesCollection[StandardImgFrame].Width;
            height = texturesCollection[StandardImgFrame].Height;

            _Draw(Origin, rotatingSpeed, 1, DoRotation);


            Fire.FiresDraw(bullets);
        }
       
 *
        double Lzawya;
        double GetLzawya(Vector2 pos, Vector2 org)
        {
            if ((org.X - pos.X) != 0)
                Lzawya = ((double)(Math.Atan((double)((pos.Y - org.Y) / (pos.X - org.X)))));
            else
                Lzawya = 0;
            Lzawya = Math.Abs(Lzawya);

            Lzawya = MathHelper.ToDegrees((float)Lzawya);
            if (pos.X == org.X && pos.Y < org.Y) // 7war tzbeet l zawya anhe rob3 :P
                Lzawya += 90;
            else if (pos.X < org.X && pos.Y < org.Y)
            {
                Lzawya = 90 - Lzawya;
                Lzawya += 90;
            }
            else if (pos.X < org.X && pos.Y == org.Y)
                Lzawya += 180;
            else if (pos.X < org.X && pos.Y > org.Y)
                Lzawya += 180;

            else if (pos.X == org.X && pos.Y > org.Y)
            {
                Lzawya += 270;
            }
            else if (pos.X > org.X && pos.Y > org.Y)
            {
                Lzawya = 90 - Lzawya;
                Lzawya += 270;
            }
            return Lzawya = MathHelper.ToRadians((float)Lzawya);
        }

        public void Avoid(Vector2 org, int radius, bool AVOIDNESS)
        {

            double ZAWYA = GetLzawya(new Vector2((float)cordx, (float)cordy), new Vector2((float)org.X, (float)org.Y));

            double rate = (radius - Math.Sqrt(((cordx - org.X) * (cordx - org.X)) + ((cordy - org.Y) * (cordy - org.Y)))) / radius;
            if (AVOIDNESS) // avoid
            {
                velocity_x += (0.8 * rate * Math.Cos(ZAWYA)); // Acceleration 
                velocity_y += (0.8 * -rate * Math.Sin(ZAWYA));
            }
            else // get closer
            {
                velocity_x -= (0.8 * -rate * Math.Cos(ZAWYA));
                velocity_y -= (0.8 * rate * Math.Sin(ZAWYA));
            }

        }

        bool whichin = false; // to reset the velocity
        public void Update(Fire fire)
        {
            // Allows the game to exit
            // velocity_x = 0; velocity_y = 0;
            int radius = 90;

            if (fire != null) // there is no fires
            {
                if (Math.Sqrt(((cordx - fire.cordx) * (cordx - fire.cordx)) + ((cordy - fire.cordy) * (cordy - fire.cordy))) <= radius) // int the range
                {
                    if (whichin == true)
                    {
                        velocity_x = cordx < fire.cordx ? -5 : 5; velocity_y = cordy < fire.cordy ? -5 : 5; //reset its max vel. according to plane's position
                    }
                    whichin = false;
                    // rate cosidered 2 b the acceleration

                    Avoid(new Vector2((float)fire.cordx, (float)fire.cordy), radius, true); // enemy avoids plane

                    if (Math.Abs(velocity_x) > 5) // dont exceed max vel
                        velocity_x = velocity_x < 0 ? -5 : 5;
                    if (Math.Abs(velocity_y) > 5)
                        velocity_y = velocity_y < 0 ? -5 : 5;

                    cordx += (float)velocity_x; cordy += (float)velocity_y; // update position


                }
            }
            else
            {
                whichin = true;
                radius = 80;
                Avoid(new Vector2((float)Game1.Airplane.cordx, (float)Game1.Airplane.cordy - 400), radius, false); // get closer to plane's position 

                if (Math.Abs(velocity_x) > 5)// dont exceed max vel
                    velocity_x = velocity_x < 0 ? -5 : 5;
                if (Math.Abs(velocity_y) > 5)
                    velocity_y = velocity_y < 0 ? -5 : 5;

                cordx += (float)velocity_x; cordy += (float)velocity_y; // update it
            }

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
    public class Enemies : MainSprite
    {

        public int enemhealth = 30;
        public bool DeleteIt { get; set; }
        Random fireDelay { get; set; }
        Vector2 GotoPosition { get; set; }
        List<Fire> bullets;
        public Vector2 vectOfEnemies;
        Random rand = new Random();
        int fireeDelay = 20;
        public Enemies(string image, Vector2 coordinates, float velocity_x, float velocity_y, Vector2 GotoPosition)
        {
            DeleteIt = false; // !exist if he has a fire , delete when its fire is deleted 
            Exist = true;
            this.GotoPosition = GotoPosition; // seek point
            fireeDelay = rand.Next(100, 1000);
            _initialize(coordinates, velocity_x, velocity_y, 2, 0);
            texturesCollection.Add(Game1.content.Load<Texture2D>(image));
            texturesCollection.Add(Game1.content.Load<Texture2D>("Images//xxxx"));
            bullets = new List<Fire>();
            width = texturesCollection[0].Width;
            height = texturesCollection[0].Height;
        }

        bool DoRotation = false;
        public void Update(float IncInAngle, float SpeedOfSeeking)
        {

            velocity_y = SpeedOfSeeking;
            velocity_x = SpeedOfSeeking;
            float toolmosallas = Math.Abs((float)(cordx - GotoPosition.X));
            float ardmosallas = Math.Abs((float)(cordy - GotoPosition.Y));

            if ((int)toolmosallas <= SpeedOfSeeking && (int)ardmosallas <= SpeedOfSeeking) // rotate when u rech ur position
            {
                DoRotation = true;
            }
            else if (toolmosallas == 0) // seek to this point (mosallasat w fithagorsat w kda) :D
            {
                cordx += velocity_x;
            }
            else if (ardmosallas == 0)
            {
                cordy += velocity_y;
            }
            else if (!(cordx == GotoPosition.X || cordy == GotoPosition.Y) && DoRotation == false)
            {
                if ((toolmosallas) < (ardmosallas))
                {
                    if (!(cordx == GotoPosition.X))
                    {
                        if (cordx < GotoPosition.X)
                            cordx += (toolmosallas / ardmosallas) * velocity_x;
                        else
                            cordx -= (toolmosallas / ardmosallas) * velocity_x;
                    }

                    if (!(cordy == GotoPosition.Y))
                    {
                        if (cordy < GotoPosition.Y)
                            cordy += velocity_y;
                        else
                            cordy -= velocity_y;
                    }

                }
                else
                {
                    if (!(cordx == GotoPosition.X))
                    {
                        if (cordx < GotoPosition.X)
                            cordx += velocity_x;
                        else
                            cordx -= velocity_x;
                    }

                    if (!(cordy == GotoPosition.Y))
                    {
                        if (cordy < GotoPosition.Y)
                            cordy += (ardmosallas / toolmosallas) * velocity_y;
                        else
                            cordy -= (ardmosallas / toolmosallas) * velocity_y;
                    }

                }
            }

            if (!Exist)
                StandardImgFrame = 1; // one pixel img 
            fireeDelay--;
            if ((int)fireeDelay <= 0 && Exist) // delay between fires
            {
                bullets.Add(new Fire("Images//2oo", new Vector2((float)cordx, (float)cordy), 0, -7)); // enemies fire image
                fireeDelay = rand.Next(100, 1000);

            }
            Fire.FiresUpdate(ref bullets, Game1.Airplane); // update all the fires wth its collision wth the plane

            if (bullets.Count <= 0 && Exist == false)
                DeleteIt = true;
        }

        // centre of rotation , hw fast thy're rotating
        public void Draw(Vector2 Origin, double rotatingSpeed)
        {
            width = texturesCollection[StandardImgFrame].Width;
            height = texturesCollection[StandardImgFrame].Height;

            _Draw(Origin, rotatingSpeed, 1, DoRotation); // draw wth rotation
         //  Game1.spriteBatch.DrawString(Game1.font, "score", new Vector2(100, 100), Color.Red);

            Fire.FiresDraw(bullets);
        }


        /*
         * 
         * 
         * */
        double Lzawya;
        double GetLzawya(Vector2 pos, Vector2 org)
        {
            if ((org.X - pos.X) != 0)
                Lzawya = ((double)(Math.Atan((double)((pos.Y - org.Y) / (pos.X - org.X)))));
            else
                Lzawya = 0;
            Lzawya = Math.Abs(Lzawya);

            Lzawya = MathHelper.ToDegrees((float)Lzawya);
            if (pos.X == org.X && pos.Y < org.Y) // 7war tzbeet l zawya anhe rob3 :P
                Lzawya += 90;
            else if (pos.X < org.X && pos.Y < org.Y)
            {
                Lzawya = 90 - Lzawya;
                Lzawya += 90;
            }
            else if (pos.X < org.X && pos.Y == org.Y)
                Lzawya += 180;
            else if (pos.X < org.X && pos.Y > org.Y)
                Lzawya += 180;

            else if (pos.X == org.X && pos.Y > org.Y)
            {
                Lzawya += 270;
            }
            else if (pos.X > org.X && pos.Y > org.Y)
            {
                Lzawya = 90 - Lzawya;
                Lzawya += 270;
            }
            return Lzawya = MathHelper.ToRadians((float)Lzawya);
        }

        private int OutOfBorders()// exceed the screen
        {
            if (cordx >= Game1.graphicsdevice.Viewport.Width - width) // width of the sprite 
                return 1;
            if (cordx <= 0) 
                return -1;

            if (cordy <= 0)
                return 2;
            return 0;
        }

        public void Avoid(Vector2 org, int radius, bool AVOIDNESS)
        {

            double ZAWYA = GetLzawya(new Vector2((float)cordx, (float)cordy), new Vector2((float)org.X, (float)org.Y));

            double rate = (radius - Math.Sqrt(((cordx - org.X) * (cordx - org.X)) + ((cordy - org.Y) * (cordy - org.Y)))) / radius;
            if (AVOIDNESS) // avoid
            {
                velocity_x += (0.8 * rate * Math.Cos(ZAWYA)); // Acceleration 
                velocity_y += (0.8 * -rate * Math.Sin(ZAWYA));
            }
            else // get closer
            {
                velocity_x -= (0.8 * -rate * Math.Cos(ZAWYA));
                velocity_y -= (0.8 * rate * Math.Sin(ZAWYA));
            }

        }

        bool whichin = false; // to reset the velocity
        public void Update(Fire fire)
        {
            // Allows the game to exit
            // velocity_x = 0; velocity_y = 0;
            int radius = 200;
            fireeDelay--;
            if (fire != null) // there is no fires
            {
                if (Math.Sqrt(((cordx - fire.cordx) * (cordx - fire.cordx)) + ((cordy - fire.cordy) * (cordy - fire.cordy))) <= radius) // int the range
                {
                    if (whichin == true)
                    {
                        velocity_x = cordx < fire.cordx ? -5 : 5; velocity_y = cordy < fire.cordy ? -5 : 5; //reset its max vel. according to plane's position
                    }
                    whichin = false;
                    // rate cosidered 2 b the acceleration

                    Avoid(new Vector2((float)fire.cordx, (float)fire.cordy), radius, true); // enemy avoids plane

                    if (Math.Abs(velocity_x) > 5) // dont exceed max vel
                        velocity_x = velocity_x < 0 ? -5 : 5;
                    if (Math.Abs(velocity_y) > 5)
                        velocity_y = velocity_y < 0 ? -5 : 5;

                    cordx += (float)velocity_x; cordy += (float)velocity_y; // update position


                }
            }
            else
            {
               
                whichin = true;
                radius = 80;
                Avoid(new Vector2((float)Game1.Airplane.cordx, (float)Game1.Airplane.cordy - 400), radius, false); // get closer to plane's position 

                if (Math.Abs(velocity_x) > 5)// dont exceed max vel
                    velocity_x = velocity_x < 0 ? -5 : 5;
                if (Math.Abs(velocity_y) > 5)
                    velocity_y = velocity_y < 0 ? -5 : 5;

                cordx += (float)velocity_x; cordy += (float)velocity_y; // update it


                // fire 
               
                if ((int)fireeDelay <= 0 && Exist) // delay between fires
                {
                    bullets.Add(new Fire("Images//2oo", new Vector2((float)cordx, (float)cordy), 0, -7)); // enemies fire image
                    fireeDelay = rand.Next(100, 300);

                }
                Fire.FiresUpdate(ref bullets, Game1.Airplane); // update all the fires wth its collision wth the plane

            }

          /*  if (OutOfBorders() == 1)
                velocity_x -= 10;
            else if (OutOfBorders() == -1)
                velocity_x += 10;
            else  if (OutOfBorders() == 2)
                velocity_x -= 10;
           * */
           

        }

    }
}


