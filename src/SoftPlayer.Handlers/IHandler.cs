using System.Threading.Tasks;

namespace SoftPlayer.Handlers
{
    public interface IHandler<T, TValue>
        where T : Command
        where TValue : EventBase
    {
       Task<TValue> Handler(T command);
    }
}
