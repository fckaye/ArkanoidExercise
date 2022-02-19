using ArkanoidExercise.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts.Controllers
{
    public class GameController : Singleton<GameController>
    {
        #region Class members
        public bool GameStarted { get; set; }
        #endregion // Class members

        #region MonoBehaviour
        private void Update()
        {
            
        }
        #endregion // MonoBehaviour

        #region Public
        public void PlayerWin()
        {
            Debug.Log("WIN!");
        }
        #endregion // Public
    }
}