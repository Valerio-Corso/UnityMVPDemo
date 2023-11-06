using Core;
using Demo.Scripts.VContainerDemo.LifetimeScopes;

namespace Demo.Scripts.VContainerDemo.SubContainer
{
	public interface IHelloPresenterSubModel {
		void CountUp();
		void PrintText();
	}
	
	public class HelloPresenterSubModel : BaseModel<HelloScreenData>, IHelloPresenterSubModel {
		private readonly HelloWorldService _helloWorldService;

		public HelloPresenterSubModel(HelloWorldService helloWorldService)
		{
			_helloWorldService = helloWorldService;
		}

		public void CountUp() {
			Data.Count++;
		}
		
		public void PrintText() {
			_helloWorldService.Hello($"{Data.HelloText}, count: {Data.Count}");
		}
	}
}