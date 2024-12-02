using Snake1125.Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1125.Game
{
    internal class Scores : GameObject
    {
        public int Count { get; set; }

        public Scores(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}