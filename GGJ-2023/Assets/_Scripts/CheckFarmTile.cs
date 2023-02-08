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
    List<Vegetable> vegetableDataObjects;
    // Start is called before the first frame update
    void Start() {
        farmPanel.SetActive(false);

        vegetableDataObjects = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
    }

    // Update is called once per frame
    void Update() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject.tag.Equals("FarmTile")) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    if (hit.transform.gameObject.GetComponent<FarmTile>().currentLevel < 2) {
                        //this doens't check for distance, I know, shut up
                        //open ui
                        if (!panelIsOpen) {
                            farmPanel.SetActive(true);
                            panelIsOpen = true;

                            //empty old tiles
                            foreach (Transform child in farmPanel.transform.GetChild(0)) {
                                //Destroy the children
                                Destroy(child.gameObject);
                            }

                            //fill UI with correct amount of tiles
                            int pressValue = 1;
                            foreach (Vegetable vegetable in vegetableDataObjects) {
                                if (vegetable.unlocked) {
                                    GameObject tile = Instantiate(vegetableOption, farmPanel.transform.GetChild(0));
                                    //fill in values of tile
                                    tile.GetComponent<VegetableUiOption>().FillInUiOptions(pressValue, vegetable);
                                    pressValue++;
                                }
                            }
                        } else {
                            farmPanel.SetActive(false);
                            panelIsOpen = false;
                        }
                    } else {
                        //get ammo from fully grown farm tile
                        VegetableManager.VegetableType plantedVegetableType = hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.type;
                        if (plantedVegetableType.Equals(VegetableManager.VegetableType.Carrot)) {
                            FarmTile(hit);
                        }
                        if (plantedVegetableType.Equals(VegetableManager.VegetableType.Beet)) {
                            FarmTile(hit);
                        }
                        if (plantedVegetableType.Equals(VegetableManager.VegetableType.Onion)) {
                            FarmTile(hit);
                        }
                        if (plantedVegetableType.Equals(VegetableManager.VegetableType.Potato)) {
                            FarmTile(hit);
                        }
                        if (plantedVegetableType.Equals(VegetableManager.VegetableType.Berry)) {
                            FarmTile(hit);
                        }
                        if (plantedVegetableType.Equals(VegetableManager.VegetableType.Grape)) {
                            FarmTile(hit);
                        }
                    }
                }
            }

            //plant something if farm UI is opened
            if (panelIsOpen) {
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    ReplaceTile(hit, 0);
                }

                if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    ReplaceTile(hit, 1);
                }

                if (Input.GetKeyDown(KeyCode.Alpha3)) {
                    ReplaceTile(hit, 2);
                }

                if (Input.GetKeyDown(KeyCode.Alpha4)) {
                    ReplaceTile(hit, 3);
                }

                if (Input.GetKeyDown(KeyCode.Alpha5)) {
                    ReplaceTile(hit, 4);
                }

                if (Input.GetKeyDown(KeyCode.Alpha6)) {
                    ReplaceTile(hit, 5);
                }
            }
        }
    }

    public void FarmTile(RaycastHit hit) {
        GameObject.Find("GameManager").GetComponent<VegetableList>().IncreaseVegetableAmmoNumber(hit.transform.gameObject.GetComponent<FarmTile>().currentVegetable.vegetableName, 5);
        Vector3 pos = hit.transform.position;
        Destroy(hit.transform.gameObject);
        Instantiate(farmEmpty, pos, Quaternion.identity);
    }

    public void ReplaceTile(RaycastHit hit, int objectPos) {
        VegetableManager.VegetableType chosenType = farmPanel.transform.GetChild(0).GetChild(objectPos).GetComponent<VegetableUiOption>().currentVegetable.type;
        foreach (Vegetable vegetable in vegetableDataObjects) {
            if (vegetable.type.Equals(chosenType)) {
                if (vegetable.currentSeedNumber > 0) {
                    hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetable);
                    farmPanel.SetActive(false);
                    panelIsOpen = false;
                    ChangeToTileOne(vegetable, hit);
                    break;
                } else {
                    Debug.Log("not enough seeds popup");
                }
            }
        }
    }

    public void ChangeToTileOne(Vegetable vegetableToChangeTo, RaycastHit hit) {
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
