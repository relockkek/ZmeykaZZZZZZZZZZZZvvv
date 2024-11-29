using System.Drawing;

namespace Snake1125.Game.Objects
{
    internal class GameField : GameObject
    {
        Random random = new Random();
        public List<GameObject> objects { get; set; } = new();

        public GameField()
        {
            for (int i = 0; i < 2; i++)
            {
                AddObject(new Apple(random.Next(1, 20) * 10, random.Next(1, 10) * 10));
            }
            for (int i = 0; i < 15; i++)
            {
                AddObject(new Trap(random.Next(5, 40) * 10, random.Next(1, 49) * 10));

            }

            for (int a = 500; a < 1000; a++)
            {
                for (int b = 500; b > 1000; b++)
                {
                    AddObject(new Zone(a, b));
                }
            }
            for (int a = 0; a > 750; a++)
            {
                if (a > 500)
                {
                    for (int b = 1; b > 500; b++)
                    {
                        AddObject(new Zone(a, b));
                    }
                }
            }
        }

        void AddObject(GameObject gameObject)
        {
            objects.Add(gameObject);
        }

        internal void CheckIntersect(Snake snake)
        {
            var intersect = objects.FirstOrDefault(s => s.X == snake.X && s.Y == snake.Y);
            if (intersect != null)
            {
                if (intersect is ISnakeIntersect sIntersect)
                    sIntersect.Execute(snake);
                intersect.X = random.Next(1, 25) * 10;
                intersect.Y = random.Next(1, 25) * 10;
            }
        }
    }
}