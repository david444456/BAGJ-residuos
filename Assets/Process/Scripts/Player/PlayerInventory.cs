using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Transform _transformSpawnObject;

        private CharacterAnimation _characterAnimation;
        private WasteBase _currentObjectInventory;

        public WasteBase CurrentObjectInventory
        {
            get => _currentObjectInventory;
            set => SetCurrentObjectInventory(value);
        }

        private void Start()
        {
            _characterAnimation = GetComponentInChildren<CharacterAnimation>();
        }

        private void SetCurrentObjectInventory(WasteBase wasteBase)
        {
            _currentObjectInventory = wasteBase;

            if (_currentObjectInventory != null)
                InstanceAndDeleteObjectsInPlayer();
            else
                DestroyAllObjectsInTransformSpawnPlayer();

            _characterAnimation.SetCarryHasValue(_currentObjectInventory!=null);
        }

        private void InstanceAndDeleteObjectsInPlayer()
        {
            DestroyAllObjectsInTransformSpawnPlayer();

            Instantiate(_currentObjectInventory.GameObjectToSpawnCarry, _transformSpawnObject);
        }

        private void DestroyAllObjectsInTransformSpawnPlayer()
        {
            var list = _transformSpawnObject.GetComponentsInChildren<Transform>();

            foreach (Transform trans in list)
            {
                if (trans == _transformSpawnObject) continue;
                Destroy(trans.gameObject);
            }
        }

        private void Update()
        {
            //print(_currentObjectInventory != null);
        }
    }
}
