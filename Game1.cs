using Axefax;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace MKdir
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch painter;
        Target Pile;


        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Pile = new Target();
            Pile.Position = new Point(50, 50);
            Pile.Size = new Point(150, 150);
            


            base.Initialize();
        }

        protected override void LoadContent()
        {
            painter = new SpriteBatch(GraphicsDevice);
            

            var stream = File.OpenRead("content/Pile.png");

            var Textura_pile = Texture2D.FromStream(GraphicsDevice, stream);

            stream.Dispose();

            Pile.Kartinka = Textura_pile;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            var x = Mouse.GetState();
            if (x.LeftButton == ButtonState.Pressed) 
                Exit();

            int msElapsed = (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            Pile.Update(msElapsed);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            painter.Begin();
            // TODO: Add your drawing code here
            Pile.Draw(painter);
            painter.End();


        }
    }
}
