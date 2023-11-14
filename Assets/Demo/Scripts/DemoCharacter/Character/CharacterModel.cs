using Core;
using Demo.Scripts.DemoCharacter.WorldObjects.Clicker;
using Demo.Scripts.VContainerDemo;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using VContainer.Unity;

namespace Demo.Scripts.DemoCharacter.Character
{
    public interface ICharacterModel
    {
        void IncreaseSpeed(int count);
    }

    public class CharacterModel : BaseModel<HelloScreenData>, ICharacterModel, IStartable
    {
        public void IncreaseSpeed(int count)
        {
            Data.CharacterSpeed++;
        }

        public void Start()
        {
            MessageBroker.Default.Receive<CountChangedEvent>().Subscribe(count => IncreaseSpeed(count.Count));
        }
    }
}   