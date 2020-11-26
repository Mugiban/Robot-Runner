using System;
using ID.Systems;
using UnityEngine;

namespace ID.Core
{
    [Serializable]
    public class MushroomMovement
    {
        private readonly CharacterController2D _controller;

        private readonly Mushroom _mushroom;
        private Vector3 _velocity;

        public MushroomMovement(Mushroom mushroom, CharacterController2D characterController2D)
        {
            _mushroom = mushroom;
            _controller = characterController2D;
        }
        
        public void Update()
        {
            if (_mushroom.applyMovement)
            {
                _velocity.x = -_mushroom.runSpeed;
            }

            _velocity.y += _mushroom.gravity * Time.deltaTime;
            if (_controller.isGrounded)
            {
                _velocity.y = 0;
            }

            _controller.move(_velocity * Time.deltaTime);
            
        }
    } 
}

