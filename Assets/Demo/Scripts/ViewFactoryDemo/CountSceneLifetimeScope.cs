using Core.Helpers.VContainer;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.ViewFactoryDemo
{
	public class CountSceneLifetimeScope : LifetimeScope
	{
		[SerializeField] private SpawnerView _spawnerView;
		[SerializeField] GameObject _circlePrefab;
		
		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterComponent(_spawnerView).AsImplementedInterfaces();
			builder.RegisterEntryPoint<SpawnPanelModel>();

			// Factory
			builder.Register<CircleFactory>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.RegisterViewFactory<CircleView>(_circlePrefab, Lifetime.Scoped);
		}
	}
}