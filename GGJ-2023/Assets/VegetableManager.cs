using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject carrotSelected;
    public GameObject potatoSelected;
    public GameObject onionSelected;
    public GameObject beetSelected;
    public GameObject blueberrySelected;
    public GameObject grapeSelected;

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

    public enum KeyboardLocation
    {
        Alpha1,
        Alpha2,
        Alpha3,
        Alpha4,
        Alpha5,
        Alpha6
    }
    // Start is called before the first frame update
    void Start() {
        vegetableDataObjects = GetComponent<VegetableList>().vegetables;
        //reset values at beginning of game
        foreach (Vegetable vegetable in vegetableDataObjects) {
            vegetable.currentAmmoNumber = vegetable.baseAmmo;
            vegetable.currentSeedNumber = vegetable.baseSeed;
            vegetable.currentUnlocked = vegetable.baseUnlocked;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
