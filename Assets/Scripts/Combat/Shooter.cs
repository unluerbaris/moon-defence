using System.Collections;
using UnityEngine;
using Moon.Manager;

namespace Moon.Combat
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] float timeBetweenShoots = 0.25f;
        [SerializeField] float projectileXOffset = 1f;
        [SerializeField] float projectileYOffset = -0.1f;

        AudioManager audioManager;

        private void Start()
        {
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }

        bool continueFiring = false;

        public IEnumerator Fire()
        {
            while (continueFiring)
            {
                audioManager.PlaySound("PlayerFire");

                GameObject projectileInstance = Instantiate(projectilePrefab,
                                                        new Vector2(transform.position.x + projectileXOffset, transform.position.y + projectileYOffset),
                                                        Quaternion.identity) as GameObject;
                yield return new WaitForSeconds(timeBetweenShoots);
            }
        }

        public void ContinueFiring(bool isFiring)
        {
            continueFiring = isFiring;
        }
    }
}
