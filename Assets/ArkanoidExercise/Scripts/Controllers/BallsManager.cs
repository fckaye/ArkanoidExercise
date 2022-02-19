using ArkanoidExercise.Scripts.GameElements;
using ArkanoidExercise.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts.Controllers
{
    public class BallsManager : Singleton<BallsManager>
    {
        #region SerializeFields
        [SerializeField] private GameObject ballPrefab;
        #endregion // SerializeFields

        #region Class Members
        private List<Ball> _balls;
        public List<Ball> Balls => _balls;
        #endregion // Class Members

        #region MonoBehaviour
        private void Start()
        {
            Initialize();
        }
        #endregion // MonoBehaviour

        #region Public

        #endregion // Public

        #region Private
        private void Initialize()
        {
            CreateBallOnPaddle();
        }

        private void CreateBallOnPaddle()
        {
            GameObject ballObj = Instantiate(ballPrefab, Paddle.Instance.BallStartPos);
        }
        #endregion // Private
    }
}