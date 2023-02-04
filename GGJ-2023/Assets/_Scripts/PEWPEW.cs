using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEWPEW : MonoBehaviour
{
    public Transform ProjectileSpawn;

    [Header("bullet objects")]
    public GameObject Carrot;
    public GameObject Potato;
    public GameObject Union;
    public GameObject Beet;
    public GameObject Blueberry;
    public GameObject Grape;

    [Header("bullet values")]
    public float bulletSpeed = 0;
    public float bulletCooldown = 0;
    public float bulletreleaselimit = 0;

    [Header("cooldowns")]
    public int carrotCooldown;
    public int potatoCooldown;
    public int unionCooldown;
    public int beetCooldown;
    public int blueberryCooldown;
    public int grapeCooldown;

    public Vegetable currentAmmo;
    private List<Vegetable> vegetables;

    private bool canShoot;
    private int currentCooldown;

    private void Start() {
        vegetables = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>().vegetables;
    }
    public void FixedUpdate() {
        bulletCooldown++;
        if(bulletCooldown >= currentCooldown) {
            canShoot = true;
        }
    }
    public void Update() {
        //fix with extra rule so it doesn't mess with farm tiles
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentAmmo = vegetables[1];
        }else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentAmmo = vegetables[3];
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            currentAmmo = vegetables[2];
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            currentAmmo = vegetables[0];
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            currentAmmo = vegetables[4];
        } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            currentAmmo = vegetables[5];
        }

        if (Input.GetMouseButtonDown(0)) {
            if (canShoot) {
                if (currentAmmo.vegetableName.Equals("Carrot")) {
                    var bullet = Instantiate(Carrot, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = carrotCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Potato")) {
                    var bullet = Instantiate(Potato, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = potatoCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Union")) {
                    var bullet = Instantiate(Union, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = unionCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Beet")) {
                    var bullet = Instantiate(Beet, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = beetCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Blue Berry")) {
                    var bullet = Instantiate(Blueberry, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = blueberryCooldown;
                }

                if (currentAmmo.vegetableName.Equals("Grape")) {
                    var bullet = Instantiate(Grape, ProjectileSpawn.position, ProjectileSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;

                    bulletCooldown = 0;
                    canShoot = false;
                    currentCooldown = grapeCooldown;
                }
            }
        }


        //CARROT GUN
        //if (bulletCooldown >= bulletreleaselimit * 300) {
        //    if (Input.GetMouseButtonDown(0)) {
        //        var bullet = Instantiate(Carrot, ProjectileSpawn.position, ProjectileSpawn.rotation);
        //        bullet.GetComponent<Rigidbody>().velocity = ProjectileSpawn.forward * bulletSpeed;
        //        bulletCooldown = 0;
        //    }
        //}

        //POTATO GUN
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
}

