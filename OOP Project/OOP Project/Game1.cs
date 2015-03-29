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


//using System.Drawing; // add reference 
namespace OOP_Project
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        Texture2D textpause;
        Rectangle pausedRect;
        /////////////
        bool paused = false;

        Song sound;
        SoundEffect bulleteffect;
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static GraphicsDevice graphicsdevice;
        public static ContentManager content;
        public static GameTime gametime;
        public static float Time;
        public static MainPlane Airplane;
        Background movingBackGround;
        Background constBackGround;
        public static SpriteFont font, fot3, fonto;
        Events eve = new Events();
        Fire fire;
        // Enemies enm;
        //  Bitmap myBitmap = new Bitmap("Images//airplane0");
        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            graphics.ToggleFullScreen();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            sound = Content.Load<Song>("music//AC2_Ezios_Family");
            content = Content;

            graphicsdevice = GraphicsDevice;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textpause = Content.Load<Texture2D>("pause");
            pausedRect = new Rectangle(0, 0, textpause.Width, textpause.Height);

            font = Content.Load<SpriteFont>("SpriteFont1");
            fot3 = Content.Load<SpriteFont>("font3");
            Airplane = new MainPlane();

            // enm = new Enemies("Images//asteroid", new Vector2(20, 20), 5, 0 , new Vector2(500,500) );
            movingBackGround = new Background("Images//stars", -1200);
            constBackGround = new Background("Images//Lion-Space-Wallpaper", 0);

            fire = new Fire("Images//asteroid", new Vector2(20, 20), 20, 20);
            bulleteffect = Content.Load<SoundEffect>("music//playershoot1");
            Events.loadContent();


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        float LevelShowTimer = 10, GameOverTimer = 10;
        //Initialize a 10 second timer
        //  const float TIMER = 10;
        float elapsed;
        void LEVELS_ORGANIZATION_CREATION()
        {
            if (Events.health == 0)
                GameOverTimer -= elapsed;
            else if (Events.LevelsEnd == 0 && Levels.counter == 0)
            {
                LevelShowTimer = 10;
                level1.Createenemy();
                Events.health = 200;
            }
            else if (Events.LevelsEnd == 3 && Levels.counter == 3)
            {
                LevelShowTimer = 10;
                level2.Createenemy();
            }
            else if (Events.LevelsEnd == 2 && Levels.counter == 2)
            {
                LevelShowTimer = 10;
                level3.Createenemy();
            }
            else if (Events.LevelsEnd == 1 && Levels.counter == 1)
            {
                LevelShowTimer = 10;
                level4.Createenemy();
            }
            else if (Events.LevelsEnd == 4 && Levels.counter == 4)
            {
                LevelShowTimer = 10;
                level5.Createenemy();
            }
            else if (Events.LevelsEnd == 5 && Levels.counter == 5)
            {
                LevelShowTimer = 10;
                level6.Createenemy();
            }
            else if (Events.LevelsEnd == 7 && Levels.counter == 7)
            {
                LevelShowTimer = 10;
                level7.Createenemy();
            }
            else if (Events.LevelsEnd == 6 && Levels.counter == 6)
            {
                LevelShowTimer = 10;
                LastLvl.Createenemy(1);
            }
        }
        void LEVELS_ORGANIZATION_UPDATE()
        {
            if (Events.LevelsEnd == 0)
                level1.UpdateEnimies();
            else if (Events.LevelsEnd == 3)
                level2.UpdateEnimies();
            else if (Events.LevelsEnd == 2)
                level3.UpdateEnimies();
            else if (Events.LevelsEnd == 1)
                level4.UpdateEnimies();
            else if (Events.LevelsEnd == 4)
                level5.UpdateEnimies();
            else if (Events.LevelsEnd == 5)
                level6.UpdateEnimies();
            else if (Events.LevelsEnd == 7)
                level7.UpdateEnimies();
            else if (Events.LevelsEnd == 6)
                LastLvl.UpdateEnimies(1);

        }
        protected override void Update(GameTime gameTime)
        {
            elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            LevelShowTimer -= elapsed;
            ///////////////////////

            LEVELS_ORGANIZATION_CREATION();

            Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Escape))
                this.Exit();

            LEVELS_ORGANIZATION_UPDATE();

            movingBackGround.Update();
            Airplane.Update();
            fire.Update();
            //   enm.Update(0.06f , 0.04f);
            Events.update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        private void checktime(int n) // show level time period
        {
            if (LevelShowTimer > 6 && LevelShowTimer < 10)
            {
                Game1.spriteBatch.DrawString(Game1.fot3, "Level " + n, new Vector2(500, 300), Microsoft.Xna.Framework.Color.Red);
            }

        }
        void LEVELS_ORGANIZATION_DRAW()
        {
            if (Events.LevelsEnd == 0)
            {
                checktime(1);
                level1.DrawEnimies();
            }

            else if (Events.LevelsEnd == 3)
            {
                checktime(2);
                level2.DrawEnimies();
            }
            else if (Events.LevelsEnd == 2)
            {
                checktime(3);
                level3.DrawEnimies();
            }
            else if (Events.LevelsEnd == 1)
            {
                checktime(4);
                level4.DrawEnimies();
            }
            else if (Events.LevelsEnd == 4)
            {
                checktime(5);
                level5.DrawEnimies();
            }
            else if (Events.LevelsEnd == 5)
            {
                checktime(6);
                level6.DrawEnimies();

            }
            else if (Events.LevelsEnd == 7)
            {
                checktime(7);
                level7.DrawEnimies();
            }
            else if (Events.LevelsEnd == 6)
            {
                checktime(8);
                LastLvl.DrawEnimies();
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            if (MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(sound);

            spriteBatch.Begin();

            constBackGround.Draw(0);
            movingBackGround.Draw(1000);

            Airplane.Draw();

            LEVELS_ORGANIZATION_DRAW();

            fire.Draw();
            eve.Draw(spriteBatch); // events to draw health bar

            Game1.spriteBatch.DrawString(Game1.font, Events.LevelsEnd.ToString() + " " + Levels.counter.ToString() + " " + Levels.many.ToString(), new Vector2(100, 100), Microsoft.Xna.Framework.Color.Red);

            if (Events.health <= 0)
            {
                Game1.spriteBatch.DrawString(Game1.fot3, "Game over", new Vector2(500, 300), Color.White);
                Events.LevelsEnd = 0;
                Levels.counter = 0;
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
