using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class EnemySpwaner
{
    public Enemy[] enemies = new Enemy[50];
    double spawnTimer = 2;
    double spawnInterval = 2;
    public int enemyCounter = 0;
    int maxEnemies = 50;
    Random random = new();

    public void Update(double deltaTime)
    {
        spawnTimer -= deltaTime;
        if(spawnTimer <= 0)
        {
            if (enemyCounter < maxEnemies)
            {
                enemies[enemyCounter] = new Enemy(random.Next(Console.WindowWidth), 2, 'V', ConsoleColor.Red);
                enemyCounter++;
            }
            spawnTimer += spawnInterval;
        }
    }
}

