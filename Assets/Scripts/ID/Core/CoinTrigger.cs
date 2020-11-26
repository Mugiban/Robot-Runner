using ID.Managers;
using UnityEngine;
using ID.Systems;

namespace ID.Core
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class CoinTrigger : MonoBehaviour, IAmPickUp
    {
        private SpriteRenderer _spriteRenderer;
        private CircleCollider2D _circleCollider2D;
        private Animator _animator;
        private AudioSource _audioSource;

        [SerializeField] private AudioClip pickUpClip = null;
        [SerializeField] private int value = 1;
        public int Value => value;
        
        private Coin _coin;
        
        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _coin = new Coin(value);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PickUp(other.GetComponent<Player>().PickUpSystem);
            }
        }
        public void PickUp(PickUpSystem pickUpSystem)
        {
            pickUpSystem.AddPoints(_coin.Value);
            AudioManager.PlaySound(pickUpClip);
            Disable();
        }

        public void Reset()
        {
            _spriteRenderer.enabled = true;
            _circleCollider2D.enabled = true;
            _animator.enabled = true;
        }

        private void Disable()
        {
            _spriteRenderer.enabled = false;
            _circleCollider2D.enabled = false;
            _animator.enabled = false;

        }
    }
    
    public class Coin
    {
        public int Value { get; }
        public Coin(int value)
        {
            Value = value;
        }
    }
}

