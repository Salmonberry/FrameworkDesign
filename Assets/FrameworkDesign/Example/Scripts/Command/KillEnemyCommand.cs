namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            var gameModel = PointGame.Get<IGameModel>();

          gameModel.KillCount.Value++;

            //十个全部消灭显示通关界面
            if (gameModel.KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}


