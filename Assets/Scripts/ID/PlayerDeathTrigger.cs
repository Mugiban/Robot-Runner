using System;
using ID.Core;
using ID.Managers;
using UnityEngine;

namespace ID
{
    public class PlayerDeathTrigger : MonoBehaviour
    {
        private Mushroom _mushroom;

        private void Awake()
        {
            _mushroom = GetComponentInParent<Mushroom>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (_mushroom.IsDead) return;
                GameManager.Instance.ChangeState(GameState.GameOver);
            }
        }
    } 
}

