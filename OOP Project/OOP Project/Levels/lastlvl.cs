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
    public class LastLvl : Levels  
    {
           

        public static void Createenemy(int i)
        {
            totalenm = many = 1;
            indx = 0;
            delay = 0;
            enm = new List<Enemies>();
            time = Game1.Time;
            Levels.counter++;

        }


        public static void UpdateEnimies(int ii)
        {
            if (many > 0)
            {
                enm.Add(new Enemies("Images//download (2)", new Vector2(000, 50), 5, 0, new Vector2((Game1.graphicsdevice.Viewport.Height / (totalenm - 3) * (many) + (200)), 100)));
                enm[0].width = enm[0].texturesCollection[0].Width;
                enm[0].height = enm[0].texturesCollection[0].Height;
              
                many -= 2;
            }

            enm[0].Update(null);// if there is no fires 
            foreach (Fire i in Game1.Airplane.bullets) // 
            {
                enm[0].Update(i); // avoid all fires
            }

            if (enm.Count <= 0 && many <= 0)
                Events.LevelsEnd++;

        }

        public static void DrawEnimies(int i)
        {
            enm[0].limitBounders();
           
            
            Game1.spriteBatch.Draw(enm[0].texturesCollection[0], new Vector2((float)enm[0].cordx, (float)enm[0].cordy), Color.White);

        }

    }
}
