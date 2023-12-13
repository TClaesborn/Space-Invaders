using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Enemy : Spaceship
{
    public Enemy(int x, int y, char ship, ConsoleColor color) : base(ship, color)
    {
        pos.X = x;
        pos.Y = y;
    }
}
