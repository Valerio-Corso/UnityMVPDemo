using Core.Helpers.VContainer;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.MessagePackDemo
{
    public class MessagePackLifetimeScope : LifetimeScope
    {
        [SerializeField] private MessagePackView _messagePackView;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<MessagePackData>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterMVP<MessagePackModel, MessagePackView, MessagePackPresenter>(_messagePackView, Lifetime.Singleton);
        }
    }
}