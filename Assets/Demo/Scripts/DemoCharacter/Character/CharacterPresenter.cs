using System.Numerics;
using Core;
using Core.Helpers;
using UniRx;
using Unity.VisualScripting;
using VContainer.Unity;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Demo.Scripts.DemoCharacter.Character
{
    public class CharacterPresenter : BasePresenter<ICharacterModel, ICharacterView>, IPostStartable
    {
        public void PostStart()
        { }
    }
}