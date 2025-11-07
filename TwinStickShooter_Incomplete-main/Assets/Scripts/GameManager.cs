using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject enemies;
    private float enemyCounter;
    private float startEnemy = 10;
    public int endEnemy;

    private void Awake()
    {

    }

    void Update()
    {
       int pos = Random.Range(0, 3);

        if (enemyCounter != startEnemy)
        {
            Instantiate(enemies, spawnLocations[pos]);
            enemyCounter++;

        }

        //if(enemyCounter == endEnemy)
        //{
        //    startEnemy *= 0.120f;
        //    enemyCounter = 0;
        //    endEnemy = 0;
        //}

    }
}
