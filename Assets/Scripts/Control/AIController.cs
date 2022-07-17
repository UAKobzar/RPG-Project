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

        private void Update()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            var distance = Vector3.Distance(player.transform.position, transform.position);

            if(distance <= _chaseDistance)
            {
                print($"{transform.name} should chase");
            }
        }
    }
}
