using AD.Mono.Pong.Engine.StateMachines;

namespace AD.Mono.Pong.GameStates.Splash;

public class CountdownDecision : IDecision
{
    private int _count; 

    public CountdownDecision(int count)
    {
        _count = count;
    }

    public void Load()
    {

    }

    public bool Decide()
    {
        _count--;
        return _count <= 0;
    }
}
