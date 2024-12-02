using Snake1125;
using System;
using System.Drawing;
namespace Snake1125.Game.Objects
{    
    
    internal class Snake : GameObject
    {
        int Kolobok = 0;

       
        public override int X { get => cells[0].X; set { } }
        public override int Y { get => cells[0].Y; set { } }

        public GameObject Tale { get => stackTale.Count > 0 ? stackTale.Pop() : null; }
        public Direction Direction { get; set; }
        public bool IsAlive { get; internal set; } = true;

        List<GameObject> cells;

        Stack<GameObject> stackTale = new();
        public Snake(int x, int y)
        {
            cells = new() { new GameObject { X = x, Y = y } };
        }


        internal void Move()
        {
            stackTale.Push(new GameObject { X = cells[^1].X, Y = cells[^1].Y });
            for (int i = cells.Count - 1; i > 0; i--)
            {
                cells[i].X = cells[i - 1].X;
                cells[i].Y = cells[i - 1].Y;
            }
           
            switch (Direction)
            {
                case Direction.up:
                    cells[0].Y -= 10;
                    break;
                case Direction.down:
                    cells[0].Y += 10;
                    break;
                case Direction.left:
                    cells[0].X -= 10;
                    break;
                case Direction.right:
                    cells[0].X += 10;
                    break;
            }

            for (int i = cells.Count - 1; i > 0; i--)
            {
                if (cells[0].X == cells[i].X && cells[0].Y == cells[i].Y && Kolobok > 1)
                {
                    IsAlive = false;
                    break;
                }
            }
            if (cells[0].X > 500)
            {
                IsAlive = false;
               
            }
            if (cells[0].Y > 500)
            {
                IsAlive = false;
            }
            if (cells[0].X < 0)
            {
                IsAlive = false;


            }
            if (cells[0].Y < 0)
            {
                IsAlive = false;
            }
        }

        internal void lol()
        {

        }
       
        internal void Increase()
        {
            cells.Add(new GameObject { X = cells[^1].X, Y = cells[^1].Y });
            Kolobok++;

            OnLengthChanged?.Invoke(this, null);
        }

       public event EventHandler OnLengthChanged;
       public int SpeedBoost(int speedmain)
        {
            Kolobok++;
            int speed = Kolobok;
            speed = speed - speedmain;
            return speed;
        }
        internal void Decrease()
        {
            if (cells.Count == 1)
            {

                IsAlive = false;
                return;


            }
            Kolobok--;
            Console.WriteLine($"Набрано очков: {Kolobok}");


            stackTale.Push(new GameObject { X = cells[^1].X, Y = cells[^1].Y });
            cells.Remove(cells[^1]);
            OnLengthChanged?.Invoke(this, null);

        }
    }
}
