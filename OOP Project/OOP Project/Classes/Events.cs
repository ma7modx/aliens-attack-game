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
    public class Events
    {
        public static int score = 0;
        private static SpriteFont font;
        public static int LevelsEnd = 0;
        public static Rectangle healthRectangle;
        public static Vector2 healthBarposition;
        public  static int health;
        static Texture2D textOfBar;
        public Events()
        {
            healthBarposition = new Vector2(10, 10);
            health = 200;
        }
        public static void loadContent()
        {
            textOfBar = Game1.content.Load<Texture2D>("Images//healthbar");
            font = Game1.content.Load<SpriteFont>("Score");

        }

        public static void update()
        {
            healthRectangle = new Rectangle((int)healthBarposition.X, (int)healthBarposition.Y, health, textOfBar.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textOfBar, healthRectangle, Color.White);
            spriteBatch.DrawString(font, "Score : " + score, new Vector2(1000, 50), Color.Red);
        }

        public static bool pixelCollesion(Texture2D sprite1, Texture2D sprite2, Vector2 player1, Vector2 enemy1)
        {
            Rectangle player = new Rectangle((int)player1.X, (int)player1.Y, sprite1.Width, sprite1.Height);
            Rectangle enemy = new Rectangle((int)enemy1.X, (int)enemy1.Y, sprite2.Width, sprite2.Height);

            Color[] colordata1 = new Color[sprite1.Width * sprite1.Height];  // Get Color data of each Texture
            Color[] colordata2 = new Color[sprite2.Width * sprite2.Height];  //2D array

            sprite1.GetData<Color>(colordata1);
            sprite2.GetData<Color>(colordata2);

            //Bounds of collision , // Calculate the intersecting rectangle
            int top, bottom, left, right;
            top = Math.Max(player.Top, enemy.Top);
            bottom = Math.Min(player.Bottom, enemy.Bottom);
            left = Math.Max(player.Left, enemy.Left);
            right = Math.Min(player.Right, enemy.Right);

            // For each single pixel in the intersecting rectangle
            for (int y = top; y < bottom; y++)
                for (int x = left; x < right; x++)
                {
                    Color C_oPflayer = colordata1[(y - player.Top) * (player.Width) + (x - player.Left)]; // when u convert from 2D array to 1D array
                    Color C_ofEnemy = colordata2[(y - enemy.Top) * (enemy.Width) + (x - enemy.Left)];

                    if (C_oPflayer.A != 0 && C_ofEnemy.A != 0)  // If both colors are not transparent (the alpha channel is not 0),,// A for alpha color
                        return true;
                }

            return false;
        }


        public static void Rotate1(ref double coordx, ref double coordy, double Lzawya, Vector2 Radios)
        {
            coordx += (float)(Radios.X * (-1 * Math.Cos(Lzawya)));
            coordy += (float)(Radios.Y * Math.Sin(Lzawya));
        }
    }


}
