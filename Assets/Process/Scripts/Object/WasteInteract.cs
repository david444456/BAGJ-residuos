using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProcessMachine
{
    public class WasteInteract : MonoBehaviour
    {
        public bool _invokeEvent = false; 
        public Action DesactiveObject = delegate { };
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
            if(_invokeEvent) 
                DesactiveObject.Invoke();

            CurrentWaste.ReturnThisObjectToThePool();
        }

        private bool ColliderIsPlayer(Collider other) => other.tag == "Player";
        
    }
}
