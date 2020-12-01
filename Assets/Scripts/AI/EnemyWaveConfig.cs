using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moon.AI
{
    [CreateAssetMenu(menuName = "Enemy Wave Config")]
    public class EnemyWaveConfig : ScriptableObject
    {
        [SerializeField] GameObject enemyPrefab;
        [SerializeField] GameObject pathPrefab;
        [SerializeField] float timeBetweenSpawns = 1f;
        [SerializeField] float spawnRandomFactor = 0.3f;
        [SerializeField] int numberOfEnemies = 5;
        [SerializeField] float moveSpeed = 3f;

        public GameObject GetEnemyPrefab() { return enemyPrefab; }

        public List<Transform> GetWaypoints()
        {
            List<Transform> waveWaypoints = new List<Transform>();

            foreach (Transform childTransform in pathPrefab.transform)
            {
                waveWaypoints.Add(childTransform);
            }

            return waveWaypoints;
        }

        public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
        public float GetSpawnRandomFactor() { return spawnRandomFactor; }
        public int GetNumberOfEnemies() { return numberOfEnemies; }
        public float GetMoveSpeed() { return moveSpeed; }
    }
}
