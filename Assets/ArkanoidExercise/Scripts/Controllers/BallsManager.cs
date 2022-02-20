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
        [SerializeField] private float tapDistanceThreshold;
        #endregion // SerializeFields

        #region Class Members
        private bool _initialized;

        private Vector2 _tapStartPos;
        private Vector2 _tapEndPos;

        private List<Ball> _balls;
        public List<Ball> Balls => _balls;
        #endregion // Class Members

        #region MonoBehaviour
        private void Start()
        {
            Initialize();
            Ball.OnBallDestruction += UpdateBallStatus;
        }

        private void Update()
        {
            if (_initialized && !GameController.Instance.GameStarted)
            {
                CheckInitialTapInput();
            }
        }

        private void OnDestroy()
        {
            Ball.OnBallDestruction -= UpdateBallStatus;
            base.OnDestroy();
        }
        #endregion // MonoBehaviour

        #region Public
        public void ReInitialize()
        {
            Initialize();
        }
        #endregion // Public

        #region Private
        private void Initialize()
        {
            _balls = new List<Ball>();
            CreateBallOnPaddle();
            _initialized = true;
        }

        private void CreateBallOnPaddle()
        {
            GameObject ballObj = Instantiate(ballPrefab, Paddle.Instance.BallStartPos);
            if (ballObj.TryGetComponent(out Ball ball))
            {
                _balls.Add(ball);
            }
        }

        private void CheckInitialTapInput()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _tapStartPos = touch.position;
                    _tapEndPos = touch.position;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    _tapEndPos = touch.position;

                    if (Vector2.Distance(_tapEndPos, _tapStartPos) <= tapDistanceThreshold)
                    {
                        FireInitialTap();
                    }
                }
            }
        }

        private void FireInitialTap()
        {
            GameController.Instance.GameStarted = true;
            foreach (Ball ball in _balls)
            {
                ball.Shoot();
            }
        }

        private void UpdateBallStatus(Ball ball)
        {
            if (_balls.Contains(ball))
            {
                _balls.Remove(ball);
            }

            if (_balls.Count <= 0)
            {
                GameController.Instance.LoseLife();
            }
        }
        #endregion // Private
    }
}