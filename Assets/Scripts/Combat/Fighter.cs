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

        private Health _target;


        private Mover _mover;
        private Animator _animator;

        void Start()
        {
            _mover = GetComponent<Mover>();
            _animator = GetComponent<Animator>();
        }

        public void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;

            if (_target != null && !_target.IsDead)
            {
                var distance = Vector3.Distance(transform.position, _target.transform.position);

                if (distance > _weaponRange)
                {
                    _mover.MoveTo(_target.transform.position);
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
                _animator.SetTrigger("attack");
                _timeSinceLastAttack = 0f;
            }
        }

        public void Atack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            _target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            _target = null;
            _animator.SetTrigger("stopAttack");
        }

        //Animation Event
        private void Hit()
        {
            _target?.TakeDamage(_weaponDamage);
        }
    }
}
