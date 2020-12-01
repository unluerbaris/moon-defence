using UnityEngine;

namespace Moon.Movement
{
    public class CircularMover : MonoBehaviour
    {
        [SerializeField] Transform rotationCenter;
        [SerializeField] float circularRotationSpeed = 1f;
        [SerializeField] float localRotationSpeed = 2f;
        [SerializeField] float rotationRadius = 8f;

        float angle;
        float startAngle;
        float positionX;
        float positionY;

        private void Start()
        {
            if (rotationCenter == null)
            {
                rotationCenter = transform.parent.transform;
            }
            positionX = transform.position.x;
            positionY = transform.position.y;
            angle = startAngle * Mathf.Deg2Rad;
        }

        private void Update()
        {
            CircularMovement();
        }

        private void CircularMovement()
        {
            positionX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            positionY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            transform.position = new Vector2(positionX, positionY);

            UpdateRotation((angle * Mathf.Rad2Deg) - 90);

            angle = angle + Time.deltaTime * circularRotationSpeed;

            if (angle >= 360f)
            {
                angle = 0f;
            }
        }

        private void UpdateRotation(float angle)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                     transform.localEulerAngles.y,
                                                     angle);
        }

        public void SetStartAngle(float angle)
        {
            startAngle = angle;
        }
    }
}
