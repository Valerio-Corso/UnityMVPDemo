using System;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
	public class HelloSceneLifetimeScope : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			// Fancy fluff to make sure that SavegameLoader is only created once and the lifecycle handled by the container.
			// Equivalent would be manually creating the loader new SavegameLoader() and then builder.RegisterInstance(loader). But it is not recommended.
			builder.Register<SavegameLoader>(_ => new (), Lifetime.Singleton);
			builder.Register<SavegameData>(resolver => resolver.Resolve<SavegameLoader>().Data, Lifetime.Singleton);
		}
	}

	public class SavegameLoader
	{
		public SavegameData Data;

		public SavegameLoader()
		{
			Data = new() { HelloScreenData = new() { HelloText = "Hello world.", CharacterSpeed = 2f} };
		}
	}

	public class SavegameData
	{
		public HelloScreenData HelloScreenData { get; set; }
	}

	[Serializable]
	public class HelloScreenData
	{
		public string HelloText;
		public int Count;
		public float CharacterSpeed;
	}
}