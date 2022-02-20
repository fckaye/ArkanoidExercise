using ArkanoidExercise.Scripts.GameElements;
using ArkanoidExercise.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ArkanoidExercise.Scripts.Controllers
{
    public class BricksManager : Singleton<BricksManager>
    {
        #region Class Members
        private List<Brick> bricks;
        #endregion // Class Members

        #region MonoBehaviour
        private void Start()
        {
            bricks = FindObjectsOfType<Brick>().ToList();
            Brick.OnBrickDestruction += UpdateBrickStatus;
        }

        private void OnDestroy()
        {
            Brick.OnBrickDestruction -= UpdateBrickStatus;
            base.OnDestroy();
        }
        #endregion // MonoBehaviour

        #region Private
        private void UpdateBrickStatus(Brick brick)
        {
            if (bricks.Contains(brick))
            {
                bricks.Remove(brick);
            }

            if (bricks.Count <= 0)
            {
                GameController.Instance.PlayerWin();
            }
        }
        #endregion // Private
    }
}