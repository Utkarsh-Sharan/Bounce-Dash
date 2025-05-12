using System.Collections;
using UnityEngine;
using Singleton;
using Event;
using Player;
using Input;
using Obstacle;
using Coin;

namespace Main
{
    //Service Locator script.
    //Handles main game logic and creates services.
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("Services")]
        [SerializeField] private InputService _inputService;
        private PlayerService _playerService;
        private ObstacleService _obstacleService;
        private CoinService _coinService;

        [Header("Scriptable Objects")]
        [SerializeField] private PlayerScriptableObject _playerSO;
        [SerializeField] private ObstacleScriptableObject _obstacleSO;
        [SerializeField] private CoinScriptableObject _coinSO;

        private bool _isGameOver = false;

        protected override void Awake()
        {
            base.Awake();

            CreateServicesAndStartGame();
        }

        private void CreateServicesAndStartGame()
        {
            _playerService = new PlayerService(_playerSO);
            _obstacleService = new ObstacleService(_obstacleSO);
            _coinService = new CoinService(_coinSO);

            StartCoroutine(ObstacleSpawnRoutine());
            StartCoroutine(CoinSpawnRoutine());
        }

        private void OnEnable()
        {
            EventService.Instance.OnPlayerDeathEvent.AddListener(GameOver);
        }

        private IEnumerator ObstacleSpawnRoutine()
        {
            while (!_isGameOver)
            {
                _obstacleService.SpawnObstacles();
                yield return new WaitForSeconds(_obstacleSO.ObstacleSpawnRate);
            }
        }

        private IEnumerator CoinSpawnRoutine()
        {
            while (!_isGameOver)
            {
                _coinService.SpawnCoins();
                yield return new WaitForSeconds(_coinSO.CoinSpawnRate);
            }
        }

        private void GameOver() => _isGameOver = true;

        public InputService GetInputService() => _inputService;
        public ObstacleService GetObstacleService() => _obstacleService;
        public CoinService GetCoinService() => _coinService;

        private void OnDisable()
        {
            EventService.Instance.OnPlayerDeathEvent.RemoveListener(GameOver);
        }
    }
}