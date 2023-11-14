using Core;
using Demo.Scripts.VContainerDemo;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UniRx;

namespace Demo.Scripts.DemoCharacter.WorldObjects.Clicker
{
    public interface IClickerModel
    {
        void TryToAddCount();
        IReadOnlyReactiveProperty<bool> Enabled { get; }
        void ChangeEnabling(bool IsEnabled);
    }
    
    public class ClickerModel : BaseModel<HelloScreenData>, IClickerModel
    {
        private readonly HelloWorldService _helloWorldService;
        private readonly ReactiveProperty<bool> _enabled;

        public ClickerModel(HelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
            _enabled = new ReactiveProperty<bool>(false);
        }
        
        public void TryToAddCount()
        {
            if (_enabled.Value)
            {
                Data.Count++;
                MessageBroker.Default.Publish(new CountChangedEvent(){Count = Data.Count});
            }
            else
            {
                _helloWorldService.Hello("Out of Range");
            }
        }

        public void ChangeEnabling(bool IsEnabled)
        {
            _enabled.Value = IsEnabled;
        }

        public IReadOnlyReactiveProperty<bool> Enabled => _enabled;
        
    }

    public class CountChangedEvent
    {
        public int Count;
    }
}