namespace Patterns.Standard.ChainOfResponsibility;

/// <summary>
/// Basic implementation of the chain of responsibility pattern for handling requests.
/// Handles a request and then passes it on to the next handler in the chain if it exists.
/// </summary>
/// <param name="nextHandler">The next handler in the chain to which the request will be 
/// passed. Can be null to indicate that a handler is the end of the chain.</param>
public abstract class BaseHandler(IHandler? nextHandler) : IHandler
{
    private readonly IHandler? nextHandler = nextHandler;

    public virtual void Handle(Request request, Context context)
    {
        // Do some processing here in an implementation
        // ...

        // Pass the request on to the next handler in the chain if it exists
        nextHandler?.Handle(request, context);
    }
}
