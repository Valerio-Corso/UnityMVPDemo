using System;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
    public class CharacterSceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Will just use the same Date structure from the VContainerDemo, to avoid creating new
            // savegame loader or change the original one
            builder.Register<SavegameLoader>(_ => new (), Lifetime.Singleton);
            builder.Register<SavegameData>(resolver => resolver.Resolve<SavegameLoader>().Data, Lifetime.Singleton);
        }
    }
}