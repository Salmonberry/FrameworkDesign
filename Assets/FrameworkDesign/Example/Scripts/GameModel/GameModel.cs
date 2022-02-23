
namespace FrameworkDesign.Example
{
    public enum GameStates
    {
        NotStart,
        Started,
        Over
    }

    public interface IGameModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold { get; }
        BindableProperty<int> Score { get; }
        BindableProperty<int> BestScore { get; }

    }

    public class GameModel:IGameModel
    {
        /// <summary>
        /// ÓÎÏ·µÄ×´Ì¬
        /// </summary>
        public  GameStates State = GameStates.NotStart;

        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> Gold { get; } = new BindableProperty<int>
        {
            Value = 0
        };

        public BindableProperty<int> Score { get; } = new BindableProperty<int>
        {
            Value = 0
        };

        public BindableProperty<int> BestScore { get; } = new BindableProperty<int> { Value = 0 };
    }

}
