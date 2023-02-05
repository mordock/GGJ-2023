using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableList : MonoBehaviour
{
    public List<Vegetable> vegetables;

    void Start() {

    }


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
                vegetable.currentSeedNumber += amount;
                break;
            }
        }
    }

    public void DecreaseVegetableSeedNumber(string name, int amount) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.vegetableName.Equals(name)) {
                vegetable.currentSeedNumber -= amount;
                break;
            }
        }
    }

    public void IncreaseVegetableAmmoNumber(string name, int amount) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.vegetableName.Equals(name)) {
                vegetable.currentAmmoNumber += amount;
                break;
            }
        }
    }

    public void DecreaseVegetableAmmoNumber(string name, int amount) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.vegetableName.Equals(name)) {
                vegetable.currentAmmoNumber -= amount;
                break;
            }
        }
    }
}
