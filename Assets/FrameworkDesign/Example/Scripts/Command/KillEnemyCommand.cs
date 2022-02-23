namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            var gameModel = PointGame.Get<IGameModel>();

          gameModel.KillCount.Value++;

            //ʮ��ȫ��������ʾͨ�ؽ���
            if (gameModel.KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}


