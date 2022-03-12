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
            set => _currentObjectInventory = value;
        }

        private void Update()
        {
            print(_currentObjectInventory != null);
        }

    }
}
