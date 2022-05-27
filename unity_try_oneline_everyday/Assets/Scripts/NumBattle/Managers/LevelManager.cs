namespace NumBattle
{
    public class LevelManager : SingletonMonoBehaviour<LevelManager>
    {
        public enum LevelState
        {
            Title,
            Home,
            InGame,
            Result,
        }

        private LevelState currentState = LevelState.Title;
        public LevelState CurrentState
        {
            get
            {
                return currentState;
            }
        }

        protected override void Awake()
        {
            base.Awake();
        }

        public override void OnDestory()
        {
            base.OnDestory();
        }

        public void ChangeLevelState(LevelState nextLevelState)
        {
            if (currentState == nextLevelState)
            {
                return;
            }

            currentState = nextLevelState;
        }
    }
}
