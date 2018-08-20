using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Axefax
{
    class Target
    {
        public Point Position;
        public Point Size;
        public Texture2D Kartinka;
         

        public void Draw(SpriteBatch painter)
        {
            painter.Draw(Kartinka, new Rectangle(Position, Size), Color.Aquamarine);
        }

        public void Update(int msElapsed)
        {
            Position.X = Position.X + 1;
        }
    };
}
