using ArkanoidExercise.Scripts.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts
{
    public class Ball : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField] private Vector3 _shootForce;
        [SerializeField] private float _bounceStrength;
        #endregion // SerializedFields

        #region Class Members
        public static event Action<Ball> OnBallDestruction;
        private Rigidbody ballRigidbody;
        public Vector3 ShootForce => _shootForce;
        public float BounceStrength => _bounceStrength;
        #endregion // ClassMembers

        #region Unity Callbacks
        private void Awake()
        {
            this.ballRigidbody = this.gameObject.GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Lava))
            {
                Die();
            }
        }
        #endregion // Unity Callbacks

        #region Public
        public void Shoot()
        {
            if (ballRigidbody is null) return;

            transform.parent = BallsManager.Instance.transform;
            ballRigidbody.AddForce(_shootForce);
        }
        #endregion // Public

        #region Private
        private void Die()
        {
            OnBallDestruction?.Invoke(this);
            Destroy(this.gameObject);
        }
        #endregion // Private
    }
}
