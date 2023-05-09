using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VegetableList : MonoBehaviour
{
    public List<Vegetable> vegetables;

    void Start() {

    }


    void Update() {

    }

    public void UnlockVegetable(VegetableManager.VegetableType type) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.type.Equals(type)) {
                vegetable.currentUnlocked = true;
                break;
            }
        }
    }

    public void IncreaseVegetableSeedNumber(VegetableManager.VegetableType type, int amount) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.type.Equals(type)) {
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

    public void DecreaseVegetableAmmoNumber(VegetableManager.VegetableType type, int amount) {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.type.Equals(type)) {
                vegetable.currentAmmoNumber -= amount;
                break;
            }
        }
    }
}
