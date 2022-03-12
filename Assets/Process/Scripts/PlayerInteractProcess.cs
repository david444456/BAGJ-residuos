using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class PlayerInteractProcess : MonoBehaviour
    {
        [SerializeField] WasteBase[] _objects;
        [SerializeField] private string _tagToCompare;

        ICompareAndSetProcessMachine _processMachine;

        private void OnTriggerEnter(Collider other)
        {
            if (IsTheSameTag(other))
            {
                _processMachine = other.gameObject.GetComponent<ICompareAndSetProcessMachine>();
                print(_processMachine == null);

            }
        }

        private bool IsTheSameTag(Collider other) => other.tag == _tagToCompare;

        private void OnTriggerExit(Collider other)
        {
            if (IsTheSameTag(other))
                _processMachine = null;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.E) || _processMachine == null)
                return;

            _processMachine.CompareNewObjectAndSetIfTheSame(_objects);
        }
    }
}
