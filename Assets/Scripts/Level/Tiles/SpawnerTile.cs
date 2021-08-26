using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTile : Tile
{
    [SerializeField] private Enemy[] enemiesPrefabs;
    // How much time to wait between each spawn
    [SerializeField] private float coolDownSeconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            yield return new WaitForSeconds(coolDownSeconds);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemyToSpawn = enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)];
        Vector3 spawningPosition = transform.position;
        spawningPosition.y += enemyToSpawn.transform.localScale.y + transform.localScale.y / 2;
        Enemy spawnedEnemy = Instantiate(enemyToSpawn, spawningPosition, Quaternion.identity);
    }
}
