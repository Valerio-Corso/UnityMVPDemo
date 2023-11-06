using Core;
using Core.Helpers;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Demo.Scripts.VContainerDemo.SubContainer
{
    public class HelloPresenterSub : BasePresenter<IHelloPresenterSubModel, IHelloSubScreen>, IStartable
    {
        readonly HelloWorldService helloWorldService;

        public HelloPresenterSub(HelloWorldService helloWorldService)
        {
            this.helloWorldService = helloWorldService;
        }

        void IStartable.Start()
        {
            View.HelloButtonSubOnClick.Subscribe(_ => {
                Model.CountUp();
                Model.PrintText();
                Debug.Log("Sub context");
            }).AddToDisposer(this);
        }
    }
}