using ID.Managers;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace ID.UserInterface
{
    public class MainMenu : MenuPanel
    {
        [ChildGameObjectsOnly]
        public MenuButton playButton;
        [ChildGameObjectsOnly]
        public MenuButton optionsButton;
        [ChildGameObjectsOnly]
        public MenuButton controlsButton;
        [ChildGameObjectsOnly]
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

