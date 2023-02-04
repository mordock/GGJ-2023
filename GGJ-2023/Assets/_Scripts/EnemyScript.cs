using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    private Transform FarmTile;
    private Transform Player;

    private float speed = 5;
    private float stoppingDistance = 2.5f;
    private float aggroDistance = 6f;
    private float playerTargetLinger = 0;
    private float basePlayerTargetLinger = 2;

    private float enemyDamage = 3;
    private float health = 20;
    public float attackTimer;
    private float baseAttackTimer = 2;
    private float baseInvincibilityTime = 1;
    private float invincibilityTimer;

    private bool noHit = false;
    private Vector3 previousPos;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        FarmTile = GameObject.FindGameObjectWithTag("FarmTile").transform;
    }

    void Update() {
        //Calculate distance from targets to enemy
        float farmDist = Vector3.Distance(transform.position, FarmTile.position);
        float playerDist = Vector3.Distance(transform.position, Player.position);

        //Decide target based on several factors
        if (farmDist > stoppingDistance && playerTargetLinger <= 0) {
            transform.position = Vector3.MoveTowards(transform.position, FarmTile.position, speed * Time.deltaTime);
            transform.LookAt(FarmTile);
        }

        if (playerTargetLinger > 0) {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            transform.LookAt(Player);
        }

        if (playerDist <= aggroDistance) {
            playerTargetLinger = basePlayerTargetLinger;
        }

        if (FarmTile == null) {
            playerTargetLinger = basePlayerTargetLinger;
        }

        if (playerTargetLinger > 0) {
            playerTargetLinger -= Time.fixedDeltaTime;
        }

        if (attackTimer > 0) {
            attackTimer -= Time.fixedDeltaTime;
        }

        //Limit hits through a cooldown timer
        if (invincibilityTimer > 0) {
            invincibilityTimer -= Time.fixedDeltaTime;
        }

        //force not moving after hit to give player a chance
        if (noHit) {
            transform.position = previousPos;
            previousPos = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name);

        if (!noHit) {
            if (collision.gameObject.tag.Equals("Player")) {
                collision.gameObject.GetComponent<playerHealth>().Hit(.21f);
                noHit = true;
                StartCoroutine(WaitForNextHit(2));
            }
        }
    }

    IEnumerator WaitForNextHit(int secs) {
        yield return new WaitForSeconds(secs);
        noHit = false;
    }

    void OnTriggerStay(Collider collider) {
        if (attackTimer <= 0) {
            if (collider.gameObject.name.Equals("Player") || collider.gameObject.name.Equals("Farm")) {
                collider.SendMessage("OnHit", enemyDamage);
            }
            attackTimer = baseAttackTimer;
        }
    }

    public void OnHit(float damage) {

        if (invincibilityTimer <= 0) {
            health -= damage;
            playerTargetLinger = basePlayerTargetLinger * 2;
            invincibilityTimer = baseInvincibilityTime;
        }
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
