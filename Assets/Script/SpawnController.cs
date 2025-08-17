using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<EnemyWaveConfig> wavesConfigs; 
    [SerializeField] private Quaternion spawnRotation;
    [SerializeField] private float initialWaitTime;
    [SerializeField] private float cadenceBetweenWaves;

    void Start()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        yield return new WaitForSeconds(initialWaitTime);
        foreach (var wave in wavesConfigs)
        {
            foreach (var enemy in wave.enemies)
            {
                Vector3 enemyPosition = Vector3.zero;
                if (enemy.useSpecificXPosition)
                {
                    enemyPosition = enemy.spawnPosition;

                }
                else
                {
                    enemyPosition = new Vector3(Random.Range(-enemy.spawnPosition.x, enemy.spawnPosition.x), enemy.spawnPosition.y, enemy.spawnPosition.z);
                }

                SpawnEnemy(enemyPosition, spawnRotation);
                yield return new WaitForSeconds(wave.cadence);
            }

            yield return new WaitForSeconds(cadenceBetweenWaves); 

        }
    }

    private void SpawnEnemy(Vector3 pos, Quaternion rot)
    {
        GameObject enemy = EnemyPool.Instance.GetEnemy();
        enemy.transform.position = pos;
        enemy.transform.rotation = rot;


    }
}
