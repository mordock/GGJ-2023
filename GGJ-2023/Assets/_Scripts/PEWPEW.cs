using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PEWPEW : MonoBehaviour
{
    public Transform ProjectileSpawn;
    public Slider slider;

    [Header("bullet objects")]
    public GameObject Carrot;
    public GameObject Potato;
    public GameObject Union;
    public GameObject Beet;
    public GameObject Blueberry;
    public GameObject Grape;

    [Header("bullet values")]
    public float carrotSpeed = 80;
    public float potatoSpeed = 12;
    public float onionSpeed = 20;
    public float beetSpeed = 20;
    public float blueberrySpeed = 30;
    public float grapeSpeed = 30;

    public float bulletCooldown = 0;
    public float bulletreleaselimit = 0;

    [Header("cooldowns")]
    public int carrotCooldown;
    public int potatoCooldown;
    public int onionCooldown;
    public int beetCooldown;
    public int blueberryCooldown;
    public int grapeCooldown;

    [Header("UI Elements")]
    public GameObject carrotSelected;
    public GameObject potatoSelected;
    public GameObject onionSelected;
    public GameObject beetSelected;
    public GameObject blueberrySelected;
    public GameObject grapeSelected;

    public Vegetable currentAmmo;
    private List<Vegetable> vegetables;
    private VegetableList vegetableList;

    private bool canShoot;
    private int currentCooldown;

    private float beetExplosionTime = 5;

    private void Start() {
        vegetableList = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>();
        vegetables = vegetableList.vegetables;
        currentAmmo = vegetables[0];
    }
    public void FixedUpdate() {
        bulletCooldown++;
        if (bulletCooldown >= currentCooldown) {
            canShoot = true;
        }
    }
    public void Update() {
        slider.value = bulletCooldown;
        //fix with extra rule so it doesn't mess with farm tiles
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            if (vegetables[1].unlocked) {
                currentAmmo = vegetables[1];
                TurnOffAllSelectedUI();
                carrotSelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            if (vegetables[3].unlocked) {
                currentAmmo = vegetables[3];
                TurnOffAllSelectedUI();
                potatoSelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (vegetables[2].unlocked) {
                currentAmmo = vegetables[2];
                TurnOffAllSelectedUI();
                onionSelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            if (vegetables[0].unlocked) {
                currentAmmo = vegetables[0];
                TurnOffAllSelectedUI();
                beetSelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (vegetables[4].unlocked) {
                currentAmmo = vegetables[4];
                TurnOffAllSelectedUI();
                blueberrySelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("MIEP");
            if (vegetables[5].unlocked) {
                currentAmmo = vegetables[5];
                TurnOffAllSelectedUI();
                grapeSelected.SetActive(true);
                Debug.Log("BIEP");
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            if (canShoot) {
                if (currentAmmo.vegetableName.Equals("Carrot") && currentAmmo.currentAmmoNumber > 0) {
                    var bullet = Instantiate(Carrot, ProjectileSpawn.position, ProjectileSpawn.rotation * Quaternion.Euler(-90f, 0f, 0f));
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * carrotSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = carrotCooldown;
                    slider.maxValue = currentCooldown;

                    vegetableList.DecreaseVegetableAmmoNumber("Carrot", 1);
                }

                if (currentAmmo.vegetableName.Equals("Potato") && currentAmmo.currentAmmoNumber > 0) {
                    var bullet = Instantiate(Potato, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * potatoSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = potatoCooldown;
                    slider.maxValue = currentCooldown;

                    vegetableList.DecreaseVegetableAmmoNumber("Potato", 1);
                }

                if (currentAmmo.vegetableName.Equals("Onion") && currentAmmo.currentAmmoNumber > 0) {
                    var bullet = Instantiate(Union, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * onionSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = onionCooldown;
                    slider.maxValue = currentCooldown;

                    vegetableList.DecreaseVegetableAmmoNumber("Onion", 1);
                }

                if (currentAmmo.vegetableName.Equals("Beet") && currentAmmo.currentAmmoNumber > 0) {
                    var bullet = Instantiate(Beet, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * beetSpeed;
                    bullet.GetComponent<BulletScript>().beetExplosionTimer = beetExplosionTime;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = beetCooldown;
                    slider.maxValue = currentCooldown;

                    vegetableList.DecreaseVegetableAmmoNumber("Beet", 1);
                }

                if (currentAmmo.vegetableName.Equals("Grape") && currentAmmo.currentAmmoNumber > 0) {
                    var bullet = Instantiate(Grape, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * grapeSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = grapeCooldown;
                    slider.maxValue = currentCooldown;

                    vegetableList.DecreaseVegetableAmmoNumber("Grape", 1);
                }

                if (canShoot && currentAmmo.vegetableName.Equals("Blue Berry") && currentAmmo.currentAmmoNumber > 0) {
                    var bullet = Instantiate(Blueberry, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * blueberrySpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = blueberryCooldown;
                    slider.maxValue = currentCooldown;

                    vegetableList.DecreaseVegetableAmmoNumber("Blue Berry", 1);
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (canShoot && currentAmmo.vegetableName.Equals("Blue Berry") && currentAmmo.currentAmmoNumber > 0)
            {
                var bullet = Instantiate(Blueberry, ProjectileSpawn.position, ProjectileSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * blueberrySpeed;

                bulletCooldown = 0;
                canShoot = false;
                currentCooldown = blueberryCooldown;
                slider.maxValue = currentCooldown;

                vegetableList.DecreaseVegetableAmmoNumber("Blue Berry", 1);
            }
        }
    }

    void TurnOffAllSelectedUI() {
        carrotSelected.SetActive(false);
        potatoSelected.SetActive(false);
        onionSelected.SetActive(false);
        beetSelected.SetActive(false);
        blueberrySelected.SetActive(false);
        grapeSelected.SetActive(false);
    }
}

