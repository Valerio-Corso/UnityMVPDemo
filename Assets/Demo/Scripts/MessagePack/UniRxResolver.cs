using System;
using System.Collections.Generic;
using System.Reflection;
using MessagePack;
using MessagePack.Formatters;
using UniRx;

namespace Demo.Scripts.MessagePackDemo
{
    public class UniRxResolver : IFormatterResolver
    {
        public static readonly UniRxResolver Instance = new();

        private UniRxResolver()
        {
        }
        
        public IMessagePackFormatter<T>? GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            internal static readonly IMessagePackFormatter<T>? Formatter;

            static FormatterCache()
            {
                Formatter =
                    (IMessagePackFormatter<T>?)UniRxReactivePropertyResolverGetFormatterHelper.GetFormatter(typeof(T));
            }
        }
    }

    internal static class UniRxReactivePropertyResolverGetFormatterHelper
    {
        private static readonly Dictionary<Type, Type> FormatterMap = new()
        {
            // Add other UniRx types and their corresponding formatters here
            { typeof(ReactiveProperty<>), typeof(ReactivePropertyFormatter<>) },
        };

        internal static object? GetFormatter(Type t)
        {
            TypeInfo ti = t.GetTypeInfo();

            if (ti.IsGenericType)
            {
                Type genericType = ti.GetGenericTypeDefinition();
                if (FormatterMap.TryGetValue(genericType, out Type formatterType))
                {
                    return CreateInstance(formatterType, ti.GenericTypeArguments);
                }
            }

            return null;
        }

        private static object? CreateInstance(Type genericType, Type[] genericTypeArguments, params object[] arguments)
        {
            return Activator.CreateInstance(genericType.MakeGenericType(genericTypeArguments), arguments);
        }
    }
}