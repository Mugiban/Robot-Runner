using System;
using ID.UserInterface;
using ID.Utilities;

namespace ID.Managers
{
    public class UserInterfaceManager : Singleton<UserInterfaceManager>
    {

        public MenuPanel menuPanel;

        public MenuPanel inGamePanel;

        public MenuPanel wonPanel;
        
        public MenuPanel gameOverPanel;

        protected override void Awake()
        {
            base.Awake();
            ShowMenuPanel();
        }

        private void OnEnable()
        {
            GameManager.OnSwitchState += SwitchPanels;
        }

        private void OnDisable()
        {
            GameManager.OnSwitchState -= SwitchPanels;
        }

        private void SwitchPanels(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.MainMenu:
                    ShowMenuPanel();
                    break;
                case GameState.Playing:
                    ShowInGamePanel();
                    break; 
                case GameState.Won:
                    ShowWonPanel();
                    break;
                case GameState.GameOver:
                    ShowGameOverPanel();
                    break;
            }
        }

        private void ShowMenuPanel()
        {
            inGamePanel.Hide();
            gameOverPanel.Hide();
            wonPanel.Hide();
            menuPanel.Show();
        }
        
        private void ShowInGamePanel()
        {
            menuPanel.Hide();
            gameOverPanel.Hide();
            wonPanel.Hide();
            inGamePanel.Show();
        }

        private void ShowGameOverPanel()
        {
            menuPanel.Hide();
            inGamePanel.Hide();
            wonPanel.Hide();
            gameOverPanel.Show();
        }

        private void ShowWonPanel()
        {
            menuPanel.Hide();
            inGamePanel.Hide();
            gameOverPanel.Hide();
            wonPanel.Show();
        }
    } 
}

