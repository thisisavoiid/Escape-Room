using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Escape_Room.Vector2;

namespace Escape_Room
{
    public struct Vector2
    {
        public int x;
        public int y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"({this.x}, {this.y})";

        public static Vector2 operator +(Vector2 vector01, Vector2 vector02)
        {
            return new Vector2() { x=vector01.x + vector02.x, y=vector01.y + vector02.y };
        }

        public static bool operator ==(Vector2 vector01, Vector2 vector02) => vector01.x == vector02.x && vector01.y == vector02.y;
        public static bool operator !=(Vector2 vector01, Vector2 vector02) => vector01.x != vector02.x || vector01.y != vector02.y;

        public static Vector2 Up() => new Vector2() { x = 0, y = 1 };
        public static Vector2 Down() => new Vector2() { x = 0, y = -1 };
        public static Vector2 Left() => new Vector2() { x = -1, y = 0 };
        public static Vector2 Right() => new Vector2() { x = 1, y = 1 };
        public static Vector2 Zero() => new Vector2() { x = 0, y = 0 };


    }
}
