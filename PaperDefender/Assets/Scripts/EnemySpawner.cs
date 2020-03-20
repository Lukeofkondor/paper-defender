﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;



    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }


    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(spawnAllEnemiesInWave(currentWave));

        }
    }

    private IEnumerator spawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int EnemyCount = 0; EnemyCount < waveConfig.GetNumberOfEnemies(); EnemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                        waveConfig.GetWaveWaypoints()[0].transform.position,
                        Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }




    }
}
