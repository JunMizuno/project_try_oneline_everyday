using System.Collections;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace Test
{
    public class CalcTest : MonoBehaviour
    {
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
    }
}
