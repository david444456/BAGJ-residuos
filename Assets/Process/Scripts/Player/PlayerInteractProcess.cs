using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class PlayerInteractProcess : MonoBehaviour
    {
        [SerializeField] WasteBase[] _objects;
        [SerializeField] private string _tagToCompare;

        IProcessMachine _processMachine;
        WasteInteract _currentWasteInteract;

        PlayerInventory _playerInventory;

        

        private void Start()
        {
            _playerInventory = GetComponent<PlayerInventory>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsTheSameTag(other))
               _processMachine = other.gameObject.GetComponent<IProcessMachine>();
            
        }

        private bool IsTheSameTag(Collider other) => other.tag == _tagToCompare;

        private void OnTriggerExit(Collider other)
        {
            if (IsTheSameTag(other))
                _processMachine = null;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.E))
                return;

            if (_currentWasteInteract != null)
            {
                SetCurrentWasteInInventory(_currentWasteInteract.CurrentWaste);
                _currentWasteInteract.GrabObject();
            }

            if (_processMachine == null)
                return;

            if (_playerInventory.CurrentObjectInventory != null && CallCompareObject())
                SetCurrentWasteInInventory(null);
            else if (_processMachine.IsFinishWorking())
                SetCurrentWasteInInventory(_processMachine.GetActualWasteFinishWork());
        }

        private void SetCurrentWasteInInventory(WasteBase newWasteBase)
        {
            _playerInventory.CurrentObjectInventory = newWasteBase;
        }

        private bool CallCompareObject() => 
            _processMachine.CompareNewObjectAndSetIfTheSame(new WasteBase[] { _playerInventory.CurrentObjectInventory });
    }
}
