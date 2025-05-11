using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI
{
    public class GameUIService : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUIObject;
        [SerializeField] private GameObject _mobileInputs;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _mainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void GameOver()
        {
            _mobileInputs.SetActive(false);
            _gameOverUIObject.SetActive(true);
        } 

        private void RestartGame() => SceneManager.LoadScene(1);
        private void GoToMainMenu() => SceneManager.LoadScene(0);

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        }
    }
}