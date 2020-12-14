using System;
using ID.Core;
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
        private static readonly int Die = Animator.StringToHash("Die");


        public PlayerAnimationSystem(Player player, PlayerMovementSystem playerMovementSystem)
        {
            _playerMovementSystem = playerMovementSystem;
            _animator = player.GetComponent<Animator>();
        }

        public void LateUpdate()
        {
            var velocityY = _playerMovementSystem.Movement.y;
            _animator.SetFloat(VelocityY, velocityY);

            var isGrounded = _playerMovementSystem.IsGrounded;
            _animator.SetBool(IsGrounded, isGrounded);
        }

        public void AnimateDeath()
        {
            _animator.SetTrigger(Die);
        }

    }
}