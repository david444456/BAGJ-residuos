using UnityEngine;

namespace ProcessMachine
{
    public class ColliderCollisionWaste : MonoBehaviour
    {
        [SerializeField] private WasteInteract _wasteInteract;


        private void Start()
        {
            if (_wasteInteract == null)
                _wasteInteract = GetComponentInParent<WasteInteract>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (ColliderIsProcess(other))
            {
                if (other.
                    GetComponentInParent<IProcessMachine>().
                    CompareNewObjectAndSetIfTheSame(new WasteBase[] { _wasteInteract.CurrentWaste }))
                {
                    PlaySound();
                    other.GetComponentInParent<ContactPartycleController>().StartPartycleSystem(transform.position);
                    _wasteInteract.GrabObject();
                }
            }
        }

        private void PlaySound()
        {
            FindObjectOfType<SpawnerWaste>().StartSoundHitWaste();
        }

        private bool ColliderIsProcess(Collider other) => other.tag == "ProcessObject";

    }
}
