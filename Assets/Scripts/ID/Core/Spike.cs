using ID.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ID.Core
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Spike : MonoBehaviour
    {
        private BoxCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.ChangeState(GameState.GameOver);
            }
        }
    }
}

