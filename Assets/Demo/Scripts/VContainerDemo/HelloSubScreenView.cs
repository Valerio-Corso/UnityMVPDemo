using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts.VContainerDemo
{
    public interface IHelloSubScreen
    {
        IObservable<Unit> HelloButtonSubOnClick { get; }
    }

    public class HelloSubScreenView : MonoBehaviour, IHelloSubScreen {
        [SerializeField] Button HelloButtonSub;
        
        IObservable<Unit> IHelloSubScreen.HelloButtonSubOnClick => HelloButtonSub.OnClickAsObservable();
    }
}