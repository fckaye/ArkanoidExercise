using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ArkanoidExercise.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LifeCounter : MonoBehaviour
    {
        public static string LIFE_FORMAT = $"Lifes: {0}";

        #region Class Members
        private TextMeshProUGUI _label;
        #endregion // ClassMembers

        #region MonoBehaviour
        private void Start()
        {
            if (TryGetComponent(out TextMeshProUGUI textField))
            {
                _label = textField;
            }
        }
        #endregion

        #region Public
        public void SetLives(int lifes)
        {
            if (_label is null) return;

            _label.text = string.Format(LIFE_FORMAT, lifes);
        }
        #endregion // Public
    }
}
