using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
	public class CharacterInput : MonoBehaviour
	{
        protected bool _sprintButtonPressed;
        protected bool _jumpButtonPressed;

        protected Vector2 _lookInput;
        private Vector2 _moveDirection;

        public bool SprintButtonPress => _sprintButtonPressed;

        public bool JumpButtonPress
        {
            get => _jumpButtonPressed;
            set => _jumpButtonPressed = value;
        }

        public Vector2 LookInput => _lookInput;

        internal Vector2 GetMovementInput() => _moveDirection;

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            _sprintButtonPressed = Input.GetKey("left shift");

            _moveDirection = new Vector2(horizontal, vertical);
        }
    }
}
