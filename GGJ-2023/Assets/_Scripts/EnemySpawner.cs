using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnCounter = 10f;
    public float baseSpawnCounter = 10f;
    
    public float difficultyTimer = 30f;
    public float baseDifficultyTimer = 30f;

    private GameObject Enemy;


    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void FixedUpdate()
    {
        //Timer for spawning enemies
        if (spawnCounter > 0)
        {
            spawnCounter -= Time.fixedDeltaTime;
        } 

        if (spawnCounter <= 0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            spawnCounter = baseSpawnCounter;
        }
         
        //Timer for increasing difficulty of enemies and spawnrate
        if (difficultyTimer > 0)
        {
            difficultyTimer -= Time.fixedDeltaTime;
        }

        if (difficultyTimer <= 0)
        {
            if (baseSpawnCounter > 1)
            {
                baseSpawnCounter -= 0.5f;
            }
            difficultyTimer = baseDifficultyTimer;
        }
    }
}
