using Core;
using Demo.Scripts.MessagePackDemo;
using Demo.Scripts.VContainerDemo;
using MessagePack;
using MessagePack.Resolvers;
using VContainer;
using VContainer.Unity;

namespace LifetimeScopes
{
    /// <summary>
    /// All the Lifetime scopes inherits from this, set in VContainerSettings
    /// </summary>
    public class RootLifetimeScope : LifetimeScope {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<HelloWorldService>(Lifetime.Singleton);
            builder.Register<LifetimeScopeDisposer>(Lifetime.Scoped).AsImplementedInterfaces(); // Creates a new instance per scope
            builder.Register<LifeCycleDisposer>(Lifetime.Transient).AsImplementedInterfaces(); // Creates a new instance each time it is resolved no matter the scope.
            builder.Register<GenericMvpFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            
            SetupMessagePack();
        }

        private static void SetupMessagePack()
        {
            StaticCompositeResolver.Instance.Register(
                UniRxResolver.Instance,
                MessagePack.Unity.UnityResolver.Instance,
                MessagePack.Unity.Extension.UnityBlitWithPrimitiveArrayResolver.Instance,
                StandardResolver.Instance
            );

            var options = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
            MessagePackSerializer.DefaultOptions = options;
        }
    }
}