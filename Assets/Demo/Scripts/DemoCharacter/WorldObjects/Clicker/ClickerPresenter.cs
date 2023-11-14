using Core;
using Core.Helpers;
using UniRx;
using VContainer.Unity;

namespace Demo.Scripts.DemoCharacter.WorldObjects.Clicker
{
    public class ClickerPresenter : BasePresenter<IClickerModel, IClickerView>, IStartable
    {
        void IStartable.Start()
        {
            View.OnPlayerClick.Subscribe(_ =>
                    Model.TryToAddCount())
                .AddToDisposer(this);

            View.OnPlayerInEnablingArea.Subscribe(isEnabled =>
                Model.ChangeEnabling(isEnabled));

            Model.Enabled.Subscribe(enabled => 
                    View.ChangeColorIfEnabled(enabled))
                .AddToDisposer(this);
        }
        
    }
}