using System;

namespace ProcessMachine
{
    public interface IProcessMachine
    {
        public bool CompareNewObjectAndSetIfTheSame(WasteBase[] wasteObjectsBase);

        public WasteBase GetActualWasteFinishWorkAndFinishProcess();

        public bool IsFinishWorking();
    }
}