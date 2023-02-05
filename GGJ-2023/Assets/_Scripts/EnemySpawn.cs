using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Enemy Prefab")]
    public GameObject Enemy;

    [Header("EnemySpawning")]
    public float SummonTimer;
    public float SummonTime;
    public float TotalSummonTime;

    [Header("EnemySpawningOffset")]
    public float RandomTimeAdd;

    [Header("Grace Period")]
    public int Gracetime;

    [Header("EnemySpeedScaling")]
    public int DifficultyTimer;
    public int DifficultyScaler;

    void FixedUpdate()
    {
        TotalSummonTime = SummonTime + RandomTimeAdd;
        //Grace Period 
        Gracetime--;
        if (Gracetime < 1)
        {
            SummonTimer++;
        }

        //Asses random value to offset
        if (SummonTimer > 1 && SummonTimer < 10)
        {
            RandomTimeAdd = Random.Range(1, 500);
        }

        //Instantiate Enemy
        if (SummonTimer >= SummonTime + RandomTimeAdd)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            SummonTimer = 0;
        }

        //EnemyScaling
        DifficultyTimer++;
        if (DifficultyTimer > 2000 && DifficultyTimer < 2002)
        {
            SummonTime = SummonTime - DifficultyScaler;
        }

        if (DifficultyTimer > 4000 && DifficultyTimer < 4002)
        {
            SummonTime = SummonTime - DifficultyScaler;
        }

        if (DifficultyTimer > 6000 && DifficultyTimer < 6002)
        {
            SummonTime = SummonTime - DifficultyScaler;
        }

        if (DifficultyTimer > 8000 && DifficultyTimer < 8002)
        {
            SummonTime = SummonTime - DifficultyScaler;
        }
    }
}
