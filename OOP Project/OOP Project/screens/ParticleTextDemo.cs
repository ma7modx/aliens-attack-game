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
	public class ParticleTextDemo : Microsoft.Xna.Framework.Game
    {
        KeyboardState lastKeyboardState, keyboardState;
      //public GameTime gameTime{get;set;}
		GraphicsDeviceManager graphics;
		public SpriteBatch spriteBatch;
	public	 static SpriteFont font,fot3;
		public static Texture2D ParticleTextTexture;
		ParticleText particleText;
    
        public ParticleTextDemo()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
            graphics.ToggleFullScreen();
			IsMouseVisible = true;
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
            fot3 = Content.Load<SpriteFont>("font3");
            // Load our particle text font.
			font = Content.Load<SpriteFont>("Font");
			ParticleTextTexture = Content.Load<Texture2D>("Text Particle");
			var view = GraphicsDevice.Viewport;
            particleText = new ParticleText(GraphicsDevice, font, "Aliens Attack", ParticleTextTexture);
		}
       
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed )
				this.Exit();

            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            // Spacebar resets the simulation
            if (WasPressed(Keys.Space))
                particleText.Reset();

            else if (WasPressed(Keys.Escape))
               this.Exit();
            particleText.Update();
            base.Update(gameTime);
		}



        bool WasPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }
        
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
        	spriteBatch.Begin(0, BlendState.Additive);
			particleText.Draw(spriteBatch);
		    spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
