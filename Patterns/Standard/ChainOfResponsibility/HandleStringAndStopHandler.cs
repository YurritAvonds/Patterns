namespace Patterns.Standard.ChainOfResponsibility;

public class HandleStringAndStopHandler(IHandler? nextHandler) : BaseHandler(nextHandler)
{
    override public void Handle(Request request, Context context)
    {
        if (request?.StringValue != null)
        {
            context.HasValidString = request.StringValue.Length > 10;
        }
    }
}
