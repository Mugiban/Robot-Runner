using Sirenix.OdinInspector;
using UnityEngine;

namespace ID.UserInterface
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Fade : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        [SerializeField] private float fadeInTime = 1f;
        [SerializeField] private float fadeOutTime = 1f;
        private float _timer;
        private float _fadeValue = 1;

        private enum FadeState
        {
            Blocked,
            FadingToBlocked,
            Normal,
            FadingToNormal
        }

        private FadeState _fadeState = FadeState.Normal;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            switch (_fadeState)
            {
                case FadeState.Blocked:
                    break;
                case FadeState.FadingToBlocked:
                    FadeToBlocked();
                    break;
                case FadeState.Normal:
                    break;
                case FadeState.FadingToNormal:
                    FadeToNormal();
                    break;
            }
        }

        public void FadeIn()
        {
            _fadeState = FadeState.FadingToBlocked;
        }
        public void FadeOut()
        {
            _fadeState = FadeState.FadingToNormal;
        }

        
        private void FadeToBlocked()
        {
            _fadeValue += Time.deltaTime * (1f / fadeInTime);
            if (_fadeValue > 1)
            {
                _fadeState = FadeState.Blocked;
            }
            _canvasGroup.alpha = _fadeValue;
        }

        private void FadeToNormal()
        {
            _fadeValue -= Time.deltaTime * (1f / fadeOutTime);
            if (_fadeValue < 0)
            {
                _fadeState = FadeState.Normal;
            }
            _canvasGroup.alpha = _fadeValue;
        }
    } 
}

