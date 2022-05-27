using UnityEngine;

namespace NumBattle
{
    public sealed class UserManager : SingletonMonoBehaviour<UserManager>
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
