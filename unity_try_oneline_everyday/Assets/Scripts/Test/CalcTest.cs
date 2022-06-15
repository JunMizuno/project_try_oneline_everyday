using System.Collections;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;

using UnityEngine;

namespace Test
{
    public class CalcTest : MonoBehaviour
    {
        private void Awake()
        {
            this.OnTriggerEnterAsObservable()
                .Subscribe(collision =>
                {
                    Debug.Log("<color=cyan>" + "OnTriggerEnterAsObservable  collision.name:" + collision.name + "</color>");
                })
                .AddTo(this);

            this.OnTriggerStayAsObservable()
                .Subscribe(collision =>
                {
                    Debug.Log("<color=cyan>" + "OnTriggerStayAsObservable  collision.name:" + collision.name + "</color>");
                })
                .AddTo(this);

            this.OnTriggerExitAsObservable()
                .Subscribe(collision =>
                {
                    Debug.Log("<color=cyan>" + "OnTriggerExitAsObservable  collision.name:" + collision.name + "</color>");
                })
                .AddTo(this);
        }

        private void Start()
        {
            UniTaskTestAsync();
        }

        private void Update()
        {

        }

        private async void UniTaskTestAsync()
        {
            var str1 = await WaitTestAsync(3);

            Debug.Log("<color=cyan>" + "戻り値として受け取った値:" + str1 + "</color>");

            WaitVoidFuncAsync();

            await WaitReturnTestAsync(2);

            WaitVoidTestAsync(2).Forget();

            var str2 = await WaitTestAsync(1);

            Debug.Log("<color=cyan>" + "戻り値として受け取った値:" + str2 + "</color>");
        }


        private async UniTask<string> WaitTestAsync(float waitTime)
        {
            Debug.Log("<color=cyan>" + "WaitTest開始 " + waitTime + "秒待機指定" + "</color>");

            await UniTask.Delay((int)(waitTime * 1000));

            return "WaitTest終了";
        }

        private async UniTaskVoid WaitVoidTestAsync(float waitTime)
        {
            Debug.Log("<color=cyan>" + "WaitVoidTestAsync開始 " + waitTime + "秒待機指定" + "</color>");

            await UniTask.Delay((int)(waitTime * 1000));

            Debug.Log("<color=cyan>" + "WaitVoidTestAsync終了" + "</color>");
        }

        private async UniTask<bool> WaitReturnTestAsync(float waitTime)
        {
            Debug.Log("<color=cyan>" + "WaitReturnTestAsync開始 " + waitTime + "秒待機指定" + "</color>");

            bool retValue = false;

            await UniTask.Delay((int)(waitTime * 1000));
            retValue = true;

            await UniTask.WaitUntil(() => retValue);

            Debug.Log("<color=cyan>" + "WaitReturnTestAsync終了" + "</color>");

            return retValue;
        }

        private async void WaitVoidFuncAsync()
        {
            Debug.Log("<color=cyan>" + "WaitVoidFuncAsync開始" + "</color>");

            await UniTask.Delay((int)(5 * 1000));

            Debug.Log("<color=cyan>" + "WaitVoidFuncAsync終了" + "</color>");
        }

        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log("<color=cyan>" + "OnCollisionEnter  collision.name:" + collision.gameObject.name + "</color>");
        }

        public void OnCollisionExit(Collision collision)
        {
            Debug.Log("<color=cyan>" + "OnCollisionExit  collision.name:" + collision.gameObject.name + "</color>");
        }
    }
}
