using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class ObjectPolling : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private GameObject _gameObjectToSpawn;

        [Header("References")]
        [SerializeField] private WasteType _wasteTypePool;
        [SerializeField] private WasteBase[] initialObjects;
        [SerializeField] private int _maxCountObjectsInScene;

        private List<WasteBase> _objectsWorking = new List<WasteBase>();
        private List<WasteBase> _objectsDesactive = new List<WasteBase>();

        public WasteType GetWasteType => _wasteTypePool;

        public WasteBase GetNewObjectWaste(bool ignoreMaxCount)
        {
            WasteBase returnObject = null;

            if (_objectsDesactive.Count > 0)
            {
                returnObject = _objectsDesactive[0];
                _objectsDesactive.Remove(returnObject);
            }
            else            
                returnObject = InstantiateNewGameObject(ignoreMaxCount);

            return returnObject;
        }

        private WasteBase InstantiateNewGameObject(bool ignoreMaxCount)
        {
            WasteBase returnObject = null;

            if (_objectsWorking.Count < _maxCountObjectsInScene || ignoreMaxCount)
            {
                returnObject = Instantiate(_gameObjectToSpawn, this.transform).GetComponent<WasteBase>();

                _objectsWorking.Add(returnObject);
                
            }
            return returnObject;
        }

        public void SetNewObjectToDesactivated(WasteBase wasteBaseDesactive)
        {
            _objectsWorking.Remove(wasteBaseDesactive);
            _objectsDesactive.Add(wasteBaseDesactive);
            wasteBaseDesactive.gameObject.SetActive(false);
        }
    }
}
