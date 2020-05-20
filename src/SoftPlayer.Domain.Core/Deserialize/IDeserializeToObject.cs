using System.Text.Json;

namespace SoftPlayer.Domain.Core.Deserialize
{
    public interface IDeserializeToObject<T>
    {
        T Deserialize(string value);
    }

    public class DeserializeToObject<T> : IDeserializeToObject<T>
    {
        public T Deserialize(string value)
        {
            return JsonSerializer.Deserialize<T>(value);
        }
    }
}
