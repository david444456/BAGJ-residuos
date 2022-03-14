using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class ProcessPunctuation : ProcessMachineBase<WastePoints>
    {
        [SerializeField] ParticleSystem _particleSystemFinishWork;
        [SerializeField] ControlGame _controlGame;

        public override WasteBase GetActualWasteFinishWork()
        {
            _particleSystemFinishWork.Play();

            SetBoolWaitingAndWorkingToFalse();

            _controlGame.AugmentPuntuation(_currentWaste._pointsToAdd);

            SetCurrentWasteToNull();

            _viewProcessMachine.SetNormalState();

            return null;
        }
    }
}
