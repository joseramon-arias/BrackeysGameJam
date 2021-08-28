using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDummy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            ISlime slime = other.GetComponent<ISlime>();
            if (slime != null)
            {
                slime.TakeDamage(5);
            }
        }
    }
}
