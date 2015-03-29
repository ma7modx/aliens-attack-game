using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
namespace OOP_Project
{
    class aliensFire : MainSprite
    {
        public aliensFire(string image, Vector2 coordinates, float velocity_x, float velocity_y)
        {
            Exist = true;
            _initialize(coordinates, velocity_x, velocity_y, 1, 0);
            texturesCollection.Add(Game1.content.Load<Texture2D>(image));
        }
          public void Update()
        {
          //  coordinates.X += velocity_x;
            coordinates.Y += velocity_y;

        }
          private bool OutOfBordersForaliensFire(int width, int height)
          {
              if (coordinates.Y >= Game1.graphicsdevice.Viewport.Height - height) // height ...
                  return true;
              if (coordinates.Y <= 0)
                  return true;
              return false;
          }

          public static void aliensFiresUpdate(ref List<aliensFire> aliensbullets)
          {
              for (int x = 0; x < aliensbullets.Count; ++x)
              {
                  aliensFire i = aliensbullets[x];
                  if (i.OutOfBordersForaliensFire(i.width, i.height))
                  {
                      aliensbullets.Remove(i);
                      i.Exist = false;
                      x--;
                  }
                  else
                      i.Update();

              }

          }
          public static void aliensfireDraw(List<aliensFire> aliensbullets)
          {
              foreach (aliensFire i in aliensbullets)
                  if (i.Exist)
                      i.Draw();
          }

          public void Draw()
          {
              width = 40;
              height = 40;
              _Draw();
          }

    }
}
