using UnityEngine;
using Moon.Movement;

namespace Moon.Spawn
{
    public class EnemyWeaponSpawner : MonoBehaviour
    {
        [SerializeField] int numberOfWeapons = 0;
        [SerializeField] GameObject weaponPrefab;

        void Start()
        {
            PlaceWeapons();
        }

        public void PlaceWeapons()
        {
            if (numberOfWeapons <= 0)
            {
                return;
            }
            else
            {
                int counter = 360 / numberOfWeapons;

                for (int i = 0; i < 360; i += counter)
                {
                    GameObject weaponInstance = Instantiate(weaponPrefab,
                                                new Vector2(transform.position.x, transform.position.y),
                                                Quaternion.identity) as GameObject;

                    weaponInstance.GetComponent<CircularMover>().SetStartAngle(i);

                    weaponInstance.transform.parent = gameObject.transform;
                }
            }
        }
    }
}

