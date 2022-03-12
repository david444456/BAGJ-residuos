using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class FactoryWaste : MonoBehaviour
    {
        [SerializeField] private ObjectPolling[] _objectPollings;

        Dictionary<WasteType, ObjectPolling> _listObjectPolling = new Dictionary<WasteType, ObjectPolling>();

        private void Awake()
        {
            foreach (ObjectPolling objectPolling in _objectPollings)
            {
                _listObjectPolling.Add(objectPolling.GetWasteType, objectPolling);
            }
        }

        public WasteBase GetNewObjectWaste(WasteType wasteType, bool ignoreMaxCount)
        {
            return _listObjectPolling[wasteType].GetNewObjectWaste(ignoreMaxCount);
        }
    }
}
