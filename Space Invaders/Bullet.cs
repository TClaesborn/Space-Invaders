using GraphicsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Bullet
{
    Point3d pos = new();
    double lifeTime = 3;
    public bool isAlive = true;

    public Bullet(int x, int y)
    {
        pos.X = x;
        pos.Y = y - 1;
    }
    public Bullet(Point3d p1)
    {
        pos.X = p1.X;
        pos.Y = p1.Y - 1;
    }

    public void Move()
    {
        pos.Y -= 1;
        if (pos.Y <= 2)
            isAlive = false;
    }

    public void Draw()
    {
        if (isAlive) 
        { 
            Console.SetCursorPosition((int)pos.X, (int)pos.Y);
            Console.Write("*");
        }
    }
}

