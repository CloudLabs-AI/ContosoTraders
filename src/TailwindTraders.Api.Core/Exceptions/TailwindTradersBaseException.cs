namespace TailwindTraders.Api.Core.Exceptions;

public abstract class TailwindTradersBaseException : Exception
{
    protected ILogger Logger { get; set; }

    protected TailwindTradersBaseException(string message) : base(message)
    {
        Logger.LogError(message);
    }

    public abstract IActionResult ToActionResult();
}