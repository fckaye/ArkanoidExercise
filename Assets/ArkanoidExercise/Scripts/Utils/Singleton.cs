using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkanoidExercise.Scripts.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;
        public static T Instance => _instance;

        protected virtual void Awake()
        {
            if(_instance is null)
            {
                _instance = this as T;
            }
            else if (_instance != this)
            {
                Destroy(this);
            }
        }

        protected virtual void OnDestroy()
        {
            if (_instance != this) return;

            _instance = null;
        }

        public virtual void OnApplicationQuit()
        {
            _instance = null;
        }
    }
}
