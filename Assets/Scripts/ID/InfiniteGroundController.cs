using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ID
{

    public class InfiniteGroundController : MonoBehaviour
    {
        private float _updateTimer;
        [SerializeField] private float leftXMaximumPosition = -42f;
        [SerializeField] private float spawnXPosition = 18.5f;
        public List<InfiniteGround> infiniteGrounds;
        


        private bool _isActive;
        private InfiniteGround GetRandom()
        {
            var randomValue = Random.Range(0, infiniteGrounds.Count);
            return infiniteGrounds[randomValue];
        }

        private void Update()
        {
            if (_isActive == false) return;
            foreach (InfiniteGround infiniteGround in infiniteGrounds)
            {
                if (infiniteGround.transform.position.x < leftXMaximumPosition)
                {
                    var newPosition = infiniteGround.transform.position;
                    newPosition.x = spawnXPosition;
                    infiniteGround.transform.position = newPosition;
                }
            }

        }

        public void Activate()
        {
            _isActive = true;
            foreach (InfiniteGround infiniteGround in infiniteGrounds)
            {
                infiniteGround.ActivateMovement();
            }
            
        }

        public void Deactivate()
        {
            _isActive = false;
            foreach (InfiniteGround infiniteGround in infiniteGrounds)
            {
                infiniteGround.StopMovement();
            }
        }
    } 
}

