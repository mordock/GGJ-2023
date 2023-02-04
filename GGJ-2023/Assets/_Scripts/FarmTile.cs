using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour
{
    public Vegetable currentVegetable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlantTile(Vegetable vegetableToPlant) {
        currentVegetable = vegetableToPlant;
    }
}
