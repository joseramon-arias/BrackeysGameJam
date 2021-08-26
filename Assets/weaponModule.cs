using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum Type
{
    damage,
    support,
    mechanical
}

[CreateAssetMenu(fileName = "Module", menuName = "Weapon Module", order = 0)]
public class WeaponModule : ScriptableObject
{
    public GameObject prefab;
    public Type type;
    public string name = "module name";
    [Multiline]
    public string description = "sample description";
    public Sprite icon;


    /// <summary>
    /// Declares a new Weapon Module
    /// </summary>
    /// <param name="moduleDistance">Distance from the player (in modules)</param>
    public WeaponModule()
    {

    }
}
