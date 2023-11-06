using Core;
using Core.Helpers;
using Demo.Scripts.VContainerDemo;
using UniRx;
using VContainer.Unity;

namespace VContainerDemo
{
	public class HelloPresenter : BasePresenter<IHelloPresenterModel, IHelloScreen>, IStartable {
		readonly HelloWorldService helloWorldService;

		public HelloPresenter(HelloWorldService helloWorldService)
		{
			this.helloWorldService = helloWorldService;
		}

		void IStartable.Start()
		{
			View.HelloButtonOnClick.Subscribe(_ => Model.PrintText()).AddToDisposer(this);
		}
	}
}