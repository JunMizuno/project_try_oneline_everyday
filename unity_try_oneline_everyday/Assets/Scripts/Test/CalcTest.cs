using System.Collections;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace Test
{
    public class CalcTest : MonoBehaviour
    {
        private async void Start()
        {
            var str1 = await WaitTest(3);

            Debug.Log("<color=cyan>" + "戻り値として受け取った値:" + str1 + "</color>");

            var str2 = await WaitTest(1);

            Debug.Log("<color=cyan>" + "戻り値として受け取った値:" + str2 + "</color>");
        }

        private void Update()
        {

        }

        private async UniTask<string> WaitTest(float waitTime)
        {
            Debug.Log("<color=cyan>" + "WaitTest開始 " + waitTime + "秒待機指定" + "</color>");

            await UniTask.Delay((int)(waitTime * 1000));

            return "WaitTest終了";
        }
    }
}
