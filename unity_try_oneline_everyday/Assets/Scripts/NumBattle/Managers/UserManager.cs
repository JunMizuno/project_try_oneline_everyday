namespace NumBattle
{
    public sealed class UserManager : SingletonMonoBehaviour<UserManager>
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