using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class PlayerInventory : MonoBehaviour
    {
        private WasteBase _currentObjectInventory;

        public WasteBase CurrentObjectInventory
        {
            get => _currentObjectInventory;
            set => SetCurrentObjectInventory(value);
        }

        private void SetCurrentObjectInventory(WasteBase wasteBase)
        {
            _currentObjectInventory = wasteBase;

            GetComponentInChildren<animationStateController>().SetCarryHasValue(_currentObjectInventory!=null);
        }

        private void Update()
        {
            print(_currentObjectInventory != null);
        }

    }
}
