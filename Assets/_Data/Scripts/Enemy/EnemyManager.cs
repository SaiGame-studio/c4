using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> Enemies => this.enemies;

    Enemy smallestEnemey;
    Enemy biggestEnemey;

    private void Awake()
    {
        this.LoadEnemeies();
    }

    void Start()
    {
        this.LoadSmallestEnemy();
        this.LoadBiggestEnemy();
    }

    protected virtual void LoadSmallestEnemy()
    {
        Enemy fistEnemey = this.enemies[0];
        float smallestWeight = fistEnemey.GetMaxWeight();

        foreach (Enemy enemy in this.enemies)
        {
            float enemyWeight = enemy.GetWeight();
            if (enemyWeight < smallestWeight) //fasle
            {
                smallestWeight = enemyWeight;
                this.smallestEnemey = enemy;
            }

            //Debug.Log(enemy.GetObjName() + " " + enemy.GetWeight());
        }
    }

    protected virtual void LoadBiggestEnemy()
    {
        Enemy fistEnemey = this.enemies[0];
        float biggestWeight = fistEnemey.GetMinWeight();

        foreach (Enemy enemy in this.enemies)
        {
            float enemyWeight = enemy.GetWeight();
            if (enemyWeight > biggestWeight)
            {
                biggestWeight = enemyWeight;
                this.biggestEnemey = enemy;
            }

            //Debug.Log(enemy.GetObjName() + " " + enemy.GetWeight());
        }
    }

    protected virtual void LoadEnemeies()
    {

        foreach (Transform childObj in transform)
        {
            Enemy enemy = childObj.GetComponent<Enemy>();
            if (enemy == null) continue;
            this.enemies.Add(enemy);
        }
    }
}
