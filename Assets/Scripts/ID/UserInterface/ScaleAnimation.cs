using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ID.UserInterface
{
    [RequireComponent(typeof(RectTransform))]
    public class ScaleAnimation : MonoBehaviour
    {
        private Vector3 _originalScale = Vector3.one;

        [SerializeField] private float scaleValue = 1.1f;
        [SerializeField] private float scaleTime = .5f;
        private RectTransform _rect;
        
        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
            _originalScale = transform.localScale;
        }

        private void Start()
        {
            LeanTween.scale(_rect, _originalScale * scaleValue, scaleTime).setLoopPingPong(Int32.MaxValue).setDelay(Random.Range(0,0.3f));
        }
    } 
}

