using Snake1125.Game.Drawing;
using Snake1125.Game.Drawing.DrawObjects;
using Snake1125.Game.Objects;

namespace Snake1125
{
    internal class SnakeGame
    {
        Random random = new Random();
        DrawSystem draw;
        GameField field;
        Control control;
        Snake snake;
        bool stop = false;

        public bool SnakeIsAlive { get => !stop && snake.IsAlive; }        

        public SnakeGame()
        {
            draw = new DrawSystem();
            control = new Control();
        }

        void CreateSnake()
        {
            snake = new Snake(50, 50);            
        }

        internal void SendNewSnakeDirection(Direction direction)
        {
            snake.Direction = direction;
        }

        internal void Start()
        {
            stop = false;
            CreateSnake();
            field = new GameField();
            RunGame();
        }

        private void RunGame()
        {
            control.Run(this);
            draw.Draw(field);
            while (SnakeIsAlive)
            {
                snake.Move();
                field.CheckIntersect(snake);
                draw.Draw(snake);
                foreach (var obj in field.objects)
                    draw.Draw(obj);
                //Thread.Sleep(200) это пауза для текущего потока в 200 миллисекуд. Код перестает выполняться и ждет указанное время. 1сек = 1000мс
                // чем меньше пауза, тем быстрее будет двигаться змейка
               
                Thread.Sleep(100);
            }
            Console.WriteLine("Конец игры");
        }

        internal void Stop()
        {
            stop = true;
            Console.WriteLine("Игра прервана");
        }
    }
}