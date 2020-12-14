using System;
using UnityEngine;

namespace ID
{
    [Serializable]
    public class InfiniteGround : MonoBehaviour
    {
        [Range(0,5f)] public float speed = .07f;
        
        private float _currentSpeed;

        private void Start()
        {
            ActivateMovement();
        }

        private void Update()
        {
            transform.position += Vector3.left * _currentSpeed;
        }

        public void StopMovement()
        {
            _currentSpeed = 0;
        }

        public void ActivateMovement()
        {
            _currentSpeed = speed;
        }
    } 
}

