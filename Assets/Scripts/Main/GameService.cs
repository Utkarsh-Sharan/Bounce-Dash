using UnityEngine;
using Player;
using UnityEngine.InputSystem;

namespace Main
{
    //Service Locator script.
    //Handles main game logic and creates services.
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("Scriptable Objects")]
        [SerializeField] private PlayerScriptableObject _playerSO;
        
        //Services
        private PlayerService _playerService;

        protected override void Awake()
        {
            base.Awake();

            CreateServices();
        }

        private void CreateServices()
        {
            _playerService = new PlayerService(_playerSO);
        }
    }
}