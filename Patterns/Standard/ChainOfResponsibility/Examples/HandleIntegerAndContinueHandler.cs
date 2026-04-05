using Patterns.Standard.ChainOfResponsibility.Concept;

namespace Patterns.Standard.ChainOfResponsibility.Examples;

public class HandleIntegerAndContinueHandler(IHandler? nextHandler) : BaseHandler(nextHandler)
{
    override public void Handle(Request request, Context context)
    {
        if (request.IntegerValue != null)
        {
            context.HasValidInteger = request.IntegerValue > 0;
        }
        base.Handle(request, context);
    }
}
