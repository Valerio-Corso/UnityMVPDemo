using Core.Helpers.VContainer;
using Demo.Scripts.DemoCharacter.Character;
using Demo.Scripts.DemoCharacter.WorldObjects.Clicker;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.DemoCharacter.LifetimeScopes
{
    public class CharacterLifetimeScope : LifetimeScope
    {
        [SerializeField] private CharacterView _characterView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterFromParent<SavegameData, HelloScreenData>(data => data.HelloScreenData, Lifetime.Singleton);
            builder.RegisterMVP<CharacterModel, CharacterView, CharacterPresenter>(_characterView, Lifetime.Singleton);
        }
    }
}