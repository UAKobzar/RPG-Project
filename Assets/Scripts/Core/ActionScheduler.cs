using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private IAction _curentAction;
        public void StartAction(IAction action)
        {
            if (action == _curentAction) return;
            if (_curentAction != null)
            {
                _curentAction.Cancel();
            }
            _curentAction = action;
        }
    }
}
