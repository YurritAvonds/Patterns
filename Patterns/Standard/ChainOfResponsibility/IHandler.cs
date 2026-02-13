namespace Patterns.Standard.ChainOfResponsibility
{
    public interface IHandler
    {
        public void Handle(Request request, Context context);
    }
}
