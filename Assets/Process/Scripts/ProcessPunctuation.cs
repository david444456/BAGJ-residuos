using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class ProcessPunctuation : ProcessMachineBase<WastePoints>
    {
        [SerializeField] ParticleSystem _particleSystemFinishWork;
        [SerializeField] ControlGame _controlGame;
        [SerializeField] animationStateController _animationStateController;

        protected override void Start()
        {
            base.Start();

            if (_animationStateController == null)
                _animationStateController = FindObjectOfType<animationStateController>();
        }

        public override WasteBase GetActualWasteFinishWork()
        {
            _particleSystemFinishWork.Play();

            SetBoolWaitingAndWorkingToFalse();

            _controlGame.AugmentPuntuation(_currentWaste._pointsToAdd);

            SetCurrentWasteToNull();

            _viewProcessMachine.SetNormalState();

            _animationStateController.SetPlayJumpBackFlip();

            return null;
        }
    }
}
