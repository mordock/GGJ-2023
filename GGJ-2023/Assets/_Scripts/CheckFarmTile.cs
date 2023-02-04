using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckFarmTile : MonoBehaviour
{
    Camera cam;

    public GameObject farmPanel;
    public GameObject vegetableOption;

    private bool panelIsOpen = false;
    // Start is called before the first frame update
    void Start() {
        cam = GetComponent<Camera>();
        farmPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject.tag.Equals("FarmTile")) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    //this doens't check for distance, I know, shut up
                    //open ui
                    if (!panelIsOpen) {
                        farmPanel.SetActive(true);
                        panelIsOpen = true;

                        //empty old tiles
                        foreach (Transform child in farmPanel.transform.GetChild(0)) {
                            //Destroy the child
                            Destroy(child.gameObject);
                        }

                        //fill UI with correct amount of tiles
                        List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                        int pressValue = 1;
                        foreach (Vegetable vegetable in vegetables) {
                            if (vegetable.unlocked) {
                                GameObject tile = Instantiate(vegetableOption, farmPanel.transform.GetChild(0));
                                //fill in values of tile
                                tile.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = vegetable.multipleVegetableName;
                                tile.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Amount: " + vegetable.currentNumber;
                                tile.transform.GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Press: " + pressValue;
                                pressValue++;
                            }
                        }
                    } else {
                        farmPanel.SetActive(false);
                        panelIsOpen = false;
                    }
                }
            }

            if (panelIsOpen) {
                if (Input.GetKeyDown(KeyCode.Alpha1)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
                    if (vegetables[0] != null) {
                        hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetables[0]);
                        farmPanel.SetActive(false);
                        panelIsOpen = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha2)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;

                    if (vegetables[1] != null) {
                        hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetables[1]);
                        farmPanel.SetActive(false);
                        panelIsOpen = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha3)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;

                    if (vegetables[2] != null) {
                        hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetables[2]);
                        farmPanel.SetActive(false);
                        panelIsOpen = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha4)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;

                    if (vegetables[3] != null) {
                        hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetables[3]);
                        farmPanel.SetActive(false);
                        panelIsOpen = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha5)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;

                    if (vegetables[4] != null) {
                        hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetables[4]);
                        farmPanel.SetActive(false);
                        panelIsOpen = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Alpha6)) {
                    List<Vegetable> vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;

                    if (vegetables[5] != null) {
                        hit.transform.gameObject.GetComponent<FarmTile>().PlantTile(vegetables[5]);
                        farmPanel.SetActive(false);
                        panelIsOpen = false;
                    }
                }
            }
        } else {
            Debug.Log("nothing");
        }
    }
}
