using System.Collections;
using UnityEngine;

namespace ProcessMachine
{
    public class SpawnerWaste : MonoBehaviour
    {
        [SerializeField] private float _timeSpawn = 6;
        [SerializeField] private int _maxCountSpawn = 20;

        [Header("TF")]
        [SerializeField] private Transform[] _transformSpawn;
        [SerializeField] private WasteType[] _typeSpawn;
        [SerializeField] private FactoryWaste _factoryWaste;

        [SerializeField] private AudioSource _audioHitObject;

        private void Start()
        {
            StartCoroutine(StartSpawnObjects());
        }

        private IEnumerator StartSpawnObjects()
        {
            yield return new WaitForSeconds(Random.Range(0, _timeSpawn));

            Transform trans = GetNewTransform();

            if (trans != null)
                GetAndSetNewObjectWaste(trans);
            
            StartCoroutine(StartSpawnObjects());
        }

        private Transform GetNewTransform()
        {
            foreach (Transform trans in _transformSpawn)
            {
                Transform[] go = trans.GetComponentsInChildren<Transform>();
                if (go.Length <= 1)
                    return trans;
            }
            return null;
        }

        public void StartSoundHitWaste()
        {
            _audioHitObject.Play();
        }

        private void GetAndSetNewObjectWaste(Transform trans)
        {
            WasteBase wasteBase = _factoryWaste.GetNewObjectWaste(_typeSpawn[Random.Range(0, _typeSpawn.Length)], false);
            wasteBase.gameObject.SetActive(true);
            wasteBase.transform.position = trans.position;
            wasteBase.transform.parent = trans;
        }
    }
}
