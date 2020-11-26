using ID.Managers;
using UnityEngine;

namespace ID.UserInterface
{
    public class GameOver : MenuPanel
    {
        [SerializeField]  private MenuButton playAgainButton = null;
        [SerializeField]  private MenuButton backButton = null;

        private void OnEnable()
        {
            playAgainButton.AddListener(PlayAgain);
            backButton.AddListener(BackToMainMenu);
        }

        private void OnDisable()
        {
            playAgainButton.RemoveListener(PlayAgain);
            backButton.RemoveListener(BackToMainMenu);
        }

        private static void PlayAgain()
        {
            GameManager.Instance.ChangeState(GameState.Playing);
        }

        private static void BackToMainMenu()
        {
            GameManager.Instance.ChangeState(GameState.MainMenu);
        }
    }
}