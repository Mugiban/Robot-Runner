using System;
using ID.Managers;
using ID.Systems;
using UnityEngine;

namespace ID.Core
{
    public class Mushroom : MonoBehaviour
    {
        private MushroomMovement _mushroomMovement;
        private CharacterController2D _characterController2D;
        private BoxCollider2D _boxCollider;
        private SpriteRenderer _spriteRenderer;

        private bool _isActive;

        public bool applyMovement = true;
        public float runSpeed = 2f;
        public float gravity = -25f;
        public bool IsDead { get; set; }

        private void Awake()
        {
            _characterController2D = GetComponent<CharacterController2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        public void Activate()
        {
            IsDead = false;
            _isActive = true;
            _spriteRenderer.enabled = true;
            _boxCollider.enabled = true;
            applyMovement = true;
        }

        public void Deactivate()
        {
            _isActive = false;
            _spriteRenderer.enabled = false;
            _boxCollider.enabled = false;
            applyMovement = false;
        }

        private void Start()
        {
            _mushroomMovement = new MushroomMovement(this, _characterController2D);
        }

        private void Update()
        {
            if (_isActive == false) return;
            _mushroomMovement.Update();
        }


        public void Die(Player player)
        {
            IsDead = true;
            player.Jump();
            MushroomManager.Instance.KillMushroom(this);
        }

    } 
}

