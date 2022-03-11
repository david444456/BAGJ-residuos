using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class WasteBase : MonoBehaviour
    {
        [SerializeField] WasteType _wasteTypeToDoProcess;

        public WasteType CurrentWasteType => _wasteTypeToDoProcess;
    }
}
