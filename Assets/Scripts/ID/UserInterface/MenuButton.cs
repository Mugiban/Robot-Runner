using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ID.UserInterface
{
    [RequireComponent(typeof(Button))]
    public class MenuButton : MonoBehaviour
    {
        private Button _button;

        private void OnEnable()
        {
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
    } 
}

