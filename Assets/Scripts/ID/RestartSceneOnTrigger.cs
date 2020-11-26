using ID.Managers;
using UnityEngine;

namespace ID
{
    public class RestartSceneOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Restart();
            }
        }

        private void Restart()
        {
            GameManager.Instance.ChangeState(GameState.GameOver);
        }
    }
} 


