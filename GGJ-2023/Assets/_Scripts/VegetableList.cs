using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableList : MonoBehaviour
{
    public List<Vegetable> vegetables;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void UnlockVegetable(string name) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.vegetableName.Equals(name)) {
                vegetable.unlocked = true;
                break;
            }
        }
    }

    public void IncreaseVegetableSeedNumber(string name, int amount) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.vegetableName.Equals(name)) {
                vegetable.currentNumber += amount;
                break;
            }
        }
    }

    public void DecreaseVegetableSeedNumber(string name, int amount) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.vegetableName.Equals(name)) {
                vegetable.currentNumber -= amount;
                break;
            }
        }
    }
}
