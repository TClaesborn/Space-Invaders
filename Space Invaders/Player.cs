using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsBase;

class Player : Spaceship
{
    
    //powerups
    bool doubleShot = false;

    public Player(char ship, ConsoleColor color) : base(ship, color)
    {
        pos.X = Console.WindowWidth / 2;
        pos.Y = Console.WindowHeight - 2;
    }

    public void Update()
    {
        //Handles all changes in the playerclass
        HandlePlayerInput();
        HandleBulletDestruction();

        foreach(Bullet bullet in bullets)
        {
            if (bullet != null)
                bullet.Move();
        }
    }




    void HandlePlayerInput()
    {
        //Handles player input, could be swapped for a switch.
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if(keyInfo.Key == ConsoleKey.A)
            {
                Move(-1);
            }
            if(keyInfo.Key == ConsoleKey.D)
            {
                Move(1);
            }
            if(keyInfo.Key == ConsoleKey.Spacebar)
            {
                Shoot();
            }
            if(keyInfo.Key == ConsoleKey.X)
            {
                doubleShot = true;
            }
        }
    }
    void Shoot()
    {
        //Shoots if you can.
        if (bulletCounter < maxBullets)
        {
            bullets[bulletCounter] = new(pos);
            bulletCounter++;
            if (doubleShot)
            {
                bullets[bulletCounter] = new((int)pos.X - 1, (int)pos.Y);
                bulletCounter++;
            }
        }
    }
}

