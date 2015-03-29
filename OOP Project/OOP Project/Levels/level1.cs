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
    class level1 : Levels
    {
        public static void UpdateEnimies()
        {
            time = Game1.Time;
            delay++;

            if (delay > 60 && many > 0)
            {
                enm.Add(new Enemies("Images//wa2l", new Vector2(000, 50), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 3) * (many) + (200)), 100)));
                enm.Add(new Enemies("Images//wa2l", new Vector2(000, 150), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 3) * (many) + (200)), 200)));
                enm.Add(new Enemies("Images//wa2l", new Vector2(000, 250), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 3) * (many) + (200)), 300)));
                many -= 4;
                delay = 0;

            }

            foreach (Enemies i in enm) 
            {
                i.Update(0.03f, 5);
            }
            if (enm.Count <= 0 && many == 0)
                Events.LevelsEnd++;
        }
           
            public static void Createenemy()
          {
            totalenm = many = 28;
            indx = 0;
            delay = 0;
            enm = new List<Enemies>();
            time = Game1.Time;
            Levels.counter++;
            
        }
    }
}
    

