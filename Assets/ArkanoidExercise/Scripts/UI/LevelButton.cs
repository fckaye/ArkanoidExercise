using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ArkanoidExercise.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField] private int levelSceneIndex;
        #endregion // SerializedFields

        #region MonoBehaviour
        private void Start()
        {
            if (TryGetComponent(out Button button))
            {
                button.onClick.AddListener(GoToLevel);
            }
        }
        #endregion

        #region Private
        private void GoToLevel()
        {
            SceneManager.LoadScene(levelSceneIndex);
        }
        #endregion // Private
    }
}