using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTile : Tile
{
    private WaveManager waveManager;

    // Start is called before the first frame update
    void Start()
    {
        waveManager = GameObject.FindObjectOfType<WaveManager>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            int timeToWait = Random.Range(waveManager.CurrentWaveParameters.MinSpawnSpeed,
                                          waveManager.CurrentWaveParameters.MaxSpawnSpeed);
            yield return new WaitForSeconds(timeToWait);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemyToSpawn = waveManager.GetNextEnemyInStack();
        Vector3 spawningPosition = transform.position;
        spawningPosition.y += enemyToSpawn.transform.localScale.y + transform.localScale.y / 2;
        Instantiate(enemyToSpawn, spawningPosition, Quaternion.identity);
    }
}
