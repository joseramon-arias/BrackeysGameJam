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
    //[HideInInspector] public GameObject instance;
    public GameObject prefab;
    public Type type;
    public string name = "module name";
    [Multiline]
    public string description = "sample description";
    public Sprite icon;

    public WeaponModule()
    {

    }
}
