using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public abstract class ProcessMachineBase<CurrentWaste> : MonoBehaviour, ICompareAndSetProcessMachine where CurrentWaste : WasteBase
    {
        [Header("Parameters")]
        [SerializeField] protected float _timeToWork = 2f;

        [Header("Process")]
        [SerializeField] protected WasteType[] _wasteTypesToDoProcess;
        [SerializeField] protected WasteType _resultWasteType;
        [SerializeField] protected FactoryWaste _factoryWaste;

        protected CurrentWaste _currentWaste;

        private float _timeWorking = Mathf.Infinity;
        private bool _isWaitingByExitProduct = false;

        protected virtual void Update()
        {
            if (WaitingAndTimeWorkingBiggerThanTimeToWork())
                StartWorkProcess();

            _timeWorking += Time.deltaTime;
        }

        private bool WaitingAndTimeWorkingBiggerThanTimeToWork() => _timeWorking > _timeToWork && _isWaitingByExitProduct;

        public bool IsFinishWorking()
        {
            return WaitingAndTimeWorkingBiggerThanTimeToWork() && _currentWaste != null;
        }

        public CurrentWaste GetActualWasteFinishWork() => _currentWaste;

        public virtual void CompareNewObjectAndSetIfTheSame(WasteBase[] wasteObjectsBase)
        {
            if (!_isWaitingByExitProduct && IsTheSameWasteType(wasteObjectsBase))
                SetTimeToZero();
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

            //active ui
        }

        private void StartWorkProcess()
        {
            _isWaitingByExitProduct = false;
            _currentWaste = _factoryWaste.GetNewObjectWaste(_resultWasteType, true) as CurrentWaste;

            //active object to show finish object
            //desactive ui
        }


    }

    public interface ICompareAndSetProcessMachine
    {
        public void CompareNewObjectAndSetIfTheSame(WasteBase[] wasteObjectsBase);
    }
}