using Core.Helpers.VContainer;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;
using VContainerDemo;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
    public class HelloLifetimeScope : LifetimeScope
    {
        [SerializeField] HelloScreenView _helloScreenView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterFromParent<SavegameData, HelloScreenData>(data => data.HelloScreenData, Lifetime.Singleton);
            builder.RegisterMVP<HelloPresenterModel, HelloScreenView, HelloPresenter>(_helloScreenView, Lifetime.Singleton);

        }
    }
}