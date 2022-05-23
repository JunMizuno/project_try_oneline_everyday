using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NumBattle
{
    public class ObjectBase : MonoBehaviour
    {
        protected void Start()
        {

        }

        protected void Update()
        {

        }

        /// <summary>
        /// マウスがオブジェクト上に乗った時
        /// </summary>
        public virtual void OnMouseEnter()
        {

        }

        /// <summary>
        /// マウスがオブジェクト上に乗っている間
        /// </summary>
        public virtual void OnMouseOver()
        {

        }

        /// <summary>
        /// マウスがオブジェクトから離れた時
        /// </summary>
        public virtual void OnMouseExit()
        {

        }

        /// <summary>
        /// クリックがあった時
        /// </summary>
        public virtual void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
        }

        /// <summary>
        /// クリックが解除された時
        /// </summary>
        public virtual void OnMouseUp()
        {

        }

        /// <summary>
        /// クリック解除時にそれがオブジェクト上だった場合
        /// </summary>
        public virtual void OnMouseUpAsButton()
        {

        }

        /// <summary>
        /// クリック後にドラッグが続いている間
        /// </summary>
        public virtual void OnMouseDrag()
        {

        }
    }
}