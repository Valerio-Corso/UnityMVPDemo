using Core;
using Demo.Scripts.VContainerDemo;
using Demo.Scripts.VContainerDemo.LifetimeScopes;

namespace VContainerDemo
{
	public interface IHelloPresenterModel {
		void PrintText();
	}
	
	public class HelloPresenterModel : BaseModel<HelloScreenData>, IHelloPresenterModel {
		private readonly HelloWorldService _helloWorldService;

		public HelloPresenterModel(HelloWorldService helloWorldService)
		{
			_helloWorldService = helloWorldService;
		}

		public void PrintText() {
			_helloWorldService.Hello($"{Data.HelloText}, count: {Data.Count}");
		}
	}
}