using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MKdir;
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
            if (Position.X < Game1.defaultSize.X)
            {
                Position.X = Position.X + 12;
            }   else
            {
                Position.X = -Size.X;

            }
        }
    };
}
