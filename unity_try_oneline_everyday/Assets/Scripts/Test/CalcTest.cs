using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;

using UnityEngine;

namespace Test
{
    public class CalcTest : MonoBehaviour
    {
        public IObserver<Tuple<int, string>> TestAsObservable => this.TestSubject;
        private readonly Subject<Tuple<int, string>> TestSubject = new Subject<Tuple<int, string>>();

        public IObservable<(string, int, string)> Test2AsObservable => Test2Subject;
        private readonly Subject<(string, int, string)> Test2Subject = new Subject<(string, int, string)>();

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

            TestSubject
                .Subscribe((tuple) => Debug.Log("<color=yellow>" + "TestSubject  tuple.item1:" + tuple.Item1 + "  tuple.item2:" + tuple.Item2 + " </color>"))
                .AddTo(this);

            Test2Subject
                .Subscribe(tuple => Debug.Log("<color=yellow>" + "Test2Subject  tuple.item1:" + tuple.Item1 + "  tuple.item2:" + tuple.Item2 + "  tuple.item3:" + tuple.Item3 + " </color>"))
                .AddTo(this);
        }

        private void Start()
        {
            UniTaskTestAsync(this.GetCancellationTokenOnDestroy());

            List<(int, int)> baseList = new List<(int, int)>()
            {
                (1, 2),
                (3, 4),
                (5, 6),
                (7, 8),
                (9, 10),
            };

            List<int> afterList = new List<int>();

            baseList.ForEach((x) =>
            {
                afterList.Add(x.Item1);
                afterList.Add(x.Item2);
            });

            var convertedList = baseList.Select(x => new Pair<int>(x.Item2, x.Item1)).ToList();
            convertedList.ForEach((x) =>
            {
                Debug.Log("<color=yellow>" + "convertedList  Previous:" + x.Previous + "  Current:" + x.Current + " </color>");
            });

            afterList
                .Where((x) => x % 2 == 0)
                .Select((x) => x)
                .ToList()
                .ForEach((x) =>
                {
                    Debug.Log("<color=yellow>" + "finalList  x:" + x + " </color>");
                });

            TestSubject.OnNext(System.Tuple.Create(1, "string is 2"));

            Test2Subject.OnNext(("あ", 2, "さ"));


            var testValue = 0;
            var retValue = testValue switch
            {
                0 => 1,
                1 => 2,
                _ => 3,
            };
        }
 
        private void Update()
        {

        }

        private async void UniTaskTestAsync(CancellationToken token)
        {
            var cts = new CancellationTokenSource();
            cts.Token.ThrowIfCancellationRequested();
            token.ThrowIfCancellationRequested();

            var str1 = await WaitTestAsync(3);

            Debug.Log("<color=cyan>" + "戻り値として受け取った値:" + str1 + "</color>");

            WaitVoidFuncAsync();

            await WaitReturnTestAsync(2);

            WaitVoidTestAsync(2).Forget();

            var str2 = await WaitTestAsync(1);

            Debug.Log("<color=cyan>" + "戻り値として受け取った値:" + str2 + "</color>");

            Debug.Log("<color=cyan>" + "WaitCompleteFuncAsync  開始" + "</color>");

            var intList = await WaitCompleteFuncAsync();

            Debug.Log("<color=cyan>" + "WaitCompleteFuncAsync  終了" + "</color>");

            Debug.Log("<color=cyan>" + "戻り値として受け取った値:" + "</color>");
            intList.ForEach(x =>
            {
                Debug.Log("<color=cyan>" + x + "</color>");
            });
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

        private async UniTask<List<int>> WaitCompleteFuncAsync()
        {
            var ts = new UniTaskCompletionSource<List<int>>();

            var list = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);

                await UniTask.Delay(500);
            }

            ts.TrySetResult(list);

            return await ts.Task;
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
