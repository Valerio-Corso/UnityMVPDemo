using Demo.Scripts.VContainerDemo;
using UnityEngine;
using VContainer;

namespace Demo.Scripts.FactoryMVPDemo
{
	public class CircleModel : IFactoryModel<CircleScreenData>
	{
		public CircleModel() {}
		
		[Inject]
		public void Inject(HelloWorldService helloWorldService)
		{
			helloWorldService.Hello("Injected the hello world service through VContainer!");
		}
		
		public CircleScreenData Data { get; set; }
		public void Initialize(CircleScreenData data)
		{
			Data = data;
		}

		public void Dispose()
		{
			Debug.Log("Disposed model");
		}
	}
}