using System;
using ID.Core;
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
        private float _groundTimer;
        private float _coyoteTimer;
        private Vector2 _movement;

        private readonly Rigidbody2D _rigidbody2D;
        private readonly CharacterController2D _controller;
        private readonly AudioSource _audioSource;

        private PlayerData _playerData;
        private Player _player;
        

        private bool _lastGrounded;


        public PlayerMovementSystem(Player player)
        {
            _player = player;
            _controller = player.GetComponent<CharacterController2D>();
            _audioSource = player.GetComponent<AudioSource>();
            _rigidbody2D = player.GetComponent<Rigidbody2D>();
            _playerData = player.playerData;

            _rigidbody2D.isKinematic = true;
            _rigidbody2D.gravityScale = 0;
            
            _gravity = -(2 * _playerData.maxJumpHeight) / (_playerData.timeToJumpApex * _playerData.timeToJumpApex);
            _maxJumpVelocity = Mathf.Abs(_gravity) * _playerData.timeToJumpApex;
            _minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(_gravity) * _playerData.minJumpHeight);
        }
        
        public void Update()
        {
            if (_player.isDead) return;
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
            _lastGrounded = _controller.isGrounded;
        }

        private void HandleJump()
        {
            _groundTimer -= Time.deltaTime;
            _coyoteTimer -= Time.deltaTime;

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W))
            {
                if (_movement.y > _minJumpVelocity)
                {
                    _movement.y = _minJumpVelocity;
                    _groundTimer = 0;
                    _coyoteTimer = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                _groundTimer = _playerData.groundTime;
            }

            if (_controller.isGrounded)
            {
                _coyoteTimer = _playerData.coyoteTime;
            }



            if (_groundTimer > 0 && _coyoteTimer > 0)
            {
                Jump(_maxJumpVelocity);
            }
        }

        public void Jump(float jumpForce)
        {
            _movement.y = jumpForce;
            _groundTimer = 0;
            _coyoteTimer = 0;
            _audioSource.PlayOneShot(_playerData.jumpSound);
            _player.OnJump();
            
        }
    } 
}

