using RPG.Core;
using RPG.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.Combat
{
    internal class Fighter : MonoBehaviour, IAction
    {
        [SerializeField]
        private float _weaponRange  = 2f;
        [SerializeField]
        private float _timeBetweenAttack = 1f;
        [SerializeField]
        private float _weaponDamage = 5f;

        private float _timeSinceLastAttack;

        private Transform _target;
        private Mover _mover;

        void Start()
        {
            _mover = GetComponent<Mover>();
        }

        public void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;

            if (_target != null)
            {
                var distance = Vector3.Distance(transform.position, _target.position);

                if (distance > _weaponRange)
                {
                    _mover.MoveTo(_target.position);
                }
                else
                {
                    _mover.Cancel(); 
                    AttackBeheaviour();
                }
            }
        }

        private void AttackBeheaviour()
        {
            if (_timeBetweenAttack <= _timeSinceLastAttack)
            {
                GetComponent<Animator>().SetTrigger("attack");
                _timeSinceLastAttack = 0f;
            }
        }

        public void Atack(CombatTarget CombatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = CombatTarget?.transform;
        }

        public void Cancel()
        {
            _target = null;
        }

        //Animation Event
        private void Hit()
        {
            _target?.gameObject.GetComponent<Health>()?.TakeDamage(_weaponDamage);
        }
    }
}
