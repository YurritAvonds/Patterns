namespace Patterns.Standard.ChainOfResponsibility
{
    public class StringContinueHandler(IHandler nextHandler) : BaseHandler(nextHandler)
    {
        override public void Handle(Request request, Context context)
        {
            if (CanHandle(request))
            {
                context.HasValidString = request.StringValue.Length > 10;
            }
            base.Handle(request, context);
        }

        private bool CanHandle(Request request)
        {
            return request?.StringValue != null;
        }
    }
}
