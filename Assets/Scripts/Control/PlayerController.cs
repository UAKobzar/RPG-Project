using RPG.Combat;
using RPG.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        public void Update()
        {
            InteractWithMovement();
            InteractWithCombat();
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(1))
            {
                MoveToCursor();
            }
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                var target = hit.transform.gameObject.GetComponent<CombatTarget>();

                if (target != null)
                {
                    if (Input.GetMouseButton(1))
                    {
                        Fighter fighterComponent = GetComponent<Fighter>();
                        fighterComponent?.Atack(target);
                    }
                }
            }
        }

        private void MoveToCursor()
        {
            bool isHit = Physics.Raycast(GetMouseRay(), out RaycastHit hitInfo);

            if (isHit)
            {
                var component = GetComponent<Mover>();

                component.MoveTo(hitInfo.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
