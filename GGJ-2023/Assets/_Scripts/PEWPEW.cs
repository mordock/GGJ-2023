using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PEWPEW : MonoBehaviour
{
    public Transform ProjectileSpawn;
    public Slider cooldownSlider;

    [Header("bullet objects")]
    public GameObject carrotBullet;
    public GameObject potatoBullet;
    public GameObject unionBullet;
    public GameObject beetBullet;
    public GameObject blueberryBullet;
    public GameObject grapeBullet;

    private float bulletCooldown = 0;

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

    private Vegetable currentAmmo;
    private List<Vegetable> vegetables;
    private VegetableList vegetableList;

    private Vegetable alpha1Vegetable, alpha2Vegetable, alpha3Vegetable, alpha4Vegetable, alpha5Vegetable, alpha6Vegetable;

    private bool canShoot;
    private int currentCooldown;

    private void Start() {
        vegetableList = GameObject.Find("GameManager").gameObject.GetComponent<VegetableList>();
        vegetables = vegetableList.vegetables;

        TurnOffAllSelectedUI();

        currentAmmo = vegetables[5];

        grapeSelected.SetActive(true);

        FillAlphaVegetables();
    }

    public void FixedUpdate() {
        bulletCooldown++;
        if (bulletCooldown >= currentCooldown) {
            canShoot = true;
        }
    }
    public void Update() {
        cooldownSlider.value = bulletCooldown;
        //fix with extra rule so it doesn't mess with farm tiles
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            if (alpha6Vegetable.currentUnlocked) {
                currentAmmo = alpha6Vegetable;
                TurnOffAllSelectedUI();
                carrotSelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            if (vegetables[3].currentUnlocked) {
                currentAmmo = vegetables[3];
                TurnOffAllSelectedUI();
                potatoSelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (vegetables[2].currentUnlocked) {
                currentAmmo = vegetables[2];
                TurnOffAllSelectedUI();
                onionSelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            if (vegetables[0].currentUnlocked) {
                currentAmmo = vegetables[0];
                TurnOffAllSelectedUI();
                beetSelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (vegetables[4].currentUnlocked) {
                currentAmmo = vegetables[4];
                TurnOffAllSelectedUI();
                blueberrySelected.SetActive(true);
            }
        } else if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (vegetables[5].currentUnlocked) {
                currentAmmo = vegetables[5];
                TurnOffAllSelectedUI();
                grapeSelected.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            if (canShoot) {
                if (currentAmmo.currentAmmoNumber > 0) {
                    if (currentAmmo.type.Equals(VegetableManager.VegetableType.Carrot)) {
                        Shoot(carrotBullet, carrotCooldown, currentAmmo);
                    }

                    if (currentAmmo.type.Equals(VegetableManager.VegetableType.Potato)) {
                        Shoot(potatoBullet, potatoCooldown, currentAmmo);
                    }

                    if (currentAmmo.type.Equals(VegetableManager.VegetableType.Onion)) {
                        Shoot(unionBullet, onionCooldown, currentAmmo);
                    }

                    if (currentAmmo.type.Equals(VegetableManager.VegetableType.Beet)) {
                        Shoot(beetBullet, beetCooldown, currentAmmo);
                    }

                    if (currentAmmo.type.Equals(VegetableManager.VegetableType.Grape)) {
                        Shoot(grapeBullet, grapeCooldown, currentAmmo);
                    }

                    if (currentAmmo.type.Equals(VegetableManager.VegetableType.Berry)) {
                        Shoot(blueberryBullet, blueberryCooldown, currentAmmo);
                    }
                }
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

    void Shoot(GameObject bulletObject, int cooldown, Vegetable vegetable) {
        var bullet = Instantiate(bulletObject, ProjectileSpawn.position, ProjectileSpawn.rotation);
        bullet.GetComponent<BulletScript>().SetAngle(ProjectileSpawn.forward);

        bulletCooldown = 0;
        canShoot = false;
        currentCooldown = cooldown;
        cooldownSlider.maxValue = currentCooldown;

        vegetableList.DecreaseVegetableAmmoNumber(vegetable.type, 1);
    }

    private void FillAlphaVegetables() {
        foreach (Vegetable vegetable in vegetables) {
            if (vegetable.location.Equals(VegetableManager.KeyboardLocation.Alpha1)) {
                alpha1Vegetable = vegetable;
                break;
            }
            if (vegetable.location.Equals(VegetableManager.KeyboardLocation.Alpha2)) {
                alpha2Vegetable = vegetable;
                break;
            }
            if (vegetable.location.Equals(VegetableManager.KeyboardLocation.Alpha3)) {
                alpha3Vegetable = vegetable;
                break;
            }
            if (vegetable.location.Equals(VegetableManager.KeyboardLocation.Alpha4)) {
                alpha4Vegetable = vegetable;
                break;
            }
            if (vegetable.location.Equals(VegetableManager.KeyboardLocation.Alpha5)) {
                alpha5Vegetable = vegetable;
                break;
            }
            if (vegetable.location.Equals(VegetableManager.KeyboardLocation.Alpha6)) {
                alpha6Vegetable = vegetable;
                break;
            }
        }
    }
}