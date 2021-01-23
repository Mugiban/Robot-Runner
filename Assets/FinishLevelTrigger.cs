using System;
using ID.Managers;
using UnityEngine;

namespace ID
{
    public class FinishLevelTrigger : MonoBehaviour
    {
        public int level = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                FinishLevel();
            }
        }

        private void FinishLevel()
        {
            GameManager.Instance.CompleteLevel(level);
        }
    }
}
