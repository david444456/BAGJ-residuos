using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProcessMachine
{
    public class ProcessCount : ProcessMachineBase<WastePoints>
    {
        [Header("Process count")]
        [SerializeField] private int _maxCountForDoingWork = 5;
        [SerializeField] private Slider _sliderCount;

        private int _currentWorkCount;

        protected override void Start()
        {
            base.Start();
            _sliderCount.maxValue = _maxCountForDoingWork;
        }

        public override bool CompareNewObjectAndSetIfTheSame(WasteBase[] wasteObjectsBase)
        {
            if (CanStartWorkingProcess(wasteObjectsBase))
            {
                _currentWorkCount++;

                if (_currentWorkCount >= _maxCountForDoingWork)
                {
                    _currentWorkCount = 0;
                    UpdateSliderWithCount();
                    return base.CompareNewObjectAndSetIfTheSame(wasteObjectsBase);
                }
                UpdateSliderWithCount();
                return true;
            }

            return false;
        }

        private void UpdateSliderWithCount() => _sliderCount.value = _currentWorkCount;
    }
}