using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private GoldSpawner goldSpawner;

    private void Start()
    {
        goldSpawner = GetComponent<GoldSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        WeaponDummy weaponDummy = other.gameObject.GetComponent<WeaponDummy>();

        if (weaponDummy != null)
        {
            goldSpawner.SpawnGold();
            Destroy(gameObject);
        }
    }
}
