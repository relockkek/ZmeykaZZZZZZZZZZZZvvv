using Snake1125.Game.Objects;
using System.Drawing;

namespace Snake1125.Game.Drawing.DrawObjects
{
    internal class ZoneDraw : IDraw
    {
        public void Draw(GameObject gameObject, Graphics graphics)
        {
            Pen pen = new Pen(Color.Purple, 5);
            graphics.DrawRectangle(pen, gameObject.X, gameObject.Y, 520, 520);
        }
    }

}