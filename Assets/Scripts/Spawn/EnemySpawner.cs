using System.Collections;
using System.Collections.Generic;
using Moon.AI;
using Moon.Manager;
using UnityEngine;

namespace Moon.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<EnemyWaveConfig> waveConfigs;
        [SerializeField] float timeBetweenWaves = 5f;
        [SerializeField] bool isLooping = false;
        int startingWave = 0;
        bool isWinned = false;

        LevelManager levelManager;

        IEnumerator Start()
        {
            levelManager = FindObjectOfType<LevelManager>();

            do
            {
                yield return StartCoroutine(SpawnAllWaves());
            }
            while (isLooping);
        }

        private IEnumerator SpawnAllWaves()
        {
            for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
            {
                StartCoroutine(SpawnEnemiesInWave(waveConfigs[waveIndex]));

                yield return new WaitForSeconds(timeBetweenWaves);
            }

            while (!isLooping && !isWinned)
            {
                yield return StartCoroutine(LoadWinCondition());
            } 
        }

        private IEnumerator LoadWinCondition()
        {
            if (levelManager.GetNumberOfEnemies() <= 0)
            {
                isWinned = true;
                levelManager.LoadWinMenu();
            }
            yield return new WaitForSeconds(1);
        }

        private IEnumerator SpawnEnemiesInWave(EnemyWaveConfig waveConfig)
        {
            for (int enemyIndex = 0; enemyIndex < waveConfig.GetNumberOfEnemies(); enemyIndex++)
            {
                GameObject enemyInstance = Instantiate(waveConfig.GetEnemyPrefab(),
                                                       waveConfig.GetWaypoints()[0].transform.position,
                                                       Quaternion.identity) as GameObject;

                levelManager.EnemySpawned();

                // Set the current wave config on enemy instance
                enemyInstance.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);

                yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
            }
        }
    }
}
