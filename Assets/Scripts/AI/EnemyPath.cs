using System.Collections;
using System.Collections.Generic;
using Moon.Manager;
using UnityEngine;

namespace Moon.AI
{
    public class EnemyPath : MonoBehaviour
    {
        EnemyWaveConfig waveConfig;

        int waypointIndex = 0;
        Vector2 targetPosition;
        List<Transform> waypoints;

        LevelManager levelManager;

        private void Start()
        {
            waypoints = waveConfig.GetWaypoints();
            transform.position = waypoints[waypointIndex].transform.position;
            levelManager = FindObjectOfType<LevelManager>();
        }

        private void Update()
        {
            MoveOnPath();
        }

        public void SetWaveConfig(EnemyWaveConfig newWaveConfig)
        {
            waveConfig = newWaveConfig;
        }

        private void MoveOnPath()
        {
            if (waypointIndex <= waypoints.Count - 1)
            {
                targetPosition = waypoints[waypointIndex].transform.position;

                transform.position = Vector2.MoveTowards(transform.position,
                                                         targetPosition,
                                                         waveConfig.GetMoveSpeed() * Time.deltaTime);

                if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
                {
                    waypointIndex++;
                }
            }
            else
            {
                levelManager.EnemyDestroyed();
                Destroy(gameObject);
            }
        }
    }
}
