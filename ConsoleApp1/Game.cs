using System;
using System.Threading;

namespace Snake
{

    class Game
    {
        static readonly int x = 80;
        static readonly int y = 26;

        static Walls walls;
        static Snake snake;
        static FoodFactory foodFactory;
        static Timer time;
        static void Main()
        {
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetWindowSize(x + 1, y + 1);
            Console.CursorVisible = false;

            walls = new Walls(x, y, '#');
            snake = new Snake(x / 2, y / 2, 3);

            foodFactory = new FoodFactory(x, y, '@');
            foodFactory.CreateFood();

            time = new Timer(Loop, null, 0, 200);
            while(true)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Rotation(key.Key);
                }
            }
        }
        static void Loop(object obj)
        {
            if(walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
            {
                time.Change(0, Timeout.Infinite);
            }
            else if(snake.Eat(foodFactory.food))
            {
                foodFactory.CreateFood();
            }
            else
            {
                snake.Move();
            }
        }
    }
}
