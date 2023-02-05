using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnCounter = 10f;
    public float baseSpawnCounter = 10f;
    
    public float difficultyTimer = 30f;
    public float baseDifficultyTimer = 30f;

    public GameObject Enemy;

    private GameObject player;
    private GameObject pumpkin;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pumpkin = GameObject.FindGameObjectWithTag("Pumpkin");
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

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (pumpkin.GetComponent<Pumpkin>().hasPumpkin) {
            if (Input.GetKeyDown(KeyCode.F)) {
                if (dist <= 5) {
                    pumpkin.GetComponent<Pumpkin>().hasPumpkin = false;
                    Destroy(gameObject);
                    pumpkin.GetComponent<Pumpkin>().pumpkinUI.text = "We DON'T have a Pumpkin!";
                }
            }
        }
    }
}
