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

    public float carrotDamage = 20;
    public float potatoDamage = 15;
    public float onionDamage = 10;
    public float beetDamage = 10;
    public float blueberryDamage = 3;
    public float grapeDamage = 5;

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

    private bool canShoot;
    private int currentCooldown;

    private void Start() {
        vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
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
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentAmmo = vegetables[1];
            TurnOffAllSelectedUI();
            carrotSelected.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentAmmo = vegetables[3];
            TurnOffAllSelectedUI();
            potatoSelected.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            currentAmmo = vegetables[2];
            TurnOffAllSelectedUI();
            onionSelected.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            currentAmmo = vegetables[0];
            TurnOffAllSelectedUI();
            beetSelected.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            currentAmmo = vegetables[4];
            TurnOffAllSelectedUI();
            grapeSelected.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            currentAmmo = vegetables[5];
            TurnOffAllSelectedUI();
            blueberrySelected.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0)) {
            if (canShoot) {
                if (currentAmmo.vegetableName.Equals("Carrot") && currentAmmo.currentAmmoNumber >= 0) {
                    var bullet = Instantiate(Carrot, ProjectileSpawn.position, ProjectileSpawn.rotation * Quaternion.Euler(-90f, 0f, 0f));
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * carrotSpeed;
                    bullet.GetComponent<BulletScript>().bulletDamage = carrotDamage;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = carrotCooldown;
                    slider.maxValue = currentCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Potato") && currentAmmo.currentAmmoNumber >= 0) {
                    var bullet = Instantiate(Potato, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * potatoSpeed;
                    bullet.GetComponent<BulletScript>().bulletDamage = potatoDamage;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = potatoCooldown;
                    slider.maxValue = currentCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Onion") && currentAmmo.currentAmmoNumber >= 0) {
                    var bullet = Instantiate(Union, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * onionSpeed;
                    bullet.GetComponent<BulletScript>().bulletDamage = onionDamage;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = onionCooldown;
                    slider.maxValue = currentCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Beet") && currentAmmo.currentAmmoNumber >= 0) {
                    var bullet = Instantiate(Beet, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * beetSpeed;
                    bullet.GetComponent<BulletScript>().bulletDamage = beetDamage;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = beetCooldown;
                    slider.maxValue = currentCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Grape") && currentAmmo.currentAmmoNumber >= 0) {
                    var bullet = Instantiate(Grape, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * grapeSpeed;
                    bullet.GetComponent<BulletScript>().bulletDamage = grapeDamage;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = grapeCooldown;
                    slider.maxValue = currentCooldown;
                }

                if (canShoot && currentAmmo.vegetableName.Equals("Blue Berry") && currentAmmo.currentAmmoNumber >= 0) {
                    var bullet = Instantiate(Blueberry, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * blueberrySpeed;
                    bullet.GetComponent<BulletScript>().bulletDamage = blueberryDamage;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = blueberryCooldown;
                    slider.maxValue = currentCooldown;
                }
            }
        }


        //if (Input.GetMouseButton(0)) {
        //    if (canShoot && currentAmmo.vegetableName.Equals("Blue Berry")) {
        //        var bullet = Instantiate(Blueberry, ProjectileSpawn.position, ProjectileSpawn.rotation);
        //        bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * blueberrySpeed;
        //        bullet.GetComponent<BulletScript>().bulletDamage = blueberryDamage;

        //        bulletCooldown = 0;
        //        canShoot = false;
        //        currentCooldown = blueberryCooldown;
        //    }
        //}

        ////CARROT GUN
        //if (bulletCooldown >= bulletreleaselimit * 300) {
        //    if (Input.GetMouseButtonDown(0)) {
        //        var bullet = Instantiate(Carrot, ProjectileSpawn.position, ProjectileSpawn.rotation);
        //        bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;
        //        bulletCooldown = 0;
        //    }
        //}

        ////POTATO GUN
        //if (bulletCooldown >= bulletreleaselimit * 500) {
        //    if (Input.GetMouseButtonDown(0)) {
        //        var bullet = Instantiate(Potato, ProjectileSpawn.position, ProjectileSpawn.rotation);
        //        bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;
        //        bulletCooldown = 0;
        //    }
        //}

        ////UNION GUN
        //if (bulletCooldown >= bulletreleaselimit * 200) {
        //    if (Input.GetMouseButtonDown(0)) {
        //        var bullet = Instantiate(Union, ProjectileSpawn.position, ProjectileSpawn.rotation);
        //        bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;
        //        bulletCooldown = 0;
        //    }
        //}

        ////BEET GUN
        //if (bulletCooldown >= bulletreleaselimit * 100) {
        //    if (Input.GetMouseButtonDown(0)) {
        //        var bullet = Instantiate(Beet, ProjectileSpawn.position, ProjectileSpawn.rotation);
        //        bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;
        //        bulletCooldown = 0;
        //    }
        //}

        ////BLUEBERRY GUN
        //if (bulletCooldown >= bulletreleaselimit * 30) {
        //    if (Input.GetMouseButtonDown(0)) {
        //        var bullet = Instantiate(Blueberry, ProjectileSpawn.position, ProjectileSpawn.rotation);
        //        bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;
        //        bulletCooldown = 0;
        //    }
        //}

        ////GRAPE GUN
        //if (bulletCooldown >= bulletreleaselimit * 150) {
        //    if (Input.GetMouseButtonDown(0)) {
        //        var bullet = Instantiate(Grape, ProjectileSpawn.position, ProjectileSpawn.rotation);
        //        bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;
        //        bulletCooldown = 0;
        //    }
        //}
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

