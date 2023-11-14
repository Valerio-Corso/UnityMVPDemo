using Core;
using Demo.Scripts.VContainerDemo;
using UnityEngine;
using VContainer;

namespace Demo.Scripts.FactoryMVPDemo
{
	public class CircleModel : BaseFactoryModel<CircleScreenData>
	{
		[Inject]
		public void Inject(HelloWorldService helloWorldService)
		{
			helloWorldService.Hello("Injected the hello world service through VContainer!");
		}

		protected override void Start()
		{
			
		}

		public override void Dispose()
		{
			Debug.Log("Disposed model");
		}
	}
}