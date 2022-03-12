namespace ProcessMachine
{
    public interface IProcessMachine
    {
        public bool CompareNewObjectAndSetIfTheSame(WasteBase[] wasteObjectsBase);
        public WasteBase GetActualWasteFinishWork();

        public bool IsFinishWorking();
    }
}