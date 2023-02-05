using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public string vegetableName;
    public string multipleVegetableName;

    public int currentSeedNumber;
    public int currentAmmoNumber;

    public bool unlocked;

    public float vegetableLife = 60;

    void Start()
    {

    }


    void Update()
    {
        vegetableLife -= Time.fixedDeltaTime;

        if (vegetableLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
