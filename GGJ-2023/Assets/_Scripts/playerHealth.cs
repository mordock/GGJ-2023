using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    public CapsuleCollider player;

    public float health;
    private float baseInvincibilityTime = 1;
    private float invincibilityTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>();

    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.fixedDeltaTime;
        }
    }

    public void OnHit(float damage)
    {
        if (invincibilityTimer <= 0)
        {
            health -= damage;
        }

        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
