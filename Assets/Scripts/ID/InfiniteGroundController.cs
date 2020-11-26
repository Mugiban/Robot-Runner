using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ID
{

    public class InfiniteGroundController : MonoBehaviour
    {
        [SerializeField] private float updateTime = .5f;
        private float _updateTimer;
        
        [AssetList(Path = "/Prefabs/Environment", Tags = "InfiniteGround")]
        public List<InfiniteGround> infiniteGrounds;
        
        public InfiniteGround firstGround;
        private Vector3 _firstPosition;
        public InfiniteGround secondGround;
        private Vector3 _secondPosition;
        public InfiniteGround thirdGround;
        private Vector3 _thirdPosition;

        private List<InfiniteGround> _createdGrounds;

        private void OnEnable()
        {
            _firstPosition = firstGround.transform.position;
            _secondPosition = secondGround.transform.position;
            _thirdPosition = thirdGround.transform.position;
            firstGround.SetLifeTime(Mathf.Infinity);
            secondGround.SetLifeTime(Mathf.Infinity);
            thirdGround.SetLifeTime(Mathf.Infinity);
            _createdGrounds = new List<InfiniteGround>();
        }

        private bool _isActive;
        private InfiniteGround GetRandom()
        {
            var randomValue = Random.Range(0, infiniteGrounds.Count);
            return infiniteGrounds[randomValue];
        }

        private void Update()
        {
            if (_isActive == false) return;
            _updateTimer += Time.deltaTime;
            if (_updateTimer >= updateTime)
            {
                _updateTimer = 0;
                CreateGround();
            }
        }

        [Button]
        public void Activate()
        {
            firstGround.transform.position = _firstPosition;
            firstGround.speed = firstGround.DefaultSpeed;
            secondGround.transform.position = _secondPosition;
            secondGround.speed = firstGround.DefaultSpeed;
            thirdGround.transform.position = _thirdPosition;
            thirdGround.speed = firstGround.DefaultSpeed;
            _isActive = true;
            
        }

        [Button]
        public void Deactivate()
        {
            _isActive = false;
            foreach (var activeGround in _createdGrounds)
            {
                activeGround.speed = 0;
            }

            firstGround.speed = 0;
            secondGround.speed = 0;
            thirdGround.speed = 0;
        }
        private void CreateGround()
        {
            var pieceOfGround = GetRandom();
            var ground = Instantiate(pieceOfGround, transform.position, Quaternion.identity);
            ground.transform.parent = transform;
            _createdGrounds.Add(ground);
        }
        
        public void DestroyGround()
        {
            foreach (var activeGround in _createdGrounds)
            {
                Destroy(activeGround.gameObject);
            }
            _createdGrounds = new List<InfiniteGround>();
        }
    } 
}

