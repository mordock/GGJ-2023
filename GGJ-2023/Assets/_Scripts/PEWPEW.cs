using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEWPEW : MonoBehaviour
{
    public Transform ProjectileSpawn;
    public GameObject ProjectilePrefab;
    public float bulletSpeed = 0;
    public float bulletCooldown = 0;
    public float bulletreleaselimit = 0;


    public void FixedUpdate()
    {
        bulletCooldown++;
    }
    public void Update()
    {
            if (bulletCooldown >= bulletreleaselimit)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var bullet = Instantiate(ProjectilePrefab, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;
                    bulletCooldown = 0;
                }
            }
    }
}
