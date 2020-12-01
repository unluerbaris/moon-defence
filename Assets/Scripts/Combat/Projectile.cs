using UnityEngine;

namespace Moon.Combat
{
    public class Projectile : MonoBehaviour
    {
        float positionX;
        float lifeTime = 0f;

        [SerializeField] float projectileSpeed = 20f;
        [SerializeField] float projectileLife = 5f;

        void Start()
        {
            positionX = transform.position.x;
        }

        private void Update()
        {
            MoveProjectile();
            UpdateLifeTimer();

            if (lifeTime > projectileLife)
            {
                DestoyProjectile();
            }
        }

        private void MoveProjectile()
        {
            positionX = positionX + Time.deltaTime * projectileSpeed;

            transform.position = new Vector2(positionX, transform.position.y);
        }

        private void UpdateLifeTimer()
        {
            lifeTime += Time.deltaTime;
        }

        private void DestoyProjectile()
        {
            Destroy(gameObject);
        }
    }
}
