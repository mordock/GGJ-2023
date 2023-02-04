using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{

    private Transform Farm;
    private float speed = 5;

    void Start()
    {
        Farm = GameObject.FindGameObjectWithTag("Farm").transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Farm.position, speed * Time.deltaTime);
        transform.LookAt(Farm);
    }
}
