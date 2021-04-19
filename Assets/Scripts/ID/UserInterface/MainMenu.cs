using ID.Managers;
using UnityEditor;
using UnityEngine;

namespace ID.UserInterface
{
    public class MainMenu : MenuPanel
    {

        public MenuButton playButton;

        public ToggleMenuButton controlsButton;

        public MenuButton exitButton;

        public AudioClip backClip;

        private void OnEnable()
        {
            playButton.AddListener(StartGame);
            controlsButton.AddListener(HandleControlsPanel);
            exitButton.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            playButton.RemoveListener(StartGame);
            controlsButton.RemoveListener(HandleControlsPanel);
            exitButton.RemoveListener(ExitGame);
        }

        void StartGame()
        {
            playButton.Click();
            GameManager.Instance.StartGame(false);
        }

        private void HandleControlsPanel()
        {
            controlsButton.Toggle();
        }
        
        void ExitGame()
        {
            AudioManager.PlayUI(backClip, .3f);
            Application.Quit(0);
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #endif
        }
    } 
}

