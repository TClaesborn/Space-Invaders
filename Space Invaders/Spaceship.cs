using GraphicsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class Spaceship
{
    protected Point3d pos = new();
    char ship = 'A';
    ConsoleColor color;

    protected Bullet[] bullets = new Bullet[20];    //Sets maximum bulletcount to 20
    protected int bulletCounter = 0;                //Keeps track of the amount of bullets
    protected int maxBullets = 5;                   //Current max allowed bullets

    public Spaceship(char ship, ConsoleColor color) 
    {
        this.ship = ship;
        this.color = color;
    }

    protected virtual void Move(int x) //Handles movement of ship
    {
        pos.X += x;

        //Checks position against edges of the screen.
        if (pos.X <= 1)
            pos.X = 1;
        if (pos.X >= Console.WindowWidth - 2)
            pos.X = Console.WindowWidth - 2;
    }

    public void Draw()
    {
        Console.SetCursorPosition((int)pos.X, (int)pos.Y);
        Console.ForegroundColor = color;
        Console.Write(ship);
        Console.ResetColor();
        //Loops through the bullets and draws them if they exist.
        //Could be optimised with a for-loop from 0 to bulletcount-1
        foreach (Bullet bullet in bullets)
        {
            if (bullet != null)
                bullet.Draw();
        }
    }
    protected void HandleBulletDestruction()
    {
        //loopar igenom array med bullets
        for (int i = 0; i <= bulletCounter; i++)
        {
            if (bullets[i] == null)
            {
                return;
            }
            //Kollar om bullet fortfarande lever
            if (!bullets[i].isAlive)
            {
                //skiftar resten av elementen 1 steg åt vänster
                for (int j = i; j < bulletCounter - 1; j++)
                    bullets[j] = bullets[j + 1];

                bulletCounter--; //Uppdatera antal kulor

                bullets[bulletCounter] = null; //Ta bort sista kulan
            }
        }
    }

}

