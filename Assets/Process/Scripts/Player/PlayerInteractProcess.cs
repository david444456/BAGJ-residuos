using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class PlayerInteractProcess : MonoBehaviour
    {
        [SerializeField] private string _tagProcessMachine;

        IProcessMachine _processMachine;
        WasteInteract _currentWasteInteract;

        PlayerInventory _playerInventory;

        

        private void Start()
        {
            _playerInventory = GetComponent<PlayerInventory>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsTheSameTag(other, _tagProcessMachine))
               _processMachine = other.gameObject.GetComponent<IProcessMachine>();

            if (IsTheSameTag(other, "Waste"))
                _currentWasteInteract = other.gameObject.GetComponent<WasteInteract>();

        }

        private bool IsTheSameTag(Collider other, string tagString) => other.tag == tagString;

        private void OnTriggerExit(Collider other)
        {
            if (IsTheSameTag(other, _tagProcessMachine))
                _processMachine = null;

            if (IsTheSameTag(other, "Waste"))
                _currentWasteInteract = null;

            print("Exit");
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.E))
                return;

            if (_currentWasteInteract != null && _currentWasteInteract.gameObject.activeSelf)
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
