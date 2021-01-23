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
        private CoinManager _coinManager;


        [SerializeField] private AudioClip pickUpClip = null;
        [SerializeField] private int value = 1;
        public int Value => value;
        
        private Coin _coin;

        private void Start()
        {
            transform.localScale = Vector3.one;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            TryConvertToSuperCoin();
            _coin = new Coin(value);
        }

        private void TryConvertToSuperCoin()
        {
            var randomNumber = Random.Range(0f, 1f);
            if (randomNumber <= _coinManager.superCoinProbability)
            {
                ConvertToSuperCoin();
            }
        }

        private void ConvertToSuperCoin()
        {
            _spriteRenderer.color = _coinManager.superCoinColor;
            value = 5;
            transform.localScale *= 1.1f;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PickUp(other.GetComponent<Player>().pickUpSystem);
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

        public void Init(CoinManager coinManager)
        {
            _coinManager = coinManager;
        }
    }
}

