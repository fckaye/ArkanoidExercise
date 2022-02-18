using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts
{
    public class Paddle : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField] private float speed;
        #endregion // SerializedFields

        #region Class Members
        private Vector2 dragStart;
        private Vector2 dragEnd;
        #endregion // Class Members

        #region MonoBehaviour Callbacks
        private void Update()
        {
            CheckInput();
            MovePaddle();
        }
        #endregion // MonoBehaviour Callbacks.

        #region Private
        private void CheckInput()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    dragStart = touch.position;
                    dragEnd = touch.position;
                }

                if (touch.phase == TouchPhase.Moved ||
                    touch.phase == TouchPhase.Stationary)
                {
                    dragEnd = touch.position;
                }

                if (touch.phase == TouchPhase.Canceled ||
                    touch.phase == TouchPhase.Ended)
                {
                    dragStart = Vector2.zero;
                    dragEnd = Vector2.zero;
                }
            }
        }

        private void MovePaddle()
        {
            float x = GetSwipeDirection();
            Vector3 direction = new Vector3(x, 0, 0);
            this.transform.Translate(direction * speed * Time.deltaTime);
        }

        private float GetSwipeDirection()
        {
            float direction = dragEnd.x - dragStart.x;
            return Mathf.Clamp(direction, -1.0f, 1.0f);
        }
        #endregion // Private
    }
}