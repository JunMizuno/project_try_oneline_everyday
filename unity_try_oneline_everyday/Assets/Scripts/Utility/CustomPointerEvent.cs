using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Utility
{
    public class CustomPointerEvent : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField]
        public UnityEvent releasedEvent;

        public void OnPointerUp(PointerEventData eventData)
        {
            releasedEvent.Invoke();
        }
    }
}
