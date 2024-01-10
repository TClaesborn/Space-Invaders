using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* TODO
 * 
 * Highscore
 * 
 */
internal class Game
{
    Player player = new('A', ConsoleColor.Green);
    //Enemy enemy1 = new(10, 2, 'V', ConsoleColor.Red);
    EnemySpwaner enemySpwaner = new();
    Stopwatch stopwatch = new();
    double deltaTime;

    public Game()
    {
        
    }
    public void Run()
    {
        Init();

        while(true)
        {
            Update();
            Render();
        }
    }

    public void Update()
    {
        deltaTime = stopwatch.Elapsed.TotalSeconds;
        stopwatch.Restart();


        player.Update();
        enemySpwaner.Update(deltaTime);
        
        foreach (Enemy e in enemySpwaner.enemies)
            if(e != null)
                e.Update(deltaTime);
        CheckCollision();
    }
    public void Render()
    {
        Console.Clear();
        player.Draw();
        //enemy1.Draw();
        foreach(Enemy enemy in enemySpwaner.enemies)
        {
            if(enemy != null)
                enemy.Draw();
        }

        Thread.Sleep(10);
    }
    public void Init()
    {
        Console.CursorVisible = false;
        stopwatch.Start();
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    public void CheckCollision()
    {
        for(int i = 0; i < player.bulletCounter; i++)
        {
            for(int j = 0; j < enemySpwaner.enemyCounter; j++)
            {
                int bulletPosX = (int)player.bullets[i].pos.X;
                int bulletPosY = (int)player.bullets[i].pos.Y;
                int enemyPosX = (int)enemySpwaner.enemies[j].pos.X;
                int enemyPosY = (int)enemySpwaner.enemies[j].pos.Y;
                
                if (bulletPosX == enemyPosX)
                {
                    if (bulletPosY == enemyPosY)
                    {
                        enemySpwaner.enemies[j].Destroy();
                        player.bullets[i].isAlive = false;
                    }
                }
            }
        }
    }
}

