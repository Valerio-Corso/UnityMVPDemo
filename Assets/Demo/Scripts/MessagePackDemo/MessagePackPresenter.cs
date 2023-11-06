using Core;
using Core.Helpers;
using UniRx;
using VContainer.Unity;

namespace Demo.Scripts.MessagePackDemo
{
    public class MessagePackPresenter : BasePresenter<IMessagePackModel, IMessagePackView>, IStartable
    {
        void IStartable.Start()
        {
            View.CountButtonClick.Subscribe(_ => Model.CreateRandomList()).AddToDisposer(this);
            View.SerializeButton.Subscribe(_ => Model.Serialize()).AddToDisposer(this);
        }
    }
} 