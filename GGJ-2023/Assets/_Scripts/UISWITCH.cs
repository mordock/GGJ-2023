using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISWITCH : MonoBehaviour
{
    public GameObject Carrot;
    public GameObject Potato;
    public GameObject Beet;
    public GameObject Union;
    public GameObject Blueberry;
    public GameObject Grape;
    void Start()
    {
        Carrot.SetActive(false);
        Potato.SetActive(false);
        Beet.SetActive(false);
        Union.SetActive(false);
        Blueberry.SetActive(false);
        Grape.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
