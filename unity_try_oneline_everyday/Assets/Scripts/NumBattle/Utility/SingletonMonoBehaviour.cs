using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumBattle
{
    /// <summary>
    /// シングルトンベース
    /// </summary>
    /// <typeparam name="T">where T : T は MonoBehaviour を継承しているクラスに限る</typeparam>
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T instance;

        public static T Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.Log("<color=red>" + "Singleton  " + typeof(T) + "is nothing" + "</color>");
                }

                return instance;
            }
        }

        public static T InstanceNullable
        {
            get
            {
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                return;
            }

            instance = this as T;
        }

        public virtual void OnDestory()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}
