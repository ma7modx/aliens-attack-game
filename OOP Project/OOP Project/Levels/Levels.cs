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
    public class Levels
    {
        public static List<Enemies> enm;
        public static int many;
        public static int indx;
        public static int delay;
        public static int totalenm;
        public static int counter = 0;
        public static float time;
        private static float time1
        {
            get { return time; }
            set { time = value; }
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
        public static void DrawEnimies()
        {
            foreach (Enemies i in enm)
            {
                i.Draw(new Vector2(0, 0), 0.03);
            }
          
        }

        /*
         void CreateLevel();
        void UpdateLevel();
        void DrawLevel();

         */
    }
}
