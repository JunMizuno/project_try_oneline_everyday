namespace NumBattle
{
    public sealed class PlayManager : SingletonMonoBehaviour<PlayManager>
    {
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