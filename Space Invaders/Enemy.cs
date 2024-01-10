using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Enemy : Spaceship
{
    double moveTimer = 1;
    double moveInterval = 1;

    public Enemy(int x, int y, char ship, ConsoleColor color) : base(ship, color)
    {
        pos.X = x;
        pos.Y = y;
    }

    protected override void Move(int x)
    {
        pos.Y += x;
        if(pos.Y > Console.WindowHeight-2)
        {
            pos.Y = 1;
        }
        
    }

    public void Update(double deltaTime)
    {
        moveTimer -= deltaTime;
        if (moveTimer <= 0)
        {
            Move(1);
            moveTimer += moveInterval;
        }
    }
}
