using System;
using UnityEngine;

namespace ID.Systems
{
    [Serializable]
    public class PlayerAnimationSystem
    {
        private Animator _animator;
        private PlayerMovementSystem _playerMovementSystem;
        private static readonly int VelocityY = Animator.StringToHash("VelocityY");
        private static readonly int IsGrounded = Animator.StringToHash("isGrounded");


        public PlayerAnimationSystem(PlayerMovementSystem playerMovementSystem, Animator animator)
        {
            _playerMovementSystem = playerMovementSystem;
            _animator = animator;
        }

        public void LateUpdate()
        {
            var velocityY = _playerMovementSystem.Movement.y;
            _animator.SetFloat(VelocityY, velocityY);

            var isGrounded = _playerMovementSystem.IsGrounded;
            _animator.SetBool(IsGrounded, isGrounded);
        }

    }
}