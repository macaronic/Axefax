using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        public int life=1;
         

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
            var mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                var mPoss = mouse.Position;
                if (mPoss.X < Position.X + Size.X && mPoss.X > Position.X)
                {
                    if (mPoss.Y < Position.Y + Size.Y && mPoss.Y > Position.Y)
                    {
                        life = 0;
                    }

                }

            }
        }
    };
}
