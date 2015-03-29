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

using System.IO;
using System.Drawing;
namespace OOP_Project
{
    public class MainPlane : MainSprite
    {
        private int moveSpeed = 10;
        private int rotationSpeed = 10;
        private int GoRight = 0;
        private int GoLeft = 0;
        private bool Left = false, Right = false;
       public List<Fire> bullets;
        
        public int fireDelay, fireDelayAliens;

        public MainPlane()
        {
            _initialize(new Vector2(Game1.graphicsdevice.Viewport.Width / 2 + 200, Game1.graphicsdevice.Viewport.Height + 200), moveSpeed, moveSpeed, 7, 3);
            for (int x = 0; x < imageframes; ++x)//image frames
                texturesCollection.Add(Game1.content.Load<Texture2D>("Images//airplane" + x.ToString()));
            bullets = new List<Fire>();
            fireDelay = 10;
        }

        private void GetInput()
        {
            KeyboardState keyboard = Keyboard.GetState();
            bool anykeydown = false;

            if (keyboard.IsKeyDown(Keys.A) && keyboard.IsKeyDown(Keys.D))
            {
                StandardImgFrame = 3;
                GoLeft = 0;
                GoRight = 0;
                anykeydown = true;
            }

            if (keyboard.IsKeyDown(Keys.W)||keyboard.IsKeyDown(Keys.Up))
            {
                cordy -= moveSpeed;
                anykeydown = true;
                Left = false; Right = false;
            }
            if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
            {
                cordy += moveSpeed;
                anykeydown = true;
                Left = false; Right = false;
            }

            if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
            {
                cordx += moveSpeed;
                GoRight += 1;
                GoLeft -= 1;
                Right = true;
                anykeydown = true;
            }
            if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
            {
                cordx -= moveSpeed;
                GoRight -= 1;
                GoLeft += 1;
                Left = true;
                anykeydown = true;
            }
            if (!anykeydown)// reset the initial image
            {
                StandardImgFrame = 3;
                GoLeft = 0;
                GoRight = 0;
                Right = false;
                Left = false;
            }

            if (Left && Right || !Left && !Right) // lw daas S b3d kda D 3 tool 
            {
                StandardImgFrame = 3;
                GoLeft = 0;
                GoRight = 0;
                Left = false;
                Right = false;
            }

            if (keyboard.IsKeyDown(Keys.Space) && fireDelay <= 0)//shoot
            {
                bullets.Add(new Fire("Images//playerfire", new Vector2((float)cordx+25, (float)cordy), 0, 10));
                fireDelay = 10;
            }
        }

        public void Update()
        {
            GetInput();

            Fire.FiresUpdate(ref bullets, Levels.enm);//collision bullets vs enemies

            Fire.PlaneVSEnemy(ref Levels.enm);// collision plane vs enemies

            if (StandardImgFrame >= 0 && StandardImgFrame <= 6)// change image frame
            {
                if (GoRight - GoLeft >= rotationSpeed && StandardImgFrame < 6)
                {
                    StandardImgFrame++;
                    GoLeft = 0;
                    GoRight = 0;
                }
                if (GoLeft - GoRight >= rotationSpeed && StandardImgFrame > 0)
                {
                    StandardImgFrame--;
                    GoLeft = 0;
                    GoRight = 0;
                }
            }

            fireDelay = fireDelay < 0 ? 0 : fireDelay - 1;// dont exceed negative ifinity
        }


        public void Draw()
        {
            width = texturesCollection[StandardImgFrame].Width;
            height = texturesCollection[StandardImgFrame].Height;
            _Draw();
            Fire.FiresDraw(bullets);
        }

    }
}
