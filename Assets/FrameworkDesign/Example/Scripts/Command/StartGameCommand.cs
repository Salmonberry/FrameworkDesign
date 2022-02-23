using FrameworkDesign;
using FrameworkDesign.Example;


public class StartGameCommand : ICommand
{
    public void Execute()
    {
        GameStartEvent.Trigger();
    }
}
