using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class WasteInteract : MonoBehaviour
    {
        public WasteBase CurrentWaste;

        private void OnEnable()
        {
            CurrentWaste = GetComponent<WasteBase>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (ColliderIsPlayer(other))
            {
                print("Active UI");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (ColliderIsPlayer(other))
            {
                print("Desactive UI");
            }
        }

        public void GrabObject()
        {
            CurrentWaste.ReturnThisObjectToThePool();
        }

        private bool ColliderIsPlayer(Collider other) => other.tag == "Player";
        
    }
}
