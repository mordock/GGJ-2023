using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    private Transform Farm;
    private float speed = 5;
    public float stoppingDistance = 100;
    public Rigidbody rb;

    void Start()
    {
        Farm = GameObject.FindGameObjectWithTag("Farm").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, Farm.position);
        if (dist > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Farm.position, speed * Time.deltaTime);
        }
        transform.LookAt(Farm);
    }


}
