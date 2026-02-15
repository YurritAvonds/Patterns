namespace Patterns.Standard.ChainOfResponsibility
{
    public class IntegerHandler(IHandler? nextHandler) : BaseHandler(nextHandler)
    {
        override public void Handle(Request request, Context context)
        {
            if (CanHandle(request))
            {
                context.HasValidInteger = request.IntegerValue > 0;
            }
            base.Handle(request, context);
        }

        private bool CanHandle(Request request)
        {
            return request.IntegerValue != null;
        }
    }
}
