using UnityEngine;
using Moon.Combat;
using Moon.Movement;

namespace Moon.Control
{
    public class PlayerController : MonoBehaviour
    {
        float controlThrowX;
        float controlThrowY;

        Mover mover;
        Shooter shooter;
        Coroutine shootingCoroutine;

        private void Awake()
        {
            mover = GetComponent<Mover>();
            shooter = GetComponent<Shooter>();
        }

        private void Update()
        {
            MoveInput();
            Shoot();
        }

        private void MoveInput()
        {
            controlThrowX = Input.GetAxis("Horizontal"); //-1 to +1
            controlThrowY = Input.GetAxis("Vertical"); //-1 to +1
            mover.Move(controlThrowX, controlThrowY);
        }

        private void Shoot()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shooter.ContinueFiring(true);
                shootingCoroutine = StartCoroutine(shooter.Fire());
            }
            if (Input.GetButtonUp("Fire1"))
            {
                shooter.ContinueFiring(false);
                StopCoroutine(shootingCoroutine);
            }
        }
    }
}
