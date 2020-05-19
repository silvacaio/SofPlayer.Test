namespace SoftPlayer.Handlers
{
    public class EventBase
    {
        public bool Valid { get; set; }

        public string Error { get; set; }     
    }

    public class Event<T> : EventBase
    {

        public T Value { get; set; }

        public static Event<T> CreateSuccess(T value)
        {
            return new Event<T>
            {
                Value = value,
                Valid = true,
                Error = string.Empty
            };
        }

        public static Event<T> CreateError(string error)
        {
            return new Event<T>
            {
                Value = default,
                Valid = false,
                Error = error
            };
        }
    }
}
