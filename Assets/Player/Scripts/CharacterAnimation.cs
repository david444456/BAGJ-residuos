using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        private Animator _animator;

        private readonly int _forwardSpeedParamId = Animator.StringToHash("forwardSpeed");

        int isCarryingHash;

        private void Start()
        {
            _animator = GetComponent<Animator>();

            isCarryingHash = Animator.StringToHash("isCarrying");
        }

        public void UpdateAnimation(bool _walk, bool sprint)
        {
            if (_walk && sprint)
            {
                _animator.SetFloat(_forwardSpeedParamId, 6f, 0.1f, Time.deltaTime);
                return;
            }

            if (_walk) _animator.SetFloat(_forwardSpeedParamId, 1f, 0.1f, Time.deltaTime);
            else _animator.SetFloat(_forwardSpeedParamId, 0, 0.1f, Time.deltaTime);
        }

        public void SetCarryHasValue(bool newValue)
        {
            _animator.SetBool(isCarryingHash, newValue);
        }

        public void SetPlayJumpBackFlip()
        {
            _animator.Play("Backflip");
        }

        public void UpdateAnimationWithSpeed(float speed)
        {
            float speedAnim = (float) Math.Round(speed);
            _animator.SetFloat(_forwardSpeedParamId, speedAnim, 0.1f, Time.deltaTime);
        }

        public void SetBoolAnimator(int id, bool value)
        {
            _animator.SetBool(id, value);
        }
    }
}