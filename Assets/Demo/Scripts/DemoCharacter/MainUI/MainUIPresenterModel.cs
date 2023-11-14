using Core;
using Demo.Scripts.VContainerDemo;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using Demo.Scripts.VContainerDemo.SubContainer;

namespace Demo.Scripts.DemoCharacter.MainUI
{
	public interface IMainUIPresenterModel {
		void PrintText();
	}
	
	public class MainUIPresenterModel : BaseModel<HelloScreenData>, IMainUIPresenterModel {
		private readonly HelloWorldService _helloWorldService;

		public MainUIPresenterModel(HelloWorldService helloWorldService)
		{
			_helloWorldService = helloWorldService;
		}

		public void PrintText() {
			_helloWorldService.Hello($"{Data.HelloText}, count: {Data.Count}");
		}
	}
}