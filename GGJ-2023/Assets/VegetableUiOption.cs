using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VegetableUiOption : MonoBehaviour
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

    public void FillInUiOptions(int pressNumber, Vegetable vegetable) {
        currentVegetable = vegetable;
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = currentVegetable.vegetableName;
        transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "Amount: " + currentVegetable.currentSeedNumber;
        transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Press: " + pressNumber;
    }
}
