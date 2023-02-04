using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage;

    private void FixedUpdate()
    {

    }
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("Enemy"))
        {
            collider.gameObject.SendMessage("OnHit", bulletDamage);
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Hitbox")
        {
            Destroy(this.gameObject);
        }
    }
}
