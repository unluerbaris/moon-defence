using UnityEngine;

namespace Moon.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 16f;
        [SerializeField] float xBoundaryOffset = 0.05f;
        [SerializeField] float yBoundaryOffset = 0.05f;

        float positionX;
        float positionY;

        float xMin;
        float xMax;
        float yMin;
        float yMax;

        private void Awake()
        {
            positionX = transform.position.x;
            positionY = transform.position.y;
            SetUpMoveBoundaries();
        }

        public void Move(float controlThrowX, float controlThrowY)
        {
            positionX = Mathf.Clamp(positionX + Time.deltaTime * speed * controlThrowX, xMin + xBoundaryOffset, xMax - xBoundaryOffset);
            positionY = Mathf.Clamp(positionY + Time.deltaTime * speed * controlThrowY, yMin + yBoundaryOffset, yMax - yBoundaryOffset);

            transform.position = new Vector2(positionX, positionY);
        }

        private void SetUpMoveBoundaries()
        {
            Camera gameCamera = Camera.main;
            xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        }
    }
}
