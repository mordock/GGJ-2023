using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    public VegetableManager.VegetableType seedType;

    void Start()
    {
    }


    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableSeedNumber(seedType, Random.Range(1, 3));
            GameObject.Find("GameManager").GetComponent<VegetableList>().UnlockVegetable(seedType);
            Destroy(gameObject);
        }
    }
}
