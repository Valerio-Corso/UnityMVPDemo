using Core.Helpers.VContainer;
using Demo.Scripts.VContainerDemo.SubContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
    /// <summary>
    /// This lifetime does not know anything about elements declared in HelloLifetimeScope, only RootLifetimeScope
    /// </summary>
    public class HelloSubLifetimeScope : LifetimeScope
    {
        [SerializeField] HelloSubScreenView _helloScreenView;
    
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterFromParent<SavegameData, HelloScreenData>(data => data.HelloScreenData, Lifetime.Singleton);
            builder.RegisterMVP<HelloPresenterSubModel, HelloSubScreenView, HelloPresenterSub>(_helloScreenView, Lifetime.Singleton);
        }
    }
}