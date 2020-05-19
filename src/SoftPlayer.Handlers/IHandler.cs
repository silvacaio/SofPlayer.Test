namespace SoftPlayer.Handlers
{
    public interface IHandler<T, TValue>
        where T : Command
        where TValue : EventBase
    {
        TValue Handler(T command);
    }
}
