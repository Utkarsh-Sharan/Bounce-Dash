using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Event;

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
            EventService.Instance.OnPlayerDeathEvent.Addlistener(GameOver);
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
            EventService.Instance.OnPlayerDeathEvent.RemoveListener(GameOver);
            _restartButton.onClick.RemoveListener(RestartGame);
            _mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        }
    }
}