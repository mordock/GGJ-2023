using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public GameObject carrotAmmo, onionAmmo, beetAmmo, potatoAmmo, grapeAmmo, BlueAmmo;

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
            }
            if (vegetable.vegetableName.Equals("Onion")) {
                onionAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
            }
            if (vegetable.vegetableName.Equals("Beet")) {
                beetAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
            }
            if (vegetable.vegetableName.Equals("Potato")) {
                potatoAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
            }
            if (vegetable.vegetableName.Equals("Blue Berry")) {
                BlueAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
            }
            if (vegetable.vegetableName.Equals("Grape")) {
                grapeAmmo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Ammo: " + vegetable.currentAmmoNumber;
            }

        }
    }
}
