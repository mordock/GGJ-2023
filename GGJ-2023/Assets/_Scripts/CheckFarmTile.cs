using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckFarmTile : MonoBehaviour
{
    public Camera cam;

    public GameObject farmPanel;
    public GameObject vegetableOption;

    public GameObject carrotOne, potatoOne, onionOne, beetOne, grapeOne, blueOne;

    public GameObject farmEmpty;
    private bool panelIsOpen = false;
    // Start is called before the first frame update
    void Start() {
        farmPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject.tag.Equals("FarmTile")) {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.gameObject.GetComponent<FarmTile>().currentLevel < 2)
                    {
                        //this doens't check for distance, I know, shut up
                        //open ui
                        if (!panelIsOpen)
                        {
                            farmPanel.SetActive(true);
                            panelIsOpen = true;

                            //empty old tiles
                            foreach (Transform child in farmPanel.transform.GetChild(0)) {
                                //Destroy the children
                                Destroy(child.gameObject);
                            }

                            //fill UI with correct amount of tiles
                            List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                            int pressValue = 1;
                            foreach (Vegetable vegetable in vegetables)
                            {
                                if (vegetable.unlocked)
                                {
                                    GameObject tile = Instantiate(vegetableOption, farmPanel.transform.GetChild(0));
                                    //fill in values of tile
                                    tile.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = vegetable.vegetableName;
                                    tile.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Amount: " + vegetable.currentSeedNumber;
                                    tile.transform.GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Press: " + pressValue;
                                    pressValue++;
                                }
                            }
                        }
                        else
                        {
                            farmPanel.SetActive(false);
                            panelIsOpen = false;
                        }
                    }
                    else
                    {
                        string name = hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.vegetableName;
                        if (name.Equals("Carrot"))
                        {
                            //farm vegetable and get ammo
                            GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableAmmoNumber(hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.vegetableName, 5);
                            Vector3 pos = hit.transform.position;
                            Destroy(hit.transform.gameObject);
                            var farm = Instantiate(farmEmpty, pos, Quaternion.identity);
                        }
                        if (name.Equals("Beet"))
                        {
                            //farm vegetable and get ammo
                            GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableAmmoNumber(hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.vegetableName, 5);
                            Vector3 pos = hit.transform.position;
                            Destroy(hit.transform.gameObject);
                            var farm = Instantiate(farmEmpty, pos, Quaternion.identity);
                        }
                        if (name.Equals("Onion"))
                        {
                            //farm vegetable and get ammo
                            GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableAmmoNumber(hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.vegetableName, 10);
                            Vector3 pos = hit.transform.position;
                            Destroy(hit.transform.gameObject);
                            var farm = Instantiate(farmEmpty, pos, Quaternion.identity);
                        }
                        if (name.Equals("Potato"))
                        {
                            //farm vegetable and get ammo
                            GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableAmmoNumber(hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.vegetableName, 5);
                            Vector3 pos = hit.transform.position;
                            Destroy(hit.transform.gameObject);
                            var farm = Instantiate(farmEmpty, pos, Quaternion.identity);
                        }
                        if (name.Equals("Blue Berry"))
                        {
                            //farm vegetable and get ammo
                            GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableAmmoNumber(hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.vegetableName, 40);
                            Vector3 pos = hit.transform.position;
                            Destroy(hit.transform.gameObject);
                            var farm = Instantiate(farmEmpty, pos, Quaternion.identity);
                        }
                        if (name.Equals("Grape"))
                        {
                            //farm vegetable and get ammo
                            GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableAmmoNumber(hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.vegetableName, 10);
                            Vector3 pos = hit.transform.position;
                            Destroy(hit.transform.gameObject);
                            var farm = Instantiate(farmEmpty, pos, Quaternion.identity);
                        }
                    }
                }
            }

            if (panelIsOpen) {
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                    string chosenName = farmPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

                    foreach(Vegetable vegetable in vegetables) {
                        if (vegetable.name.Equals(chosenName)) {
                            hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetable);
                            farmPanel.SetActive(false);
                            panelIsOpen = false;
                            ReplaceTile(vegetable, hit);
                            break;
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                    string chosenName = farmPanel.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

                    foreach (Vegetable vegetable in vegetables) {
                        if (vegetable.name.Equals(chosenName)) {
                            hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetable);
                            farmPanel.SetActive(false);
                            panelIsOpen = false;
                            ReplaceTile(vegetable, hit);
                            break;
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha3)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                    string chosenName = farmPanel.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

                    foreach (Vegetable vegetable in vegetables) {
                        if (vegetable.name.Equals(chosenName)) {
                            hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetable);
                            farmPanel.SetActive(false);
                            panelIsOpen = false;
                            ReplaceTile(vegetable, hit);
                            break;
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha4)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                    string chosenName = farmPanel.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

                    foreach (Vegetable vegetable in vegetables) {
                        if (vegetable.name.Equals(chosenName)) {
                            hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetable);
                            farmPanel.SetActive(false);
                            panelIsOpen = false;
                            ReplaceTile(vegetable, hit);
                            break;
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha5)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                    string chosenName = farmPanel.transform.GetChild(0).GetChild(4).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

                    foreach (Vegetable vegetable in vegetables) {
                        if (vegetable.name.Equals(chosenName)) {
                            hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetable);
                            farmPanel.SetActive(false);
                            panelIsOpen = false;
                            ReplaceTile(vegetable, hit);
                            break;
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha6)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                    string chosenName = farmPanel.transform.GetChild(0).GetChild(6).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

                    foreach (Vegetable vegetable in vegetables) {
                        if (vegetable.name.Equals(chosenName)) {
                            hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetable);
                            farmPanel.SetActive(false);
                            panelIsOpen = false;
                            ReplaceTile(vegetable, hit);
                            break;
                        }
                    }
                }
            }
        } else {
            //Debug.Log("nothing");
        }
    }

    public void ReplaceTile(Vegetable vegetableToChangeTo, RaycastHit hit) {
        if (vegetableToChangeTo.vegetableName.Equals("Carrot")) {
            Vector3 pos = hit.transform.position;
            var farm = Instantiate(carrotOne, pos, Quaternion.identity);
            farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
        }
        if (vegetableToChangeTo.vegetableName.Equals("Onion")) {
            Vector3 pos = hit.transform.position;
            var farm = Instantiate(onionOne, pos, Quaternion.identity);
            farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
        }
        if (vegetableToChangeTo.vegetableName.Equals("Beet")) {
            Vector3 pos = hit.transform.position;
            var farm = Instantiate(beetOne, pos, Quaternion.identity);
            farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
        }
        if (vegetableToChangeTo.vegetableName.Equals("Potato")) {
            Vector3 pos = hit.transform.position;
            var farm = Instantiate(potatoOne, pos, Quaternion.identity);
            farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
        }
        if (vegetableToChangeTo.vegetableName.Equals("Grape")) {
            Vector3 pos = hit.transform.position;
            var farm = Instantiate(grapeOne, pos, Quaternion.identity);
            farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
        }
        if (vegetableToChangeTo.vegetableName.Equals("Blue Berry")) {
            Vector3 pos = hit.transform.position;
            var farm = Instantiate(blueOne, pos, Quaternion.identity);
            farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
        }

        Destroy(hit.transform.gameObject);
        vegetableToChangeTo.currentSeedNumber--;
    }
}
