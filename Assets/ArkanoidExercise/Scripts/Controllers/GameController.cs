using ArkanoidExercise.Scripts.GameElements;
using ArkanoidExercise.Scripts.UI;
using ArkanoidExercise.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts.Controllers
{
    public class GameController : Singleton<GameController>
    {
        #region SerializedFields
        [SerializeField] private int maxLifes;
        #endregion // SerializedFields

        #region Class members
        public bool GameStarted { get; set; }

        private int _lifes;
        #endregion // Class members

        #region MonoBehaviour
        private void Start()
        {
            Initialize();
        }
        #endregion // MonoBehaviour

        #region Public
        public void PlayerWin()
        {
            GameUIController.Instance.ShowGameOverUI(true);
        }

        public void LoseLife()
        {
            _lifes--;
            GameUIController.Instance.UpdateLifeCounter(_lifes);

            if (_lifes <= 0)
            {
                PlayerLose();
            }
            else
            {
                SetNextRound();
            }
        }
        #endregion // Public

        #region Private
        private void Initialize()
        {
            _lifes = maxLifes;
            GameUIController.Instance.UpdateLifeCounter(_lifes);
        }

        private void PlayerLose()
        {
            GameUIController.Instance.ShowGameOverUI(false);
        }

        private void SetNextRound()
        {
            this.GameStarted = false;
            Paddle.Instance.ResetToStartPos();
            BallsManager.Instance.ReInitialize();
        }
        #endregion // Private
    }
}