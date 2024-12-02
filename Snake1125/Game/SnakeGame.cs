using Snake1125.Game;
using Snake1125.Game.Drawing;
using Snake1125.Game.Drawing.DrawObjects;
using Snake1125.Game.Objects;
using System.Runtime.CompilerServices;


namespace Snake1125
{
    internal class SnakeGame
    { 
    
        Random random = new Random();
        DrawSystem draw;
        GameField field;
        Control control;
        Snake snake;
        Zone zone;
        Scores scores;
        bool stop = false;
        int speed = 150;

        public bool SnakeIsAlive { get => !stop && snake.IsAlive; }        

        public SnakeGame()
        {
            draw = new DrawSystem();
            control = new Control();
            zone = new Zone(0, 0);
            scores = new Scores();
        }


        void CreateSnake()
        {
            snake = new Snake(50, 50);
            snake.OnLengthChanged += Snake_OnLengthChanged;    
        }

        private void Snake_OnLengthChanged(object? sender, EventArgs e)
        {
            scores.AddScore(10);
            DisplayScore();
        }
        private void DisplayScore()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Очки: {scores.CurrentScore}");
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
            draw.Draw(zone);
            while (SnakeIsAlive)
            {
                snake.Move();
                field.CheckIntersect(snake);
                draw.Draw(snake);
                foreach (var obj in field.objects)
                    draw.Draw(obj);
                //Thread.Sleep(200) это пауза для текущего потока в 200 миллисекуд. Код перестает выполняться и ждет указанное время. 1сек = 1000мс
                // чем меньше пауза, тем быстрее будет двигаться змейка
                
                Thread.Sleep(speed);

            }
            
            Console.WriteLine("Конец игры");
            Console.WriteLine($"Ваш итоговый счет: {scores.CurrentScore}");

        }

        internal void Stop()
        {
            stop = true;
            Console.WriteLine("Игра прервана");
        }
        private void IncreaseSpeed()
        {
            if (speed > 50)
            {
                speed -= 10;
            }
        }
    }
    public class Scores
    {
        public int CurrentScore { get; private set; }
        public void AddScore (int points)
        {
            CurrentScore += points;
        }
        public void Reset()
        {
            CurrentScore = 0;
        }
    }
}