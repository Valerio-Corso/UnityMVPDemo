using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts.MessagePackDemo
{
    public interface IMessagePackView
    {
        IObservable<Unit> CountButtonClick { get; }
        IObservable<Unit> SerializeButton { get; }
    }

    public class MessagePackView : MonoBehaviour, IMessagePackView
    {
        [SerializeField] private Button _countButton;
        [SerializeField] private Button _serializeButton;

        public IObservable<Unit> CountButtonClick => _countButton.OnClickAsObservable();
        public IObservable<Unit> SerializeButton => _serializeButton.OnClickAsObservable();
    }
}