using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts.DemoCharacter.MainUI
{
    public interface IMainUIScreenView
    {
        IObservable<Unit> ShowCountButtonOnClick { get; }
    }

    public class MainUIScreenView : MonoBehaviour, IMainUIScreenView {
        [SerializeField] Button showCountButton;
        
        IObservable<Unit> IMainUIScreenView.ShowCountButtonOnClick => showCountButton.OnClickAsObservable();
    }
}