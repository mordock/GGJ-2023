using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Vegetable Base")]
public class VegetableBaseValue : ScriptableObject
{
    public VegetableManager.VegetableType vegetableType;
    public int baseAmmo;
    public int baseSeed;

    public bool unlocked;

    public Sprite icon;
}
