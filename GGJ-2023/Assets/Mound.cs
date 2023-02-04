using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mound : MonoBehaviour
{
    public GameObject mound;
    public bool isCopy;
    public float reduceAmount;
    float timePassed = 0f;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (!isCopy) {
            transform.Translate(new Vector3(0, 2 * Time.deltaTime, 0));
            timePassed += Time.deltaTime;
            if (timePassed > 0.25f) {
                //do something
                GameObject newMound = Instantiate(mound);
                newMound.GetComponent<Mound>().isCopy = true;
                timePassed = 0;
            }
        }

        if (isCopy) {
            Vector3 currentScale = transform.localScale;
            transform.localScale = currentScale - new Vector3(reduceAmount, reduceAmount, reduceAmount);

            if(currentScale.x <= 0) {
                Destroy(gameObject);
            }

            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    IEnumerator Spawn(float secs) {
        GameObject newMound = Instantiate(mound);
        newMound.GetComponent<Mound>().isCopy = true;
        yield return new WaitForSeconds(secs);
    }
}
