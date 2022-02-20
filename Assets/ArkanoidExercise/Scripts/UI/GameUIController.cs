using ArkanoidExercise.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ArkanoidExercise.Scripts.UI
{
    public class GameUIController : Singleton<GameUIController>
    {
        #region SerializedFields
        [SerializeField] GameOverPanel gameOverPanel;
        [SerializeField] LifeCounter lifeCounter;
        #endregion // SerializedFields

        #region Public
        public void ShowGameOverUI(bool playerWin)
        {
            if (gameOverPanel is null) return;

            gameOverPanel.Show(playerWin);
        }

        public void UpdateLifeCounter(int lives)
        {
            if (lifeCounter is null) return;

            lifeCounter.SetLives(lives);
        }
        #endregion // Public
    }
}
