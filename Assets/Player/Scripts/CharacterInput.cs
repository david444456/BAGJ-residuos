using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
	public class CharacterInput : MonoBehaviour
	{
        protected bool _sprintButtonPressed;
        protected bool _isHoldItemPress;
        protected bool _isPushItemPress;
        protected bool _jumpButtonPressed;

        protected Vector2 _lookInput;
        private Vector2 _moveDirection;
        public bool PushItemPress => _isPushItemPress;

        public bool HoldItemPress => _isHoldItemPress;

        public bool SprintButtonPress => _sprintButtonPressed;

        public bool JumpButtonPress
        {
            get => _jumpButtonPressed;
            set => _jumpButtonPressed = value;
        }

        public Vector2 LookInput => _lookInput;

        internal Vector2 GetMovementInput() => _moveDirection;

        private void FixedUpdate()
        {
            MoveInput();
        }

        private void Update()
        {
            _isHoldItemPress = Input.GetKeyDown(KeyCode.E);
            _isPushItemPress = Input.GetKeyDown(KeyCode.F);
        }

        private void MoveInput()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            _sprintButtonPressed = Input.GetKey("left shift");

            _moveDirection = new Vector2(horizontal, vertical);
        }
    }
}
