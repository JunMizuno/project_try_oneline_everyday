using UnityEngine;

namespace NumBattle
{
    public sealed class PlayManager : SingletonMonoBehaviour<PlayManager>
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(this);
        }

        public override void OnDestory()
        {
            base.OnDestory();
        }
    }
}