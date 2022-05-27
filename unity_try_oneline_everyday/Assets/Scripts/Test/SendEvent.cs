using UnityEngine;
using UnityEngine.EventSystems;

namespace Test
{
    public class SendEvent : MonoBehaviour
    {
        private void Start()
        {
            // target : 呼び出す対象のオブジェクト
            // eventData : イベントデータ(モジュールなどの情報)
            // functor : 操作
            ExecuteEvents.Execute<IReceiveEvent>(target: gameObject, eventData: null, functor: (receiver, eventData) => receiver.OnReceive());
        }
    }
}
