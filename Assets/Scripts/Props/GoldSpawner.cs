using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldPrefab;
    [SerializeField, Range(1, 5)] private int maxGoldToSpawn;
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionPower;

    public void SpawnGold()
    {
        Vector3 explosionPos = transform.position;

        int numberOfGold = Random.Range(1, maxGoldToSpawn + 1);
        for (int i = 0; i < numberOfGold; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfGold;
            Vector3 newPos = explosionPos + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
            GameObject gold = Instantiate(goldPrefab, newPos, Quaternion.identity);
            gold.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPos, explosionRadius, 3.0f, ForceMode.Force);
        }
    }
}
