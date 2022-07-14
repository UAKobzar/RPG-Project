﻿using RPG.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.Combat
{
    internal class Fighter : MonoBehaviour
    {
        [field: SerializeField]
        public float weaponRange { get; set; } = 2f;

        private Transform _target;

        private Mover _mover;

        void Start()
        {
            _mover = GetComponent<Mover>();
        }

        public void Update()
        {
            if (_target != null)
            {
                var distance = Vector3.Distance(transform.position, _target.position);

                if (distance > weaponRange)
                {
                    _mover.MoveTo(_target.position);
                }
                else
                {
                    _mover.Stop();
                }
            }
        }

        public void Atack(CombatTarget CombatTarget)
        {
            _target = CombatTarget?.transform;
        }
    }
}
