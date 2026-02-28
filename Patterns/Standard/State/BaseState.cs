namespace Patterns.Standard.State;

public class BaseState
{
    protected Context? _context;

    public void SetContext(Context context) => _context = context;

    public void Continue(IState newState)
    {
        if (_context == null)
        {
            throw new NullReferenceException("Context was null in Continue method.");
        }

        newState.SetContext(_context);
        _context?.ChangeState(newState);
    }
}
