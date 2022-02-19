using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts.GameElements
{
    public class Brick : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField] private int _hitPoints;
        #endregion // SerializedFields

        #region Class Members
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                if (_hitPoints <= 0)
                {
                    this.Die();
                }
            }
        }
        #endregion // Class Members

        #region Unity Callbacks
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Ball))
            {
                TakeDamage();
            }
        }
        #endregion // Unity Callbacks

        #region Private
        private void TakeDamage()
        {
            HitPoints--;
        }

        private void Die()
        {
            Debug.Log("Brick died");
        }
        #endregion // Private
    }
}