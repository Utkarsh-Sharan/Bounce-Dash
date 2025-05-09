using UnityEngine;

namespace Player
{
    public class PlayerService
    {
        private PlayerController _playerController;

        public PlayerService(PlayerScriptableObject playerSO)
        {
            _playerController = new PlayerController(playerSO);
        }
    }
}