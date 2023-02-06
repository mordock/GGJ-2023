using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public float health = 1;
    public Slider slider; 

    void Start()
    {

    }

    void Update()
    {
    }

    public void Hit(float damage)
    {
        health -= damage;
        UpdateHealthBar();

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void UpdateHealthBar() {
        slider.value = health;
    }
}
