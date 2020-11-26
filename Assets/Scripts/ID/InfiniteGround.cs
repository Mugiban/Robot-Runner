using System;
using UnityEngine;

namespace ID
{
    [Serializable]
    public class InfiniteGround : MonoBehaviour
    {
        [Range(0,5f)] public float speed = .07f;

        [SerializeField] private float lifeTime = 30f;
        private float _lifeTimer = 0;
        public float DefaultSpeed = .1f;

        private void Start()
        {
            _lifeTimer = 0;
        }

        private void Update()
        {
            transform.position += Vector3.left * speed;
            _lifeTimer += Time.deltaTime;
            if (_lifeTimer >= lifeTime)
            {
                DestroyImmediate(gameObject);
            }
        }

        public void SetLifeTime(float newLifeTime)
        {
            lifeTime = newLifeTime;
        }
    } 
}

