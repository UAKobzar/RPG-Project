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
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;

        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                var target = hit.transform.gameObject.GetComponent<CombatTarget>();

                if (target != null)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        Fighter fighterComponent = GetComponent<Fighter>();
                        fighterComponent?.Atack(target);
                    }

                    return true;
                }
            }

            return false;
        }

        private bool InteractWithMovement()
        {
            bool isHit = Physics.Raycast(GetMouseRay(), out RaycastHit hitInfo);

            if (isHit)
            {
                if (Input.GetMouseButton(1))
                {
                    var component = GetComponent<Mover>();

                    component.MoveTo(hitInfo.point);
                }
                return true;
            }

            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
