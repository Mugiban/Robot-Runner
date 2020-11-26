using ID.Systems;
using UnityEngine;

namespace ID.Core
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CharacterController2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData = null;
        
        private Rigidbody2D _rigidbody2D;
        private CharacterController2D _controller;
        private Animator _animator;
        
        [HideInInspector] public PlayerMovementSystem playerMovementSystem;
        [HideInInspector] public PlayerAnimationSystem playerAnimationSystem;
         public PickUpSystem PickUpSystem;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _controller = GetComponent<CharacterController2D>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            playerMovementSystem = new PlayerMovementSystem(_controller, _rigidbody2D, playerData);
            playerAnimationSystem = new PlayerAnimationSystem(playerMovementSystem, _animator);
            PickUpSystem = new PickUpSystem();
        }

        private void Update()
        {
            playerMovementSystem.Update();
        }

        private void LateUpdate()
        {
            playerAnimationSystem.LateUpdate();
        }
        
        public void Deactivate()
        {
            playerData.applyMovement = false;
            Invoke(nameof(ApplyGravity), .5f);
            PickUpSystem.Reset();
            //Show game over
        }

        void ApplyGravity()
        {
            playerData.applyGravity = true;
        }

        public void Activate()
        {
            playerData.applyMovement = true;
            playerData.applyGravity = true;
        }

        public void SetPosition(Vector3 spawnPosition)
        {
            transform.position = spawnPosition;
        }

        public void Jump()
        {
            playerMovementSystem.Jump(22);
        }
    }
}