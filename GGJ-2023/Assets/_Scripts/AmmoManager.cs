using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    [Header("Ammo")]
    public GameObject carrotAmmo;
    public GameObject onionAmmo;
    public GameObject beetAmmo;
    public GameObject potatoAmmo;
    public GameObject grapeAmmo;
    public GameObject BlueAmmo;

    [Header("Seeds")]
    public GameObject carrotSeeds;
    public GameObject onionSeeds;
    public GameObject beetSeeds;
    public GameObject potatoSeeds;
    public GameObject grapeSeeds;
    public GameObject blueSeeds;

    private List<Vegetable> vegetables;
    // Start is called before the first frame update
    void Start()
    {
        vegetables = GetComponent<VegetableList>().vegetables;
  
        FillAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {
        FillAmmoUI();
    }

    void FillAmmoUI() {
        foreach(Vegetable vegetable in vegetables) {
            if (vegetable.vegetableName.Equals("Carrot")) {
                carrotAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
                carrotSeeds.GetComponent<TextMeshProUGUI>().text = "Seeds: " + vegetable.currentSeedNumber;
            }
            if (vegetable.vegetableName.Equals("Onion")) {
                onionAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
                onionSeeds.GetComponent<TextMeshProUGUI>().text = "Seeds: " + vegetable.currentSeedNumber;
            }
            if (vegetable.vegetableName.Equals("Beet")) {
                beetAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
                beetSeeds.GetComponent<TextMeshProUGUI>().text = "Seeds: " + vegetable.currentSeedNumber;
            }
            if (vegetable.vegetableName.Equals("Potato")) {
                potatoAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
                potatoSeeds.GetComponent<TextMeshProUGUI>().text = "Seeds: " + vegetable.currentSeedNumber;
            }
            if (vegetable.vegetableName.Equals("Blue Berry")) {
                BlueAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
                blueSeeds.GetComponent<TextMeshProUGUI>().text = "Seeds: " + vegetable.currentSeedNumber;
            }
            if (vegetable.vegetableName.Equals("Grape")) {
                grapeAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
                grapeSeeds.GetComponent<TextMeshProUGUI>().text = "Seeds: " + vegetable.currentSeedNumber;
            }

        }
    }
}
