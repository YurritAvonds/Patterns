namespace Patterns.Standard.ChainOfResponsibility;

public class BaseHandler(IHandler? nextHandler) : IHandler
{
    private readonly IHandler? nextHandler = nextHandler;

    public virtual void Handle(Request request, Context context)
    {
        nextHandler?.Handle(request, context);
    }
}
