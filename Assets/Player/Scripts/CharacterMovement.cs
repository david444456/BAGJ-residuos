using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _velocityChangeValue = .015f;

        [Header("Walk")]
        [SerializeField] private float _sprintSpeed = 5;
        [SerializeField] private float _walkSpeed = 2;

        [Header("Rotation")]
        [SerializeField] private float _rotationFactorPerFrame = 1f;

        [Header("Gravity")]
        [SerializeField] private float _gravity = -9.8f;
        [SerializeField] private float _groundedGravity = -0.05f;

        [Header("Jump")]
        [SerializeField] private float _maxJumpHeight = 1;
        [SerializeField] private float _maxJumpTime = 0.5f;

        private bool _isJumpPressed = false;
        private float _initialJumpVelocity = 0;
        private bool _isJumping = false;

        private CharacterController _characterController;
        private CharacterInput _characterInput;
        private CharacterAnimation _characterAnimation;

        private Vector2 _inputMove;
        private Vector3 _currentMove;
        private bool _walkInput;

        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _characterInput = GetComponent<CharacterInput>();
            _characterAnimation = GetComponentInChildren<CharacterAnimation>();

            SetupJumpParameters();
        }

        private void SetupJumpParameters()
        {
            float timeToApex = _maxJumpTime / 2;
            _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
            _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
        }

        void Update()
        {
            UpdateVelocity();
            HandleRotation();
            Move();
            HandleGravity();
            HandleJump();
        }

        private void LateUpdate()
        {
            AnimationSetup();
        }

        private float _velocitySpeed;
        private float _targetSpeed;

        private void UpdateVelocity()
        {
            if (Mathf.Approximately(_velocitySpeed, _targetSpeed))
                return;

            if(_velocitySpeed < _targetSpeed)
                _velocitySpeed += _velocityChangeValue * Time.deltaTime * (_targetSpeed - _velocitySpeed);
            else if(_velocitySpeed > _targetSpeed)
                _velocitySpeed -= _velocityChangeValue * Time.deltaTime * 2;

        }

        private void HandleJump()
        {
            if (!_isJumping && _characterController.isGrounded && _characterInput.JumpButtonPress)
            {
                _isJumping = true;
                _currentMove.y = _initialJumpVelocity * 0.5f;
            }
            else if (_isJumping && !_characterInput.JumpButtonPress && _characterController.isGrounded) 
                _isJumping = false;
        }

        private void HandleGravity()
        {
            if (_characterController.isGrounded)
            {
                _currentMove.y = _groundedGravity;
            }
            else
            {
                float previousYVelocity = _currentMove.y;
                float newYVelocity = _currentMove.y + (_gravity * Time.deltaTime);
                float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;

                _currentMove.y = nextYVelocity;
            }
        }

        private void HandleRotation() 
        {
            if (!_walkInput)
                return;

            Vector3 positionToLookAt = Vector3.zero;
            positionToLookAt.x = _inputMove.x;
            positionToLookAt.z = _inputMove.y;

            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }

        private void Move()
        {
            _characterController.Move(GetMovementVector() * _velocitySpeed * Time.deltaTime);//GetSpeed() * Time.deltaTime );

            _walkInput = _inputMove.x != 0 || _inputMove.y != 0 && GetThereAreInput();
            if (_walkInput)
                _targetSpeed = _characterInput.SprintButtonPress ? _sprintSpeed : _walkSpeed;
            else
            {
                _targetSpeed = 0;
                _velocitySpeed = 0;
            }
        }

        private bool GetThereAreInput() => Mathf.Abs(_inputMove.y) + Mathf.Abs(_inputMove.x) >= 1;

        private float GetSpeed() {
            return _characterInput.SprintButtonPress ? _sprintSpeed : _walkSpeed;
        }

        private Vector3 GetMovementVector()
        {
            _inputMove = _characterInput.GetMovementInput();

            _currentMove.x = _inputMove.x;
            _currentMove.z = _inputMove.y;

            //_currentMove = new Vector3(_currentMove.x, GetGravityDown(), 0);
            _currentMove = _currentMove.normalized;
            return _currentMove;
        }

        private void AnimationSetup() 
        {
            //_characterAnimation.UpdateAnimation(_walkInput, _characterInput.SprintButtonPress);
            _characterAnimation.UpdateMove(_velocitySpeed);
        }
    }
}