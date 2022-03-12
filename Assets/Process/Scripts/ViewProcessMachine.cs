using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class ViewProcessMachine : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _objectFirstState;
        [SerializeField] private GameObject _objectWorking;
        [SerializeField] private GameObject _objectFull;

        public void SetNormalState()
        {
            SetActiveObject(_objectFirstState, true);
            SetActiveObject(_objectWorking, false);
            SetActiveObject(_objectFull, false);
        }

        public void SetWorkingState()
        {
            SetActiveObject(_objectFirstState, false);
            SetActiveObject(_objectWorking, true);
            SetActiveObject(_objectFull, false);
        }

        public void SetFinishState()
        {
            SetActiveObject(_objectFirstState, false);
            SetActiveObject(_objectWorking, false);
            SetActiveObject(_objectFull, true);
        }

        private void SetActiveObject( GameObject GO, bool newValue)
        {
            GO.SetActive(newValue);
        }
    }
}

