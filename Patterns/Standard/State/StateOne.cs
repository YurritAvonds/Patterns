namespace Patterns.Standard.State
{
    public class StateOne : BaseState, IState
    {
        public string GetString()
        {
            Continue(new StateTwo());
            return "One";
        }
    }
}
