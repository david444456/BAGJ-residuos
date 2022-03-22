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

        public void AddForce(Vector3 direction)
        {
            _rigidbody.AddForce(direction, ForceMode.Impulse);
        }
    }
}