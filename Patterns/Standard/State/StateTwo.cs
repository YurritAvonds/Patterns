namespace Patterns.Standard.State;

public class StateTwo : BaseState, IState
{
    public string GetString()
    {
        Continue(new StateThree());
        return "Two";
    }
}
