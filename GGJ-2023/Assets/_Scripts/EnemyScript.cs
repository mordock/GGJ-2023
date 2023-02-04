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
    private Rigidbody rb;
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

    private float knockbackForce = 10f;
    private float knockbackDelay = 0.15f;

    public UnityEvent KnockbackBegin, KnockbackDone;

    List<GameObject> seedList = new List<GameObject>();
    public GameObject carrotSeed;
    public GameObject potatoSeed;
    public GameObject beetSeed;
    public GameObject onionSeed;
    public GameObject blueberrySeed;
    public GameObject grapeSeed;



    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        FarmTile = GameObject.FindGameObjectWithTag("FarmTile").transform;
        rb = GetComponent<Rigidbody>();

        seedList.Add(carrotSeed);
        seedList.Add(potatoSeed);
        seedList.Add(beetSeed);
        seedList.Add(onionSeed);
        seedList.Add(blueberrySeed);
        seedList.Add(grapeSeed);
    }

    void Update()
    {
        //Calculate distance from targets to enemy
        float farmDist = Vector3.Distance(transform.position, FarmTile.position);
        float playerDist = Vector3.Distance(transform.position, Player.position);

        //Decide target based on several factors
        if (farmDist > stoppingDistance && playerTargetLinger <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, FarmTile.position, speed * Time.deltaTime);
            transform.LookAt(FarmTile);
        }

        if (playerTargetLinger > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime); 
            transform.LookAt(Player);
        }

        if (playerDist <= aggroDistance)
        {
            playerTargetLinger = basePlayerTargetLinger;
        }

        if (FarmTile == null)
        {
            playerTargetLinger = basePlayerTargetLinger;
        }

        if (playerTargetLinger > 0)
        {
            playerTargetLinger -= Time.fixedDeltaTime;
        }

        if (attackTimer > 0)
        {
            attackTimer -= Time.fixedDeltaTime;
        }

        //Limit hits through a cooldown timer
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.fixedDeltaTime;
        }
    }
    
    void OnTriggerStay(Collider collider)
    {

        if (attackTimer <= 0)
        {
            if (collider.gameObject.tag.Equals("Player") || collider.gameObject.tag.Equals("FarmTile"))
            {
                collider.SendMessage("OnHit", enemyDamage);
            }
            attackTimer = baseAttackTimer;
        }
    }

    public void OnHit(float damage)
    {

        if (invincibilityTimer <= 0)
        {
            health -= damage;
            playerTargetLinger = basePlayerTargetLinger * 2;
            KnockbackFeedback();
            invincibilityTimer = baseInvincibilityTime;
        }
        if (health <= 0)
        {
            int randomSeed = UnityEngine.Random.Range(0, seedList.Count - 1);
            Instantiate(seedList[randomSeed], transform.position, Quaternion.identity);
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
