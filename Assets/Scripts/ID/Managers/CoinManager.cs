﻿using System;
using System.Collections.Generic;
using ID.Core;
using ID.Utilities;
using UnityEngine;

namespace ID.Managers
{
    public class CoinManager : MonoBehaviour
    {
        private Dictionary<CoinTrigger, Vector3> _coinPositions;
        
        [Range(.01f, .5f)] public float superCoinProbability = .8f;
        public Color superCoinColor;
        public int coinCount;
        private void Awake()
        {
            _coinPositions = new Dictionary<CoinTrigger, Vector3>();
            var coins = FindObjectsOfType<CoinTrigger>();
            foreach (var coinTrigger in coins)
            {
                coinTrigger.Init(this);
                _coinPositions.Add(coinTrigger, coinTrigger.transform.position);
            }
        }

        private void Update()
        {
            coinCount = _coinPositions.Count;
        }

        public void RestorePosition()
        {
            foreach (var coinPosition in _coinPositions)
            {
                var coinTrigger = coinPosition.Key;
                var coinOriginalPosition = coinPosition.Value;
                coinTrigger.Reset();
                coinTrigger.transform.position = coinOriginalPosition;
            }
        }
    }
}
