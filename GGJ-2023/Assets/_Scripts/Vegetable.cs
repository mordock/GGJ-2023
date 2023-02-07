using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public VegetableManager.VegetableType type;
    public VegetableManager.KeyboardLocation location;

    public GameObject selectedUI;

    public string vegetableName;
    public string multipleVegetableName;

    public int currentSeedNumber;
    public int currentAmmoNumber;

    public bool unlocked;

    void Start()
    {

    }


    void Update()
    {
    }
}
