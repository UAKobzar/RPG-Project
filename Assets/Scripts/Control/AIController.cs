using RPG.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private float _chaseDistance = 5f;

        private GameObject _player;
        private Fighter _fighter;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _fighter = GetComponent<Fighter>();
        }


        private void Update()
        {
            InteractWithCombat();
        }

        private bool InteractWithCombat()
        {
            if (_player != null && _fighter.CanAttack(_player.gameObject))
            {
              
                if (InAttackRangeOfPlayer())
                {
                    _fighter.Atack(_player);

                    return true;
                }
                else
                {
                    _fighter.Cancel();
                    return false;
                }
            }


            return false;
        }

        private bool InAttackRangeOfPlayer()
        {
            var distance = Vector3.Distance(_player.transform.position, transform.position);
            return distance < _chaseDistance;
        }
    }
}
