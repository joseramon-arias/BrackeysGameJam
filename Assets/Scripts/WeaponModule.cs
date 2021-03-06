using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum ModuleType
{
    damage,
    support,
    mechanical
}

[CreateAssetMenu(fileName = "Module", menuName = "Weapon Module", order = 0)]
public class WeaponModule : ScriptableObject
{
    //[HideInInspector] public GameObject instance;
    public GameObject prefab;
    public ModuleType type;
    public string name = "module name";
    [TextArea]
    public string description = "sample description";
    public Sprite icon;

    public WeaponModule()
    {

    }
}
