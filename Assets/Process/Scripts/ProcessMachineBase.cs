using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public abstract class ProcessMachineBase<CurrentWaste> : MonoBehaviour, IProcessMachine where CurrentWaste : WasteBase
    {
        [Header("Parameters")]
        [SerializeField] protected float _timeToWork = 2f;
        [SerializeField] private Transform _trasnformSpawnObject;

        [Header("Process")]
        [SerializeField] protected WasteType[] _wasteTypesToDoProcess;
        [SerializeField] protected WasteType _resultWasteType;
        [SerializeField] protected FactoryWaste _factoryWaste;

        protected CurrentWaste _currentWaste;
        protected ViewProcessMachine _viewProcessMachine;

        private float _timeWorking = Mathf.Infinity;
        private bool _isWaitingByExitProduct = false;
        private bool _isFinishWork = false;

        protected virtual void Start()
        {
            _viewProcessMachine = GetComponent<ViewProcessMachine>();

            if (_factoryWaste == null)
                _factoryWaste = FindObjectOfType<FactoryWaste>();
        }

        protected virtual void Update()
        {
            if (WaitingAndTimeWorkingBiggerThanTimeToWork() && !_isFinishWork)
                FinishWorkProcess();

            _timeWorking += Time.deltaTime;
        }

        private bool WaitingAndTimeWorkingBiggerThanTimeToWork() => _timeWorking > _timeToWork && _isWaitingByExitProduct;

        public bool IsFinishWorking()
        {
            return WaitingAndTimeWorkingBiggerThanTimeToWork() && _currentWaste != null;
        }

        public virtual WasteBase GetActualWasteFinishWorkAndFinishProcess()
        {
            if (_currentWaste == null)
                throw new Exception("This is not the correct way to call this method");

            SetBoolWaitingAndWorkingToFalse();

            _currentWaste.transform.position = _trasnformSpawnObject.position;

            CurrentWaste newWaste = _currentWaste;

            SetCurrentWasteToNull();
            _viewProcessMachine.SetNormalState();

            return newWaste;
        }

        protected void SetBoolWaitingAndWorkingToFalse()
        {
            _isWaitingByExitProduct = false;
            _isFinishWork = false;
        }

        protected void SetCurrentWasteToNull()
        {
            _currentWaste = null;
        }

        public virtual bool CompareNewObjectAndSetIfTheSame(WasteBase[] wasteObjectsBase)
        {
            if (!_isWaitingByExitProduct && IsTheSameWasteType(wasteObjectsBase))
            {
                SetTimeToZero();
                return true;
            }

            return false;
        }

        protected bool IsTheSameWasteType(WasteBase[] wasteObjectsBase)
        {
            int result = 0;
            foreach (WasteBase wasteBase in wasteObjectsBase)
            {
                foreach (WasteType type in _wasteTypesToDoProcess)
                {
                    if (type == wasteBase.CurrentWasteType)
                        result++;
                }
            }

            bool isTheSameCount = result == wasteObjectsBase.Length;
            return isTheSameCount;
        }

        private void SetTimeToZero()
        {
            _timeWorking = 0;
            _isWaitingByExitProduct = true;

            _viewProcessMachine.SetWorkingState();
            _viewProcessMachine.PlayWorkingSound();
        }

        private void FinishWorkProcess()
        {
            _currentWaste = _factoryWaste.GetNewObjectWaste(_resultWasteType, true) as CurrentWaste;
            _currentWaste.gameObject.SetActive(false);
            _isFinishWork = true;

            _viewProcessMachine.SetFinishState();
            _viewProcessMachine.PlayFinishSound();
        }
    }
}