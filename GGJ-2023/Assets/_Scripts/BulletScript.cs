using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletDespawnTimer = 0f;
    public float BulletDespawnDelay = 0f;


    private void FixedUpdate()
    {
        BulletDespawnTimer++;
    }
    void Update()
    {
        if (BulletDespawnTimer >= BulletDespawnDelay) {
            Object.Destroy(this.gameObject);
        }
    }
}
