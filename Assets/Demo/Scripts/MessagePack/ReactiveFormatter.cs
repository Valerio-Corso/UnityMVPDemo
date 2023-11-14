using MessagePack.Formatters;
using MessagePack;
using MessagePack.Resolvers;
using UniRx;

namespace Demo.Scripts.MessagePackDemo
{
    public class ReactivePropertyFormatter<T> : IMessagePackFormatter<ReactiveProperty<T>>
    {
        public void Serialize(ref MessagePackWriter writer, ReactiveProperty<T> value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            // Use the underlying formatter for type T to serialize the value
            var underlyingFormatter = options.Resolver.GetFormatter<T>();
            underlyingFormatter.Serialize(ref writer, value.Value, options);
        }

        public ReactiveProperty<T> Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            // Use the underlying formatter for type T to deserialize the value
            var underlyingFormatter = options.Resolver.GetFormatter<T>();
            T deserializedValue = underlyingFormatter.Deserialize(ref reader, options);
            return new ReactiveProperty<T>(deserializedValue);
        }
    }
}