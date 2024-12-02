using Snake1125.Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1125.Game.Drawing.DrawObjects
{
    internal class ScoresDraw : IDraw
    {
        public void Draw(GameObject gameObject, Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Blue, 5, 317, 25, 25);
            graphics.FillRectangle(Brushes.Black, new RectangleF(35, 310, 35, 35));
            Scores score = (Scores)gameObject;
            graphics.DrawString(score.Count.ToString(), new Font("Arial Bold", 15), Brushes.White, score.X, score.Y);
        }
    }
}

