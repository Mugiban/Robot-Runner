using ID.Managers;
using UnityEditor;
using UnityEngine;

namespace ID.UserInterface
{
    public class MainMenu : MenuPanel
    {

        public MenuButton playButton;

        public MenuButton optionsButton;

        public MenuButton controlsButton;

        public MenuButton exitButton;

        private void OnEnable()
        {
            playButton.AddListener(StartGame);
            optionsButton.AddListener(OpenOptionsPanel);
            controlsButton.AddListener(OpenControlsPanel);
            exitButton.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            playButton.RemoveListener(StartGame);
            optionsButton.RemoveListener(OpenOptionsPanel);
            controlsButton.RemoveListener(OpenControlsPanel);
            exitButton.RemoveListener(ExitGame);
        }

        void StartGame()
        {
            GameManager.Instance.ChangeState(GameState.Playing);
        }
        private void OpenOptionsPanel()
        {
            //TODO
        }
        private void OpenControlsPanel()
        {
           //TODO
        }
        
        void ExitGame()
        {
            Application.Quit(0);
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #endif
        }
    } 
}

