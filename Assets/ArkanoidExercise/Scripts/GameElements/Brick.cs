using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts.GameElements
{
    public class Brick : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField] private int _hitPoints;
        [SerializeField] private ParticleSystem _destroyEffect;
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

        public static event Action<Brick> OnBrickDestruction;
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
            OnBrickDestruction?.Invoke(this);
            InstantiateDestroyEffect();
            Destroy(this.gameObject, 0.05f);
        }

        private void InstantiateDestroyEffect()
        {
            if (_destroyEffect is null) return;

            Vector3 brickPos = this.transform.position;
            Vector3 effectPos = new Vector3(brickPos.x, brickPos.y, brickPos.z - 0.2f);
            GameObject effectObj = Instantiate(_destroyEffect.gameObject, effectPos, Quaternion.identity);

            Destroy(effectObj, _destroyEffect.main.startLifetime.constant);
        }
        #endregion // Private
    }
}