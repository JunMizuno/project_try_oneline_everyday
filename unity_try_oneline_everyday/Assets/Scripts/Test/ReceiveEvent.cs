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
        /// Interface���g���ꍇ�AEvent�̏ꍇ��private�̓_���Ƃ̂��ƁB
        /// SendMessage�𕹗p���Ă���ꍇ�A���\�b�h���͏d�����Ȃ��悤�ɂ��Ȃ��Ƃ����Ȃ��B
        /// </summary>
        public void OnReceive()
        {
            Debug.Log("<color=cyan>" + "ReceiveEvent  OnReceive" + "</color>");
        }
    }
}