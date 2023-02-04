using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
    public GameObject pumpkin1, pumpkin2, pumpkin3;

    private int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        pumpkin2.SetActive(false);
        pumpkin3.SetActive(false);

        InvokeRepeating("Grow", 0, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(level);
        //StartCoroutine(Grow(5));

        if (level.Equals(1)) {
            pumpkin1.SetActive(true);
            pumpkin2.SetActive(false);
            pumpkin3.SetActive(false);
        }else if (level.Equals(2)) {
            pumpkin1.SetActive(false);
            pumpkin2.SetActive(true);
            pumpkin3.SetActive(false);
        }else if (level.Equals(3)) {
            pumpkin1.SetActive(false);
            pumpkin2.SetActive(false);
            pumpkin3.SetActive(true);
        }

        if (level.Equals(2)) {

        }
    }

    void Grow() {
        level++;
    }
}
