namespace Patterns.Standard.State;

public interface IState
{
    public string GetString();
    public void SetContext(Context context);
}
