using System;

namespace OOP_Project
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //using (ParticleTextDemo game = new ParticleTextDemo())
            //{

            //    game.Run();


            //}
                using (Game1 game2 = new Game1())
                {
                   game2.Run();

                }
 
            
        }
    }
#endif
}

