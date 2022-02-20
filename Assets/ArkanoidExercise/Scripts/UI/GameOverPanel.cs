using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ArkanoidExercise.Scripts.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        #region SerializedFields
        [Header("Objects references.")]
        [SerializeField] RectTransform layoutContainer;
        [SerializeField] TextMeshProUGUI gameOverLabel;
        [SerializeField] Button restartButton;
        [SerializeField] Button mainMenuButton;

        [Space(10)]
        [Header("Config options.")]
        [SerializeField] string loseMessage;
        [SerializeField] string winMessage;
        #endregion // SerializedFields

        #region MonoBehaviour
        private void Awake()
        {
            Initialize();
        }
        #endregion // MonoBehaviour

        #region Public
        public void Show(bool playerWin)
        {
            ShowLayout(true);

            gameOverLabel.text = playerWin ? winMessage : loseMessage;
        }
        #endregion // Public

        #region Private
        private void Initialize()
        {
            ShowLayout(false);
            gameOverLabel.text = string.Empty;
            restartButton.onClick.AddListener(RestartCurrentLevel);
            mainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void ShowLayout(bool show)
        {
            if (layoutContainer is null) return;

            layoutContainer.gameObject.SetActive(show);
        }

        private void RestartCurrentLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        private void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        #endregion // Private
    }
}