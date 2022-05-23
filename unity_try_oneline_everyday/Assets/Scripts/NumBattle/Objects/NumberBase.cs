using UnityEngine;
using UnityEngine.EventSystems;

namespace NumBattle
{
    public class NumberBase : ObjectBase
    {
        public readonly uint ownNumber;

        public NumberBase(uint number)
        {
            ownNumber = number;
        }

        public override void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            GameObject clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;

                Debug.Log("<color=white>" + "Hit Object Name:" + clickedGameObject.name + "</color>");
            }
        }
    }
}
