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
        /// �}�E�X���I�u�W�F�N�g��ɏ������
        /// </summary>
        public virtual void OnMouseEnter()
        {

        }

        /// <summary>
        /// �}�E�X���I�u�W�F�N�g��ɏ���Ă����
        /// </summary>
        public virtual void OnMouseOver()
        {

        }

        /// <summary>
        /// �}�E�X���I�u�W�F�N�g���痣�ꂽ��
        /// </summary>
        public virtual void OnMouseExit()
        {

        }

        /// <summary>
        /// �N���b�N����������
        /// </summary>
        public virtual void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
        }

        /// <summary>
        /// �N���b�N���������ꂽ��
        /// </summary>
        public virtual void OnMouseUp()
        {

        }

        /// <summary>
        /// �N���b�N�������ɂ��ꂪ�I�u�W�F�N�g�ゾ�����ꍇ
        /// </summary>
        public virtual void OnMouseUpAsButton()
        {

        }

        /// <summary>
        /// �N���b�N��Ƀh���b�O�������Ă����
        /// </summary>
        public virtual void OnMouseDrag()
        {

        }
    }
}