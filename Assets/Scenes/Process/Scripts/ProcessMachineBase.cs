using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public abstract class ProcessMachineBase<CurrentWaste> : MonoBehaviour where CurrentWaste : WasteBase
    {
        [Header("Parameters")]
        [SerializeField] protected float _timeToWork = 2f;
        [SerializeField] protected WasteType[] _wasteTypesToDoProcess;

        public virtual void CompareNewObjectAndSetIfTheSame(WasteBase[] wasteObjectsBase)
        {
            if (IsTheSameWasteType(wasteObjectsBase))
                StartWorkProcess();
        }

        protected bool IsTheSameWasteType(WasteBase[] wasteObjectsBase)
        {
            int result = 0;
            foreach (WasteBase wasteBase in wasteObjectsBase)
            {
                foreach (WasteType type in _wasteTypesToDoProcess)
                {
                    if (type != wasteBase.CurrentWasteType)
                        result++;
                }
            }

            bool isTheSameCount = result == wasteObjectsBase.Length;
            return isTheSameCount;
        }

        private void StartWorkProcess()
        { 
            //found the factory and request a object
        }
    }
}