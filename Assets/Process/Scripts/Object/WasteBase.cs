using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class WasteBase : MonoBehaviour
    {
        [SerializeField] WasteType _wasteTypeToDoProcess;

        ObjectPolling _objectPolling;

        public WasteType CurrentWasteType => _wasteTypeToDoProcess;

        public void SetActualObjectPolling(ObjectPolling objectPolling)
        {
            _objectPolling = objectPolling;
        }

        public void ReturnThisObjectToThePool()
        {
            _objectPolling.SetNewObjectToDesactivated(this);
        }
    }
}
