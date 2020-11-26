using System;
using ID.Core;
using ID.UserInterface;
using ID.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        [ShowInInspector] public static GameState CurrentGameState;
        private InfiniteGroundController _infiniteGroundController;
        private MushroomManager _mushroomManager;
        private SpawnPosition _spawnPosition;
        private Player _player;
        [SerializeField] private Fade fade;

        public static event Action OnPlayerDeath;

        private void OnEnable()
        {
            if(_player == null) _player = FindObjectOfType<Player>();
            if (_spawnPosition == null) _spawnPosition = FindObjectOfType<SpawnPosition>();
            if (fade == null) fade = FindObjectOfType<Fade>();
            if (_mushroomManager == null) _mushroomManager = FindObjectOfType<MushroomManager>();
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
            _mushroomManager.DeActivateAllMushrooms();
            _player.Deactivate();
            _player.SetPosition(_spawnPosition.transform.position);
            Invoke(nameof(ShowMain), .4f);
        }

        void ShowMain()
        {
            fade.FadeOut();

        }
        private void ShowInGame()
        {
            fade.FadeOut();
            _mushroomManager.ActivateAllMushrooms();
            
            _infiniteGroundController.Activate();
            _infiniteGroundController.Deactivate();
            
            _player.SetPosition(_spawnPosition.transform.position);
            _player.Activate();
        }


        
        private void ShowGameOver()
        {
            fade.FadeIn();
            _mushroomManager.DeActivateAllMushrooms();
            _player.Deactivate();
            OnPlayerDeath?.Invoke();
        }
    } 
}

