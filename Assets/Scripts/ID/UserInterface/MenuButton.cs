using System;
using ID.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ID.UserInterface
{
    [RequireComponent(typeof(Button), typeof(RectTransform))]
    public class MenuButton : MonoBehaviour, IPointerEnterHandler
    {
        protected RectTransform _rect;
        protected Button _button;
        public AudioClip hoverClip;
        public AudioClip clickClip;

        private void OnEnable()
        {
            _rect = GetComponent<RectTransform>();
            _button = GetComponent<Button>();
        }
        public void AddListener(UnityAction action)
        {
            if(_button == null) _button = GetComponent<Button>();
            _button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            if(_button == null) _button = GetComponent<Button>();
            _button.onClick.RemoveListener(action);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if(hoverClip != null)
                AudioManager.PlayUI(hoverClip, .1f);
        }

        public void Click()
        {
            if(clickClip != null)
                AudioManager.PlayUI(clickClip, .15f);
        }
    }
}

