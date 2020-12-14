using System;
using UnityEngine;

namespace ID
{
    [Serializable]
    public class InfiniteGround : MonoBehaviour
    {
        [Range(1,20f)] public float speed = 5f;
        
        private float _currentSpeed;

        private void Start()
        {
            ActivateMovement();
        }

        private void Update()
        {
            transform.position += Vector3.left * (_currentSpeed * Time.deltaTime);
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

