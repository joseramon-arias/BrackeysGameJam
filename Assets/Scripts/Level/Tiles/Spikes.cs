using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    SpikesTile parentTile;

    private void Start()
    {
        parentTile = transform.parent.GetComponent<SpikesTile>();
    }

    private void OnTriggerEnter(Collider other)
    {
        parentTile.OnChildTriggerEnter(other);
    }
}
