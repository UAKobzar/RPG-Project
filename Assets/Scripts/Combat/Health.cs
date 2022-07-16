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

        public bool IsDead { get; private set; } = false;

        public void TakeDamage(float damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                _health = 0;
                Die();
            }
        }

        private void Die()
        {
            if (!IsDead)
            {
                GetComponent<Animator>().SetTrigger("die");
                IsDead = true;
            }
        }
    }
}
