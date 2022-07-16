using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float _health = 100f;

        public void TakeDamage(float damage)
        {
            _health -= damage;
            _health = _health < 0 ? 0 : _health;
            print(_health);
        }
    }
}
