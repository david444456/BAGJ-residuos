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
            _currentWorkCount++;

            if (CanStartWorkingProcess(wasteObjectsBase) && _currentWorkCount >= _maxCountForDoingWork)
            {
                _currentWorkCount = 0;
                UpdateSliderWithCount();
                return base.CompareNewObjectAndSetIfTheSame(wasteObjectsBase);
            }
            else
                UpdateSliderWithCount();  
            
            return true;
        }

        private void UpdateSliderWithCount() => _sliderCount.value = _currentWorkCount;
    }
}