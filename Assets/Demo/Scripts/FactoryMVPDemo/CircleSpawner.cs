using System.Collections.Generic;
using Core;
using Core.Helpers;
using Demo.Scripts.FactoryMVPDemo;
using Demo.Scripts.ViewFactoryDemo;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
	public class CircleSpawner : BaseModel<CircleSavegameData>, IStartable
	{
		private readonly ICircleWithCountFactory _factory;
		private readonly ISpawnerView _view;
		private ILifeCycleDisposer _lifeCycleDisposer;

		public CircleSpawner(ICircleWithCountFactory factory, ISpawnerView view, ILifeCycleDisposer lifeCycleDisposer)
		{
			_factory = factory;
			_view = view;
			_lifeCycleDisposer = lifeCycleDisposer;
		}

		public void Start()
		{
			Data.CircleData = new List<CircleScreenData>()
			{
				new() {Count = 1},
				new() {Count = 5},
				new() {Count = 10},
			};
			
			_view.SpawnButtonOnClick.Subscribe(_ => Spawn()).AddTo(Disposer);
			_view.DisposeButtonOnClick.Subscribe(_ => _lifeCycleDisposer.Reset()).AddTo(Disposer);
		}

		private void Spawn()
		{
			var count = 1;
			foreach (var circleScreenData in Data.CircleData)
			{
				_factory.Spawn(circleScreenData, _view.CircleSpawnParent, new Vector3(1 + count,1), _lifeCycleDisposer);
				count++;
			}
		}
	}
}