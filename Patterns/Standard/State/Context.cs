namespace Patterns.Standard.State
{
    public class Context(IState InitialState)
    {
        private IState state = InitialState;

        public void ChangeState(IState newState) => state = newState;

        public string GetString() => state.GetString();
    }
}
