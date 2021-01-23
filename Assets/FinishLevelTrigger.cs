using System;
using ID.Core;
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
                FinishLevel(other.GetComponent<Player>());
            }
        }

        private void FinishLevel(Player player)
        {
            GameManager.Instance.CompleteLevel(level);
        }
    }
}
