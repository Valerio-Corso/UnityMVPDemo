using System;
using Core;
using Demo.Scripts.FactoryMVPDemo;
using Demo.Scripts.ViewFactoryDemo;
using UnityEngine;
using VContainer.Unity;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
	public interface ICircleWithCountFactory
	{
		void Spawn(CircleScreenData data, Transform transform, Vector3? position, IDisposer disposer);
	}

	public class CircleWithCountFactory : BaseMvpFactory<CircleModel, CircleView, CirclePresenter, CircleScreenData>, IStartable, ICircleWithCountFactory
	{

		public void Start()
		{
			
		}

		public void Spawn(CircleScreenData data, Transform transform, Vector3? position, IDisposer disposer)
		{
			var mvp = SpawnInternal(data, transform, position, disposer);
		}
	}
}