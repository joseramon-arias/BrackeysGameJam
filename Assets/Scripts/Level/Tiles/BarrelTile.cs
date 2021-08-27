using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTile : Tile
{
    [SerializeField] private Barrel barrelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateBarrel();
    }

    private void InstantiateBarrel()
    {
        Vector3 position = transform.position;
        position.y += barrelPrefab.transform.localScale.y + transform.localScale.y / 2;
        Instantiate(barrelPrefab, position, Quaternion.identity);
    }
}