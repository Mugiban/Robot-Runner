using System;
using ID.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ID.UserInterface
{
    public class ToggleMenuButton : MenuButton
    {
        public bool isToggle;
        public AudioClip backClip;

        public CanvasGroup controlsPanel;

        private void Awake()
        {
            controlsPanel.alpha = 0;
        }

        public void Toggle()
        {
            isToggle = !isToggle;
            LeanTween.alphaCanvas(controlsPanel, isToggle ? 1 : 0, .25f);
            if (isToggle)
            {
                AudioManager.PlaySound(clickClip, .25f);
            }
            else
            {
                AudioManager.PlaySound(backClip, .25f);
            }
        }

    }
}