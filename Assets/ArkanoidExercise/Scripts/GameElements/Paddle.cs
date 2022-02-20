using ArkanoidExercise.Scripts.Controllers;
using ArkanoidExercise.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts.GameElements
{
    public class Paddle : Singleton<Paddle>
    {
        #region SerializedFields
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _paddleStartPos;
        [SerializeField] private Transform _ballStartPos;
        #endregion // SerializedFields

        #region Class Members
        private Vector2 _dragStart;
        private Vector2 _dragEnd;

        public Transform BallStartPos => _ballStartPos;
        #endregion // Class Members

        #region MonoBehaviour Callbacks
        private void Update()
        {
            CheckInput();
            MovePaddle();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision != null &&
                collision.rigidbody != null &&
                collision.rigidbody.CompareTag(Tags.Ball))
            {
                CalculateBounceDirection(collision);
            }
        }
        #endregion // MonoBehaviour Callbacks.

        #region Public
        public void ResetToStartPos()
        {
            this.transform.position = _paddleStartPos;
        }
        #endregion // Public

        #region Private
        private void CheckInput()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _dragStart = touch.position;
                    _dragEnd = touch.position;
                }

                if (touch.phase == TouchPhase.Moved ||
                    touch.phase == TouchPhase.Stationary)
                {
                    _dragEnd = touch.position;
                }

                if (touch.phase == TouchPhase.Canceled ||
                    touch.phase == TouchPhase.Ended)
                {
                    _dragStart = Vector2.zero;
                    _dragEnd = Vector2.zero;
                }
            }
        }

        private void MovePaddle()
        {
            float x = GetSwipeDirection();
            Vector3 direction = new Vector3(x, 0, 0);
            this.transform.Translate(direction * _speed * Time.deltaTime);
        }

        private float GetSwipeDirection()
        {
            float direction = _dragEnd.x - _dragStart.x;
            return Mathf.Clamp(direction, -1.0f, 1.0f);
        }

        private void CalculateBounceDirection(Collision collision)
        {
            if (!GameController.Instance.GameStarted) return;
            if (collision is null) return;

            if (collision.gameObject.TryGetComponent(out Ball ball))
            {
                Rigidbody ballRB = collision.rigidbody;

                Vector3 contactPoint = collision.contacts[0].point;

                float distanceToCenter = contactPoint.x - this.transform.position.x;
                float xDirection = Mathf.Clamp(distanceToCenter, -1.0f, 1.0f);

                Vector3 newBallDirection = ball.ShootForce;
                newBallDirection.x = xDirection * ball.BounceStrength;

                ballRB.velocity = Vector3.zero;
                ballRB.AddForce(newBallDirection);
            }
        }
        #endregion // Private
    }
}