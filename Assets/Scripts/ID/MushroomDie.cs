using System;
using ID.Core;
using UnityEngine;

namespace ID
{
    public class MushroomDie : MonoBehaviour
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
                _mushroom.Die(other.GetComponent<Player>());
            }
        }
    } 
}

