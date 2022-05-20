using System.Collections;
namespace NumBattle
{
    public sealed class UserManager : SingletonMonoBehaviour<UserManager>
    {
        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(this);
        }
    }
}