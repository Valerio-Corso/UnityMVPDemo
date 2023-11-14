using Core;
using Core.Helpers;
using UniRx;
using VContainer.Unity;

namespace Demo.Scripts.DemoCharacter.MainUI
{
    public class MainUIPresenter : BasePresenter<IMainUIPresenterModel, IMainUIScreenView>, IStartable
    {

        void IStartable.Start()
        {
            View.ShowCountButtonOnClick.Subscribe(_ => Model.PrintText())
                .AddToDisposer(this);
        }
    }
}