using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

<<<<<<< HEAD:Assets/weaponModule.cs
public enum Type
=======
public class WeaponModule : MonoBehaviour
>>>>>>> develop:Assets/Scripts/WeaponModule.cs
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
