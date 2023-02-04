using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour
{
    public float Health = 40;

    public Vegetable currentVegetable;
    [HideInInspector]
    public int currentLevel = 1;

    public GameObject carrotTwo, potatoTwo, onionTwo, beetTwo, grapeTwo, blueTwo;

    public GameObject carrotThree, potatoThree, onionThree, beetThree, grapeThree, blueThree;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (currentVegetable != null) {
            if (currentLevel < 3) {
                StartCoroutine(Grow(20));
            }
        }
    }

    IEnumerator Grow(int secs) {
        yield return new WaitForSeconds(secs);
        ReplaceTile(currentVegetable);
    }

    public void PlantTile(Vegetable vegetableToPlant) {
        currentVegetable = vegetableToPlant;
    }

    public void OnHit(float damage) {
        Health -= damage;
        if (Health <= 0) {
            Destroy(gameObject);
        }
    }

    public void ReplaceTile(Vegetable vegetableToChangeTo) {
        if (vegetableToChangeTo.vegetableName.Equals("Carrot")) {
            Vector3 pos = transform.position;
            if (currentLevel.Equals(1)) {
                var farm = Instantiate(carrotTwo, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            } else if (currentLevel.Equals(2)) {
                var farm = Instantiate(carrotThree, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            }
        }
        if (vegetableToChangeTo.vegetableName.Equals("Onion")) {
            Vector3 pos = transform.position;
            if (currentLevel.Equals(1)) {
                var farm = Instantiate(onionTwo, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            } else if (currentLevel.Equals(2)) {
                var farm = Instantiate(onionThree, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            }
        }
        if (vegetableToChangeTo.vegetableName.Equals("Beet")) {
            Vector3 pos = transform.position;
            if (currentLevel.Equals(1)) {
                var farm = Instantiate(beetTwo, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            } else if (currentLevel.Equals(2)) {
                var farm = Instantiate(beetThree, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            }
        }
        if (vegetableToChangeTo.vegetableName.Equals("Potato")) {
            Vector3 pos = transform.position;
            if (currentLevel.Equals(1)) {
                var farm = Instantiate(potatoTwo, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            } else if (currentLevel.Equals(2)) {
                var farm = Instantiate(potatoThree, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            }
        }
        if (vegetableToChangeTo.vegetableName.Equals("Grape")) {
            Vector3 pos = transform.position;
            if (currentLevel.Equals(1)) {
                var farm = Instantiate(grapeTwo, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            } else if (currentLevel.Equals(2)) {
                var farm = Instantiate(grapeThree, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            }
        }
        if (vegetableToChangeTo.vegetableName.Equals("Blue Berry")) {
            Vector3 pos = transform.position;
            if (currentLevel.Equals(1)) {
                var farm = Instantiate(blueTwo, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            } else if (currentLevel.Equals(2)) {
                var farm = Instantiate(blueThree, pos, Quaternion.identity);
                farm.GetComponent<FarmTile>().currentVegetable = vegetableToChangeTo;
                farm.GetComponent<FarmTile>().currentLevel++;
            }
        }

        Destroy(gameObject);
    }
}
