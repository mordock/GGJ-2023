using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableManager : MonoBehaviour
{
    public List<VegetableBaseValue> baseValueList;

    private List<Vegetable> vegetableDataObjects;
    public enum VegetableType
    {
        Potato,
        Onion,
        Beet,
        Grape,
        Berry,
        Carrot
    }
    // Start is called before the first frame update
    void Start() {
        vegetableDataObjects = GetComponent<VegetableList>().vegetables;
        //reset values at beginning of game
        foreach(Vegetable vegetable in vegetableDataObjects) {
            foreach(VegetableBaseValue baseValue in baseValueList) {
                if (vegetable.type.Equals(baseValue.vegetableType)) {
                    vegetable.currentAmmoNumber = baseValue.baseAmmo;
                    vegetable.currentSeedNumber = baseValue.baseSeed;
                    vegetable.unlocked = baseValue.unlocked;
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
