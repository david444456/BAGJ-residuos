using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class SpawnerWaste : MonoBehaviour
    {
        [SerializeField] float timeSpawn = 6;
        [SerializeField] private int maxCountSpawn = 20;

        [Header("TF")]
        [SerializeField] Transform[] transformSpawn;
        [SerializeField] WasteType[] typeSpawn;
        [SerializeField] FactoryWaste factoryWaste;

        void Start()
        {
            StartCoroutine(StartSpawnObjects());
        }

        IEnumerator StartSpawnObjects()
        {
            yield return new WaitForSeconds(Random.Range(0, timeSpawn));

            Transform trans = GetNewTransform();

            if (trans != null)
            {
                WasteBase wasteBase = factoryWaste.GetNewObjectWaste(typeSpawn[Random.Range(0, typeSpawn.Length)], false);
                wasteBase.gameObject.SetActive(true);
                wasteBase.transform.position = trans.position;
                wasteBase.transform.parent = trans;
            }
            
            StartCoroutine(StartSpawnObjects());
        }

        private Transform GetNewTransform()
        {
            foreach (Transform trans in transformSpawn)
            {
                Transform[] go = trans.GetComponentsInChildren<Transform>();
                if (go.Length <= 1)
                    return trans;
            }
            return null;
        } 
    }
}
