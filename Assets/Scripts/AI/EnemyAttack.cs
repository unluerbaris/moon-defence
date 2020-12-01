using System.Collections;
using System.Collections.Generic;
using Moon.Manager;
using UnityEngine;

namespace Moon.AI
{
    public class EnemyAttack : MonoBehaviour
    {
        float shotCounter;
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] float projectileXOffset = -1f;
        [SerializeField] float projectileYOffset = -0.1f;
        [SerializeField] float minTimeBetweenShots = 3f;
        [SerializeField] float maxTimeBetweenShots = 6f;

        AudioManager audioManager;

        private void Start()
        {
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
            SetRandomShotTime(minTimeBetweenShots, maxTimeBetweenShots);
        }

        private void Update()
        {
            ShootingTimer();
        }

        private void ShootingTimer()
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0f)
            {
                Fire();
                SetRandomShotTime(minTimeBetweenShots, maxTimeBetweenShots);
            }
        }

        private void Fire()
        {
            audioManager.PlaySound("EnemyFire");
            GameObject projectileInstance = Instantiate(projectilePrefab,
                                                        new Vector2(transform.position.x + projectileXOffset, transform.position.y + projectileYOffset),
                                                        Quaternion.identity) as GameObject;
        }

        private void SetRandomShotTime(float minTime, float maxTime)
        {
            shotCounter = Random.Range(minTime, maxTime);
        }
    }
}
