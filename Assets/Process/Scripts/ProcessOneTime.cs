using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class ProcessOneTime : ProcessPunctuation
    {
        [Header("Process one time")]
        [SerializeField] private GameObject _goChangeParent;

        [SerializeField] private bool _isAlreadyDoProcess = false;

        public override bool CompareNewObjectAndSetIfTheSame(WasteBase[] wasteObjectsBase)
        {
            if (!_isAlreadyDoProcess)
            {
                return base.CompareNewObjectAndSetIfTheSame(wasteObjectsBase);
            }

            return false;
        }

        public override WasteBase GetActualWasteFinishWorkAndFinishProcess()
        {
            _goChangeParent.transform.SetParent(transform);
            _isAlreadyDoProcess = true;
            return base.GetActualWasteFinishWorkAndFinishProcess();
        }
    }
}