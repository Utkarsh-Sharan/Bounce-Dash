using UnityEngine;
using Singleton;
using Player;
using Input;
using Obstacle;

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

        [Header("Scriptable Objects")]
        [SerializeField] private PlayerScriptableObject _playerSO;
        [SerializeField] private ObstacleScriptableObject _obstacleSO;

        protected override void Awake()
        {
            base.Awake();

            CreateServices();
        }

        private void CreateServices()
        {
            _playerService = new PlayerService(_playerSO);
            _obstacleService = new ObstacleService(_obstacleSO);
        }

        public InputService GetInputService() => _inputService;
        public ObstacleService GetObstacleService() => _obstacleService;
    }
}