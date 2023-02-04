using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    public string seedType;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableSeedNumber(seedType, Random.Range(1,3));
            Destroy(gameObject);
        }
    }
}
