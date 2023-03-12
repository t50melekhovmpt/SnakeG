using System;

namespace Snake
{
    struct Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public char ch { get; set; }

        public static implicit operator Point((int, int, char) value) =>
            new Point {x = value.Item1,y = value.Item2, ch = value.Item3 };

        public static bool operator ==(Point a, Point b) =>
            (a.x == b.x && a.y == b.y);
        public static bool operator !=(Point a, Point b) =>
            (a.x != b.x || a.y != b.y);
        private void DrawPoint(char _ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(_ch);
        }
        public void Draw()
        {
            DrawPoint(ch);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }

    }
}
