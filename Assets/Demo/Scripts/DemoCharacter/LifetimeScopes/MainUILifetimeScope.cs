using Core.Helpers.VContainer;
using Demo.Scripts.DemoCharacter.MainUI;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using Demo.Scripts.VContainerDemo.SubContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.DemoCharacter.LifetimeScopes
{
    public class MainUILifetimeScope : LifetimeScope
    {
        [SerializeField] private MainUIScreenView _mainUIScreenView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterFromParent<SavegameData, HelloScreenData>(data => data.HelloScreenData, Lifetime.Singleton);
            builder.RegisterMVP<MainUIPresenterModel, MainUIScreenView, MainUIPresenter>(_mainUIScreenView, Lifetime.Singleton);
        }
    }
}