using UnityEngine;

namespace ID.UserInterface
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Fade : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        [SerializeField] private float fadeInTime = 1f;
        [SerializeField] private float fadeOutTime = 1f;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 1f;
        }
        
        public void FadeIn()
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.LeanAlpha(1f, fadeInTime).setEase(LeanTweenType.easeInSine);
            }
        }
        public void FadeOut()
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.LeanAlpha(0f, fadeOutTime).setEase(LeanTweenType.easeInQuart);
            }
        }
    } 
}

