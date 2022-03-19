using UnityEngine;

namespace ProcessMachine
{
    public class ControlVelocityObject : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            

        }

        public void AddForce(Vector3 direction)
        {
            _rigidbody.AddForce(direction, ForceMode.Impulse);
        }
    }
}