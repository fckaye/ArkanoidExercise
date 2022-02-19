using ArkanoidExercise.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts
{
    public class Ball : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField] Collider ballCollider;
        [SerializeField] Rigidbody rigidBody;
        [SerializeField] private Vector3 shootForce;
        #endregion // SerializedFields

        #region Unity Callbacks
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Paddle))
            {
                BounceOff();
            }

            if (other.CompareTag(Tags.Lava))
            {

            }
        }
        #endregion // Unity Callbacks

        #region Public
        public void Shoot()
        {
            if (rigidBody is null) return;

            transform.parent = BallsManager.Instance.transform;
            rigidBody.AddForce(shootForce);
        }
        #endregion // Public

        #region Private
        private void BounceOff()
        {

        }

        private void DestroyBall()
        {

        }
        #endregion // Private
    }
}
