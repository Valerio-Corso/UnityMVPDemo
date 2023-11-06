using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts.VContainerDemo
{
    public interface IHelloScreen
    {
        IObservable<Unit> HelloButtonOnClick { get; }
    }
    
    public class HelloScreenView : MonoBehaviour, IHelloScreen {
        [SerializeField] private Button HelloButton;
        IObservable<Unit> IHelloScreen.HelloButtonOnClick => HelloButton.OnClickAsObservable();
    }
}