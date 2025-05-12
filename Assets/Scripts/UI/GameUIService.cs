using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Event;
using System.Collections;

namespace Game.UI
{
    public class GameUIService : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUIObject;
        [SerializeField] private GameObject _mobileInputs;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _finalScoreText;
        [SerializeField] private Text _coinsCollectedText;

        private int _score = 0;
        private int _coins = 0;
        private bool _isGameOver = false;

        private void OnEnable()
        {
            EventService.Instance.OnPlayerDeathEvent.AddListener(GameOver);
            EventService.Instance.OnCoinCollectedEvent.AddListener(CoinCollected);

            _restartButton.onClick.AddListener(RestartGame);
            _mainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void Start()
        {
            StartCoroutine(ScoreRoutine());
            _scoreText.text = $"Score: 0";
            _coinsCollectedText.text = $": 0";
        }

        private IEnumerator ScoreRoutine()
        {
            while (!_isGameOver)
            {
                _scoreText.text = $"Score: {(++_score).ToString()}";
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void CoinCollected(int value)
        {
            _score += value;
            _coinsCollectedText.text = $": {(++_coins).ToString()}";
        } 

        private void GameOver()
        {
            _isGameOver = true;
            _finalScoreText.text = $"Score: {(_score).ToString()}";

            _mobileInputs.SetActive(false);
            _gameOverUIObject.SetActive(true);
        } 

        private void RestartGame() => SceneManager.LoadScene(1);    //Can use enum instead of hard coded value.
        private void GoToMainMenu() => SceneManager.LoadScene(0);

        private void OnDisable()
        {
            EventService.Instance.OnPlayerDeathEvent.RemoveListener(GameOver);
            EventService.Instance.OnCoinCollectedEvent.RemoveListener(CoinCollected);

            _restartButton.onClick.RemoveListener(RestartGame);
            _mainMenuButton.onClick.RemoveListener(GoToMainMenu);
        }
    }
}