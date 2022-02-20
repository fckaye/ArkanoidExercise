using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts.GameElements
{
    [Serializable]
    public class BrickColors
    {
        public Color color;
        public int hitPoint;
    }

    public class Brick : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField] private BrickColors[] _hitColors;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private int _hitPoints;
        [SerializeField] private ParticleSystem _destroyEffect;
        #endregion // SerializedFields

        #region Class Members
        public static event Action<Brick> OnBrickDestruction;
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

        private Material material; 
        #endregion // Class Members

        #region Unity Callbacks
        private void Awake()
        {
            GetMaterial();
            UpdateColor();
        }

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
            UpdateColor();
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

        private void GetMaterial()
        {
            Renderer renderer = GetComponentInChildren<Renderer>();
            if (renderer != null)
            {
                material = renderer.material;
            }
        }

        private void UpdateColor()
        {
            if (material is null) return;

            bool foundColorMatch = false;

            foreach (BrickColors hitColor in _hitColors)
            {
                if (hitColor.hitPoint == _hitPoints)
                {
                    material.color = hitColor.color;
                    foundColorMatch = true;
                }
            }

            if (!foundColorMatch)
            {
                material.color = _defaultColor;
            }
        }
        #endregion // Private
    }
}