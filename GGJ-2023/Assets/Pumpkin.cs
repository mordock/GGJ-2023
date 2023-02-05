using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pumpkin : MonoBehaviour
{
    public GameObject pumpkin1, pumpkin2, pumpkin3;
    public TextMeshProUGUI pumpkinUI;
    public float pumpkinGrowthTime;

    private int level = 0;
    private GameObject player;

    [HideInInspector]
    public bool hasPumpkin;
    // Start is called before the first frame update
    void Start() {
        pumpkin2.SetActive(false);
        pumpkin3.SetActive(false);

        InvokeRepeating("Grow", 0, pumpkinGrowthTime);

        pumpkinUI.text = "We DON'T have a Pumpkin!";

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (level.Equals(1)) {
            pumpkin1.SetActive(true);
            pumpkin2.SetActive(false);
            pumpkin3.SetActive(false);
        } else if (level.Equals(2)) {
            pumpkin1.SetActive(false);
            pumpkin2.SetActive(true);
            pumpkin3.SetActive(false);
        } else if (level.Equals(3)) {
            pumpkin1.SetActive(false);
            pumpkin2.SetActive(false);
            pumpkin3.SetActive(true);
        }

        float dist = Vector3.Distance(player.transform.position, transform.position);


        if (level >= 3) {
            if (Input.GetKeyDown(KeyCode.F)) {
                if (dist <= 5) {
                    level = 1;
                    hasPumpkin = true;
                    pumpkinUI.text = "You have a pumpkin! You can destroy gopher nests with this (press F)";
                }
            }
        }
    }

    void Grow() {
        level++;
    }
}
