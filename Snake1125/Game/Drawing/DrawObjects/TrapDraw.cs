using Snake1125.Game.Objects;
using System.Drawing;

namespace Snake1125.Game.Drawing.DrawObjects
{
    internal class TrapDraw : IDraw
    {
        public void Draw(GameObject gameObject, Graphics graphics)
        {
            graphics.FillEllipse(Brushes.White, gameObject.X, gameObject.Y, 10, 10);
        }
    }

}