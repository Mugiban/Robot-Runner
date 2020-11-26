using System;
using ID.Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ID.UserInterface
{
    public class GameOver : MenuPanel
    {
        [SerializeField] [ChildGameObjectsOnly] private MenuButton playAgainButton = null;
        [SerializeField] [ChildGameObjectsOnly] private MenuButton backButton = null;

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