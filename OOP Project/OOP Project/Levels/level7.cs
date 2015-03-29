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
    class level7 : Levels
    {

        public static void UpdateEnimies()
        {
            time = Game1.Time;
            delay++;
            Random rand = new Random();
            float res, res2;
            res = rand.Next(0, 1000);
            res2 = rand.Next(0, 1000);
            if (delay > 50 && many > 0)
            {

                enm.Add(new Enemies("Images//wa2l", new Vector2(res, 0), 5, 0, new Vector2((res), Game1.graphicsdevice.Viewport.Height + 100)));
                many--;
                delay = 0;

                enm.Add(new Enemies("Images//wa2l", new Vector2(res2, 0), 5, 0, new Vector2((res2), Game1.graphicsdevice.Viewport.Height + 100)));
                many--;
                delay = 0;
            }

            foreach (Enemies i in enm)
            {
                i.Update(0.00f,10);
            }
       
            if (enm.Count <= 0 && many <= 0)
                Events.LevelsEnd++;

        }
        public static void Createenemy()
        {
            totalenm = many = 80;
            indx = 0;
            delay = 0;
            enm = new List<Enemies>();
            time = Game1.Time;
            Levels.counter++;
        }
         
    }
}
