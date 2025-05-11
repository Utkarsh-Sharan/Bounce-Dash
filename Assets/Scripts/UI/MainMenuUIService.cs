using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MainMenu.UI
{
    public class MainMenuUIService : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(LoadGameScene);
            _quitButton.onClick.AddListener(QuitGame);
        }

        private void LoadGameScene() => SceneManager.LoadScene(1);
        private void QuitGame() => Application.Quit();

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(LoadGameScene);
            _quitButton.onClick.RemoveListener(QuitGame);
        }
    }
}