using UnityEngine;
using UnityEngine.EventSystems;

namespace Test
{
    public class SendEvent : MonoBehaviour
    {
        private void Start()
        {
            // target : �Ăяo���Ώۂ̃I�u�W�F�N�g
            // eventData : �C�x���g�f�[�^(���W���[���Ȃǂ̏��)
            // functor : ����
            ExecuteEvents.Execute<IReceiveEvent>(target:gameObject, eventData:null, functor: (receiver, eventData) => receiver.OnReceive());
        }
    }
}