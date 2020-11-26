using System;
using UnityEngine;

namespace ID.Systems
{
    [Serializable]
    public class PlayerMovementSystem
    {
        public bool IsGrounded => _controller.isGrounded;
        public Vector2 Movement => _movement;
        
        private readonly float _gravity;
        private readonly float _maxJumpVelocity;
        private readonly float _minJumpVelocity;
        private float groundTimer;
        private float coyoteTimer;
        private Vector2 _movement;

        private readonly Rigidbody2D _rigidbody2D;
        private readonly CharacterController2D _controller;

        private PlayerData _playerData;


        public PlayerMovementSystem(CharacterController2D controller2D, Rigidbody2D rigidbody, PlayerData playerData)
        {
            _controller = controller2D;
            _rigidbody2D = rigidbody;
            if (playerData == null)
            {
                throw new NullReferenceException("There is no player data.");
            }
            _playerData = playerData;
            
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.gravityScale = 0;
            
            _gravity = -(2 * _playerData.maxJumpHeight) / (_playerData.timeToJumpApex * _playerData.timeToJumpApex);
            _maxJumpVelocity = Mathf.Abs(_gravity) * _playerData.timeToJumpApex;
            _minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(_gravity) * _playerData.minJumpHeight);
        }
        
        public void Update()
        {
            if (_controller.isGrounded || _controller.collisionState.above)
            {
                _movement.y = 0f;
            }
            

            if(_playerData.applyGravity)
                _movement.y += _gravity * Time.deltaTime;

            HandleJump();
            if (_movement.y < -_playerData.maxVelocityY)
            {
                _movement.y = -_playerData.maxVelocityY;
            }

            if (_playerData.applyMovement)
            {
                _movement.x = _playerData.movementSpeed;
            }
            else
            {
                _movement = new Vector2(0, _movement.y);
            }
            _controller.move(_movement * Time.deltaTime);
        }

        private void HandleJump()
        {
            groundTimer -= Time.deltaTime;
            coyoteTimer -= Time.deltaTime;

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W))
            {
                if (_movement.y > _minJumpVelocity)
                {
                    _movement.y = _minJumpVelocity;
                    groundTimer = 0;
                    coyoteTimer = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                groundTimer = _playerData.groundTime;
            }

            if (_controller.isGrounded)
            {
                coyoteTimer = _playerData.coyoteTime;
            }



            if (groundTimer > 0 && coyoteTimer > 0)
            {
                Jump(_maxJumpVelocity);
            }
        }

        public void Jump(float jumpForce)
        {
            _movement.y = jumpForce;
            groundTimer = 0;
            coyoteTimer = 0;
        }
    } 
}

