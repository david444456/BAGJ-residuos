using Character;
using UnityEngine;

namespace ProcessMachine
{
    public class PlayerInteractProcess : MonoBehaviour
    {
        [SerializeField] private string _tagProcessMachine;

        private IProcessMachine _processMachine;
        private WasteInteract _currentWasteInteract;

        private PlayerInventory _playerInventory;
        private CharacterInput _characterInput;

        private void Start()
        {
            _playerInventory = GetComponent<PlayerInventory>();
            _characterInput = GetComponent<CharacterInput>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsTheSameTag(other, _tagProcessMachine))
            {
                _processMachine = other.gameObject.GetComponent<IProcessMachine>();
            }

            if (IsTheSameTag(other, "Waste"))
            {
                _currentWasteInteract = other.gameObject.GetComponent<WasteInteract>();
                _currentWasteInteract.DesactiveObject += DesactiveObjectWasteInteract;
            }
        }

        private void DesactiveObjectWasteInteract()
        {
            _currentWasteInteract = null;
        }

        private bool IsTheSameTag(Collider other, string tagString) => other.tag == tagString;

        private void OnTriggerExit(Collider other)
        {
            if (IsTheSameTag(other, _tagProcessMachine))
                _processMachine = null;

            if (IsTheSameTag(other, "Waste"))
            {
                _currentWasteInteract.DesactiveObject -= DesactiveObjectWasteInteract;
                _currentWasteInteract = null;
            }
        }

        private void Update()
        {
            if (!_characterInput.HoldItemPress)
                return;

            if (IsInteractWasteAndSetWasteInventory())
                return;

            if (_processMachine == null)
                return;

            if (_playerInventory.CurrentObjectInventory != null && CallCompareObject())
                SetCurrentWasteInInventory(null);
            else if (_processMachine.IsFinishWorking() && _playerInventory.CurrentObjectInventory == null)
                SetCurrentWasteInInventory(_processMachine.GetActualWasteFinishWorkAndFinishProcess());
        }

        private bool IsInteractWasteAndSetWasteInventory()
        {
            if (_currentWasteInteract != null && _currentWasteInteract.gameObject.activeSelf)
            {
                if (_playerInventory.CurrentObjectInventory != null)
                    return false;

                SetCurrentWasteInInventory(_currentWasteInteract.CurrentWaste);
                _currentWasteInteract.GrabObject();
                return true;
            }
            return false;
        }

        private void SetCurrentWasteInInventory(WasteBase newWasteBase)
        {
            _playerInventory.CurrentObjectInventory = newWasteBase;
        }

        private bool CallCompareObject() => 
            _processMachine.CompareNewObjectAndSetIfTheSame(new WasteBase[] { _playerInventory.CurrentObjectInventory });
    }
}
