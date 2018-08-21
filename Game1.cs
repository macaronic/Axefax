using Axefax;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace MKdir
{
    public class Game1 : Game
    {
        public static Point defaultSize = new Point(800, 600);
        static Random rnd = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch painter;
        List<Target> Flox = new List<Target>();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            int Ncount = rnd.Next(5, 12);
            for (int i = 0; i < Ncount; i++)
            {
                int yPoss = rnd.Next(10, 600);
                int xPoss = rnd.Next(0, defaultSize.X);
                var Pile = new Target();
                Pile.Position = new Point(xPoss, yPoss);
                Pile.Size = new Point(150, 150);
                Flox.Add(Pile);
            }
            graphics.PreferredBackBufferWidth = defaultSize.X;
            graphics.PreferredBackBufferHeight = defaultSize.Y;
            graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            painter = new SpriteBatch(GraphicsDevice);


            var stream = File.OpenRead("content/Pile.png");

            var Textura_pile = Texture2D.FromStream(GraphicsDevice, stream);

            stream.Dispose();
            foreach (var pile in Flox)
                pile.Kartinka = Textura_pile;

            // List<Te TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
         


            int msElapsed = (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            foreach (Target pile in Flox)
            pile.Update(msElapsed);
            Flox.RemoveAll(x => x.life <= 0);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            painter.Begin();
            // TODO: Add your drawing code here

            foreach (Target pile in Flox) {

                pile.Draw(painter);
            }
            painter.End();


        }
    }
}
