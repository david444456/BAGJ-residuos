using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Character
{
	public class CharacterInput : MonoBehaviour
	{
        [Header("Mobile")]
        [SerializeField] private GameObject _mobileGO;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _buttonE;
        [SerializeField] private Button _buttonF;

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

        public Vector2 GetMovementInput() => _moveDirection;


        private bool _isMobileActive;

        private void Start()
        {
            _isMobileActive = _mobileGO.activeSelf;

            if (_isMobileActive)
            {
                Button[] buttons = _mobileGO.GetComponentsInChildren<Button>();
                if (_buttonE == null) _buttonE = buttons[0];
                if (_buttonF == null) _buttonF = buttons[1];

                _buttonE.onClick.AddListener(() => { _isHoldItemPress = true; });
                _buttonF.onClick.AddListener(() => { _isPushItemPress = true; });
            }
        }

        private void FixedUpdate()
        {
            MoveInput();
        }

        private void Update()
        {
            if (!_isMobileActive)
            {
                _isHoldItemPress = Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0);
                _isPushItemPress = Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1);
            }
        }

        private void LateUpdate()
        {
            if (_isMobileActive)
            {
                _isHoldItemPress = false;
                _isPushItemPress = false;
            }
        }

        private void MoveInput()
        {
            float horizontal, vertical = 0;
            if (_isMobileActive)
            {
                horizontal = _joystick.Horizontal;
                vertical = _joystick.Vertical;
                _sprintButtonPressed = Mathf.Abs( horizontal) > 0.5f || Mathf.Abs(vertical) > 0.5f;
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");

                _sprintButtonPressed = Input.GetKey("left shift");
            }

            _moveDirection = new Vector2(horizontal, vertical);
        }
    }
}
