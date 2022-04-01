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
            /*if (ColliderIsProcess(other))
            {
                if (other.
                    GetComponentInParent<IProcessMachine>().
                    CompareNewObjectAndSetIfTheSame(new WasteBase[] { CurrentWaste }))
                {
                    GrabObject();
                }
            }*/
        }

        private void OnTriggerExit(Collider other)
        {
            if (ColliderIsProcess(other))
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

        private bool ColliderIsProcess(Collider other) => other.tag == "ProcessObject";
        
    }
}
