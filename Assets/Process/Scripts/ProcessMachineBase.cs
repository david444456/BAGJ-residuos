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

        [Header("Process")]
        [SerializeField] protected WasteType[] _wasteTypesToDoProcess;
        [SerializeField] protected WasteType _resultWasteType;
        [SerializeField] protected FactoryWaste _factoryWaste;

        protected CurrentWaste _currentWaste;
        protected ViewProcessMachine _viewProcessMachine;

        private float _timeWorking = Mathf.Infinity;
        private bool _isWaitingByExitProduct = false;

        private void Start()
        {
            _viewProcessMachine = GetComponent<ViewProcessMachine>();
        }

        protected virtual void Update()
        {
            if (WaitingAndTimeWorkingBiggerThanTimeToWork())
                FinishWorkProcess();

            _timeWorking += Time.deltaTime;
        }

        private bool WaitingAndTimeWorkingBiggerThanTimeToWork() => _timeWorking > _timeToWork && _isWaitingByExitProduct;

        public bool IsFinishWorking()
        {
            return WaitingAndTimeWorkingBiggerThanTimeToWork() && _currentWaste != null;
        }

        public WasteBase GetActualWasteFinishWork()
        {
            if (_currentWaste == null)
                throw new Exception("This is not the correct way to call this method");

            CurrentWaste newWaste = _currentWaste;
            _currentWaste = null;

            _viewProcessMachine.SetNormalState();

            return _currentWaste;
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
            print(result);
            bool isTheSameCount = result == wasteObjectsBase.Length;
            return isTheSameCount;
        }

        private void SetTimeToZero()
        {
            print("Time to zero");
            _timeWorking = 0;
            _isWaitingByExitProduct = true;
            _viewProcessMachine.SetWorkingState();

            //active ui
        }

        private void FinishWorkProcess()
        {
            _isWaitingByExitProduct = false;
            _currentWaste = _factoryWaste.GetNewObjectWaste(_resultWasteType, true) as CurrentWaste;

            _viewProcessMachine.SetFinishState();
            //active object to show finish object
            //desactive ui
        }
    }
}