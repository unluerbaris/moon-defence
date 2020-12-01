using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moon.Combat
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] int damage = 50;

        public int GetDamage()
        {
            return damage;
        }
    }
}
