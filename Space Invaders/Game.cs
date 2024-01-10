using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* TODO
 * Deltatime
 * Highscore
 * Enemy movement
 * Enemy spawning
 * Hitpoints
 * Destruction of ships
 * Collision checks
 */
internal class Game
{
    Player player = new('A', ConsoleColor.Green);
    Enemy enemy1 = new(10, 2, 'V', ConsoleColor.Red);
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
        enemy1.Update(deltaTime);
    }
    public void Render()
    {
        Console.Clear();
        player.Draw();
        enemy1.Draw();
        
        Thread.Sleep(10);
    }
    public void Init()
    {
        Console.CursorVisible = false;
        stopwatch.Start();
    }
}

