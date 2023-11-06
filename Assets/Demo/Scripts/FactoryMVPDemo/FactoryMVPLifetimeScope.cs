using Core.Helpers.VContainer;
using Demo.Scripts.FactoryMVPDemo;
using Demo.Scripts.ViewFactoryDemo;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
	public class FactoryMVPLifetimeScope : LifetimeScope
	{
		[SerializeField] private SpawnerView _spawnerView;
		[SerializeField] GameObject _circlePrefab;
		
		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterComponent(_spawnerView).AsImplementedInterfaces();
			
			builder.Register<CircleSavegameData>(Lifetime.Singleton);

			// Factory
			builder.Register<CircleWithCountFactory>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.RegisterEntryPoint<CircleSpawner>();
			
			builder.RegisterViewFactory<CircleView>(_circlePrefab, Lifetime.Scoped);
			builder.RegisterMVPFactory<CircleModel, CircleScreenData, CircleView, CirclePresenter>(Lifetime.Scoped);
		}
	}
}