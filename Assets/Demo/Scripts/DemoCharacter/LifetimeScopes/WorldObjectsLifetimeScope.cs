using Core.Helpers.VContainer;
using Demo.Scripts.DemoCharacter.WorldObjects.Clicker;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
    public class WorldObjectsLifetimeScope : LifetimeScope
    {
        [SerializeField] private ClickerView _clickerView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterFromParent<SavegameData, HelloScreenData>(data => data.HelloScreenData, Lifetime.Singleton);
            builder.RegisterMVP<ClickerModel, ClickerView, ClickerPresenter>(_clickerView, Lifetime.Singleton);
        }
    }
}