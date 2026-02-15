namespace Patterns.Standard.ChainOfResponsibility
{
    public class IntegerHandler(IHandler? nextHandler) : BaseHandler(nextHandler)
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
}
