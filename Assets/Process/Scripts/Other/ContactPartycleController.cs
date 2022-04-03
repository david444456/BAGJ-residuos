using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class ContactPartycleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _partycleExplosion;

        void Start()
        {

        }

        public void StartPartycleSystem(Vector3 position)
        {
            _partycleExplosion.transform.position = position;
            _partycleExplosion.Play();
        }
    }
}
