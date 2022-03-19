using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Configure")]
        [SerializeField] private float _forceToPushObject = 2;

        [Header("References")]
        [SerializeField] private Transform _transformSpawnObject;
        [SerializeField] private Transform _transformSpawnPushObject;

        private CharacterInput _characterInput;
        private CharacterAnimation _characterAnimation;
        private FactoryWaste _factoryWaste;


        private WasteBase _currentObjectInventory;

        public WasteBase CurrentObjectInventory
        {
            get => _currentObjectInventory;
            set => SetCurrentObjectInventory(value);
        }

        private void Start()
        {
            _characterInput = GetComponent<CharacterInput>();
            _characterAnimation = GetComponentInChildren<CharacterAnimation>();

            _factoryWaste = FindObjectOfType<FactoryWaste>();
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
            print(_characterInput.PushItemPress);
            if (_characterInput.PushItemPress && _currentObjectInventory != null)
                CreateAndPushObject();
        }

        private void CreateAndPushObject()
        {
            DestroyAllObjectsInTransformSpawnPlayer();
            RequestObjectAndPush();
            LostCurrentObject();
        }

        private void RequestObjectAndPush()
        {
            WasteBase wasteBase = _factoryWaste.GetNewObjectWaste(_currentObjectInventory.CurrentWasteType, true);

            wasteBase.gameObject.SetActive(true);
            wasteBase.transform.position = _transformSpawnPushObject.position;

            wasteBase.GetComponent<ControlVelocityObject>().AddForce(transform.forward * _forceToPushObject);
        }

        private void LostCurrentObject()
        {
            _currentObjectInventory = null;
            _characterAnimation.SetCarryHasValue(_currentObjectInventory != null);
        }
    }
}
