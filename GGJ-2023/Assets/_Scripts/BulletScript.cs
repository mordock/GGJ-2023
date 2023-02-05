using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage;
    public float beetExplosionTimer = -1;
    private Vector3 scaleChange;
    private SphereCollider explosionCollider;

    private void Start()
    {
        scaleChange = new Vector3(+0.01f, +0.01f, +0.01f);
        explosionCollider = gameObject.GetComponent<SphereCollider>();
    }
    void Update()
    {
        if (beetExplosionTimer > 0)
        {
            beetExplosionTimer -= Time.fixedDeltaTime;
            transform.localScale += scaleChange;
            if (beetExplosionTimer < 1) {
                gameObject.GetComponent<SphereCollider>().enabled = true;
            }
            if (beetExplosionTimer < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().OnHit(bulletDamage);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            collider.gameObject.GetComponent<EnemyScript>().OnHit(bulletDamage);
            Destroy(gameObject);
        }
    }
}