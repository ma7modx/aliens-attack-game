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
    class level5 : Levels
    {
        public static void UpdateEnimies()
        {
          delay++;

            if (delay > 50 && many > 0)
            {
                enm.Add(new Enemies("Images//128px-Fantasmático_original555", new Vector2(000, 50), 5, 0, new Vector2(200,100)));
                many--;
                delay = 0;
                enm.Add(new Enemies("Images//128px-Fantasmático_original555", new Vector2(000, 50), 5, 0, new Vector2(450, 100)));
                many--;
                delay = 0;
                enm.Add(new Enemies("Images//128px-Fantasmático_original555", new Vector2(000, 50), 5, 0, new Vector2(700, 100)));
                many--;
                delay = 0;
                enm.Add(new Enemies("Images//128px-Fantasmático_original555", new Vector2(000, 50), 5, 0, new Vector2(950, 100)));
                many--;
                delay = 0;
                enm.Add(new Enemies("Images//128px-Fantasmático_original555", new Vector2(000, 50), 5, 0, new Vector2(200, 300)));
                many--;
                delay = 0;
                enm.Add(new Enemies("Images//128px-Fantasmático_original555", new Vector2(000, 50), 5, 0, new Vector2(450, 300)));
                many--;
                delay = 0;
                enm.Add(new Enemies("Images//128px-Fantasmático_original555", new Vector2(000, 50), 5, 0, new Vector2(700, 300)));
                many--;
                delay = 0;
                enm.Add(new Enemies("Images//128px-Fantasmático_original555", new Vector2(000, 50), 5, 0, new Vector2(950, 300)));
                many--;
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
            totalenm = many = 32;
            indx = 0;
            delay = 0;
            enm = new List<Enemies>();
            time = Game1.Time;
            Levels.counter++;
        }
        
    }
}
