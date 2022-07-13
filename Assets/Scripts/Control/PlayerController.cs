using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Control
{
    public class PlayerController : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetMouseButton(1))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isHit = Physics.Raycast(ray, out RaycastHit hitInfo);

            if (isHit)
            {
                var component = GetComponent<Mover>();

                component.MoveTo(hitInfo.point);
            }
        }
    }
}
