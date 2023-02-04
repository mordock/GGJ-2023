using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    private Transform Farm;
    public Rigidbody rb;
    public Transform Player;

    private float speed = 5;
    private bool inRange;
    private float stoppingDistance = 2.5f;
    private float aggroDistance = 5f;
    private float playerTargetLinger = 0;
    private float basePlayerTargetLinger = 2;

    private float enemyDamage = 3;
    private float health = 8;
    public float baseInvincibilityTime = 1;
    public float invincibilityTimer;

    private float knockbackForce = 10f;
    public float knockbackDelay = 0.15f;

    public UnityEvent KnockbackBegin, KnockbackDone;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Farm = GameObject.FindGameObjectWithTag("Farm").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(Farm);
        float farmDist = Vector3.Distance(transform.position, Farm.position);
        float playerDist = Vector3.Distance(transform.position, Player.position);

        if (farmDist > stoppingDistance && playerTargetLinger <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Farm.position, speed * Time.deltaTime);
        }

        if (playerDist > stoppingDistance && playerTargetLinger > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }

        if (playerDist <= aggroDistance)
        {
            playerTargetLinger = basePlayerTargetLinger;
        }

        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.fixedDeltaTime;
        }

        if (playerTargetLinger > 0)
        {
            playerTargetLinger -= Time.fixedDeltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (inRange == true)
        {
            if (collider.gameObject.name.Equals("Player") || collider.gameObject.name.Equals("Farm"))
            {
                collider.SendMessage("OnHit", enemyDamage);
            }
        }
    }

    public void OnHit(float damage)
    {

        if (invincibilityTimer <= 0)
        {
            health -= damage;
            playerTargetLinger = basePlayerTargetLinger * 2;
            KnockbackFeedback();
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void KnockbackFeedback()
    {
        StopAllCoroutines();
        KnockbackBegin?.Invoke();
        Vector2 direction = (transform.position - Player.transform.position).normalized;
        rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        StartCoroutine(KnockbackReset());
    }

    private IEnumerator KnockbackReset()
    {
        yield return new WaitForSeconds(knockbackDelay);
        rb.velocity = Vector3.zero;
        KnockbackDone?.Invoke();
    }


}
