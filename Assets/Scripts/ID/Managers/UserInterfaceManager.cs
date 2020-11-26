using ID.UserInterface;
using ID.Utilities;

namespace ID.Managers
{
    public class UserInterfaceManager : Singleton<UserInterfaceManager>
    {

        public MenuPanel menuPanel;

        public MenuPanel inGamePanel;     
        

        public MenuPanel gameOverPanel;

        protected override void Awake()
        {
            base.Awake();
            ShowMenuPanel();
        }

        private void Update()
        {
            switch (GameManager.CurrentGameState)
            {
                case GameState.MainMenu:
                    ShowMenuPanel();
                    break;
                case GameState.Playing:
                    ShowInGamePanel();
                    break;
                case GameState.GameOver:
                    ShowGameOverPanel();
                    break;
            }
        }

        private void ShowMenuPanel()
        {
            menuPanel.Show();
            inGamePanel.Hide();
            gameOverPanel.Hide();
        }
        
        private void ShowInGamePanel()
        {
            menuPanel.Hide();
            inGamePanel.Show();
            gameOverPanel.Hide();
        }

        private void ShowGameOverPanel()
        {
            menuPanel.Hide();
            inGamePanel.Hide();
            gameOverPanel.Show();
        }




    } 
}

