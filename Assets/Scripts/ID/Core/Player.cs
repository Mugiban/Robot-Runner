using System.Collections;
using ID.Systems;
using UnityEngine;

namespace ID.Core
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CharacterController2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] public PlayerData playerData;
        
        private Rigidbody2D _rigidbody2D;
        private CharacterController2D _controller;
        private Animator _animator;
        private AudioSource _audioSource;
        
        [HideInInspector] public PlayerMovementSystem playerMovementSystem;
        [HideInInspector] public PlayerAnimationSystem playerAnimationSystem;
         public PickUpSystem pickUpSystem;

         public bool isDead;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _controller = GetComponent<CharacterController2D>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            playerMovementSystem = new PlayerMovementSystem(this);
            playerAnimationSystem = new PlayerAnimationSystem(this, playerMovementSystem);
            pickUpSystem = new PickUpSystem();
            _audioSource.volume = .1f;
            StartCoroutine(PlayFootStepCoroutine());
            //StartCoroutine(PlayFootStep());
        }

        private void Update()
        {
            playerMovementSystem.Update();
            
        }

        private void LateUpdate()
        {
            playerAnimationSystem.LateUpdate();
        }
        
        public void Deactivate(bool isStartGame)
        {
            isDead = !isStartGame;
            playerData.applyMovement = false;
            Invoke(nameof(ApplyGravity), .5f);
            pickUpSystem.Reset();
            _audioSource.volume = .1f;
        }
        
        private IEnumerator PlayFootStepCoroutine()
        {
            while (true)
            {
                if (_controller.isGrounded && isDead == false)
                {
                    _audioSource.PlayOneShot(playerData.leftFootStepSound);
                    yield return new WaitForSeconds(playerData.footStepsTimeStamp / 2f);
                    _audioSource.PlayOneShot(playerData.rightFootStepSound);
                    yield return new WaitForSeconds(playerData.footStepsTimeStamp / 2f);
                }

                yield return null;
            }
        }

        private void ApplyGravity()
        {
            playerData.applyGravity = true;
        }

        public void Activate()
        {
            playerData.applyMovement = true;
            playerData.applyGravity = true;
            _audioSource.volume = .2f;
        }

        public void SetPosition(Vector3 spawnPosition)
        {
            transform.position = spawnPosition;
        }

    }
}