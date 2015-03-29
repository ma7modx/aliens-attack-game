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
    class level2:Levels
    {

        public static void UpdateEnimies()
        {
            time = Game1.Time;
            delay++;

            if (delay > 50 && many > 0)
            {
                enm.Add(new Enemies("Images//enemyship", new Vector2(000, 50), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 7) * (many) + (140)), 100)));
                many--;
                delay = 0;
                enm.Add(new Enemies("Images//enemyship", new Vector2(000, 150), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 7) * (many) + (140)), 200)));

                many--;
                delay = 0;
                enm.Add(new Enemies("Images//enemyship", new Vector2(000, 250), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 7) * (many) + (140)), 300)));

                many-=2;
                delay = 0;

            }

            foreach (Enemies i in enm)
            {
                i.Update(0.01f, 4);
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
