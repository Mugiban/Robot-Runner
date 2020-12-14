using System;
using ID.Core;
using ID.UserInterface;
using ID.Utilities;
using UnityEditor.U2D;
using UnityEngine;

namespace ID.Managers
{      
    
    public enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }
    public class GameManager : Singleton<GameManager>
    {
        public static GameState CurrentGameState;
        private InfiniteGroundController _infiniteGroundController;
        private CoinManager _coinManager;
        private SpawnPosition _spawnPosition;
        private Player _player;
        [SerializeField] private Fade fade;

        public static event Action OnPlayerDeath;

        private void OnEnable()
        {
            if(_player == null) _player = FindObjectOfType<Player>();
            if (_spawnPosition == null) _spawnPosition = FindObjectOfType<SpawnPosition>();
            if (_coinManager == null) _coinManager = FindObjectOfType<CoinManager>();
            if (fade == null) fade = FindObjectOfType<Fade>();
            if (_infiniteGroundController == null)
                _infiniteGroundController = FindObjectOfType<InfiniteGroundController>();
            
            ChangeState(GameState.MainMenu);
            fade.FadeIn();
        }

        public void ChangeState(GameState newState)
        {
            CurrentGameState = newState;
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    ShowMainMenu();
                    break;
                case GameState.Playing:
                    ShowInGame();
                    break;
                case GameState.GameOver:
                    ShowGameOver();
                    break;
            }
        }
        
        private void ShowMainMenu()
        {
            _infiniteGroundController.Activate();
            _player.Deactivate(true);
            _player.SetPosition(_spawnPosition.transform.position);
            Invoke(nameof(ShowMain), .4f);
        }

        private void ShowMain()
        {
            fade.FadeOut();

        }
        private void ShowInGame()
        {
            fade.FadeOut();
            
            _infiniteGroundController.Deactivate();
            
            _player.Activate();
        }


        
        private void ShowGameOver()
        {
            fade.FadeIn();
            _player.Deactivate(false);
            OnPlayerDeath?.Invoke();
        }
        
        public void BackToMainMenu()
        { 
            ChangeState(GameState.MainMenu);
        }

        public void StartGame(bool resetPlayerPosition)
        {
            if (resetPlayerPosition)
            {
                _player.SetPosition(_spawnPosition.transform.position);
            }
            _coinManager.RestorePosition();
            ChangeState(GameState.Playing);
        }
    } 
}

