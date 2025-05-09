using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        private PlayerView _playerView;

        public PlayerController(PlayerScriptableObject playerSO)
        {
            _playerView = Object.Instantiate(playerSO.PlayerView, playerSO.SpawnPosition, Quaternion.identity);
        }
    }
}