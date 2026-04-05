using Patterns.Standard.ChainOfResponsibility.Examples;

namespace Patterns.Standard.ChainOfResponsibility.Concept;

public interface IHandler
{
    public void Handle(Request request, Context context);
}
