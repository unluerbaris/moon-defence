using System.Collections;
using System.Collections.Generic;
using Moon.AI;
using Moon.Control;
using Moon.Manager;
using Moon.UI;
using UnityEngine;

namespace Moon.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int health = 100;
        [SerializeField] int score = 50;

        float timeBetweenBlinks = 0.1f;
        bool isBlinking = false;
        int fullHealth;

        Animator animator;
        AudioManager audioManager;
        LevelManager levelManager;

        private void Start()
        {
            fullHealth = health; 
            animator = GetComponent<Animator>();
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
            levelManager = FindObjectOfType<LevelManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
            ProcessHit(collision.gameObject.GetComponent<DamageDealer>().GetDamage());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Die();
        }

        private void ProcessHit(int damage)
        {
            audioManager.PlaySound($"{gameObject.tag}Hurt");

            if (!isBlinking)
            {
                StartCoroutine("BlinkAnimation");
            }

            health -= damage;

            UpdateHealthBar(health, fullHealth);

            if (health <= 0)
            {
                Die();
            }
        }

        IEnumerator BlinkAnimation()
        {
            isBlinking = true;

            // Blink just once
            for (int blinkCount = 0; blinkCount < 1; blinkCount++)
            {
                GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0.4f);
                yield return new WaitForSeconds(timeBetweenBlinks);
                GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
                yield return new WaitForSeconds(timeBetweenBlinks);
            }

            StopCoroutine("BlinkAnimation");
            isBlinking = false;
        }

        private void UpdateHealthBar(int health, int fullHealth)
        {
            if (gameObject.tag == "Player")
            {
                FindObjectOfType<HealthBar>().UpdateHealthBar(health, fullHealth);
            }
        }

        private void Die()
        {
            if (gameObject.tag == "Player")
            {
                UpdateHealthBar(0, fullHealth);
                GetComponent<PlayerController>().enabled = false;
                FindObjectOfType<LevelManager>().LoadGameOver();
            }
            if (gameObject.tag == "Enemy")
            {
                FindObjectOfType<ScoreManager>().AddScore(score);
                GetComponent<EnemyAttack>().enabled = false;
                GetComponent<EnemyPath>().enabled = false;
                levelManager.EnemyDestroyed();
            }
            if (GetComponent<BoxCollider2D>() != null)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }

            audioManager.PlaySound("Explosion");
            animator.SetTrigger("destroyed");
        }

        // Animation Event
        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
