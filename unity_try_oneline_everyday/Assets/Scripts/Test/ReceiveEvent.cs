using UnityEngine;
using UnityEngine.EventSystems;

namespace Test
{
    public interface IReceiveEvent : IEventSystemHandler
    {
        void OnReceive();
    }

    public class ReceiveEvent : MonoBehaviour, IReceiveEvent
    {
        private void Start()
        {

        }

        /// <summary>
        /// Interfaceを使う場合、Eventの場合はprivateはダメとのこと。
        /// SendMessageを併用している場合、メソッド名は重複しないようにしないといけない。
        /// </summary>
        public void OnReceive()
        {
            Debug.Log("<color=cyan>" + "ReceiveEvent  OnReceive" + "</color>");
        }
    }
}
