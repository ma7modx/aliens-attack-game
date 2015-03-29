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
    class level6 : Levels
    {
        public static void UpdateEnimies()
        {
            time = Game1.Time;
            delay++;

            if (delay > 50 && many > 0)
            {

                enm.Add(new Enemies("Images//wa2l", new Vector2(000, 50), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 3) * (many) + (200)), 50)));
                many -= 3;
                delay = 0;
                enm.Add(new Enemies("Images//wa2l", new Vector2(000, 320), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 3) * (many) + (200)), 320)));

                many -= 3;
                delay = 0;

                enm.Add(new Enemies("Images//wa2l", new Vector2(1250, 200), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm) * (many + 15)), 200)));
                many -= 2;
                delay = 0;
                enm.Add(new Enemies("Images//wa2l", new Vector2(1250, 450), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm) * (many + 15)), 450)));

                many -= 2;
                delay = 0;


            }

            foreach (Enemies i in enm)
            {
                i.Update(0.00f, 6);
            }


            if (enm.Count <= 0 && many == 0)
                Events.LevelsEnd++;

        }
        public static void Createenemy()
        {
            totalenm = many = 40;
            indx = 0;
            delay = 0;
            enm = new List<Enemies>();
            time = Game1.Time;
            Levels.counter++;

        }
    }
}
