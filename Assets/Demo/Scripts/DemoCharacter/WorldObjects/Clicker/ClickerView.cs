using System;
using Demo.Scripts.DemoCharacter.Character;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using VContainer.Unity;
using Unit = UniRx.Unit;

namespace Demo.Scripts.DemoCharacter.WorldObjects.Clicker
{
    public interface IClickerView
    {
        IObservable<Unit> OnPlayerClick { get; }
        IObservable<bool> OnPlayerInEnablingArea { get; }
        void ChangeColorIfEnabled(bool isEnabled);
    }

    public class ClickerView : MonoBehaviour, IClickerView, IStartable
    {
        [SerializeField] private GameObject ClickerBody;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Collider2D _enablingArea;
        
        private Subject<bool> _onPlayerInEnablingArea = new Subject<bool>();
        public void Start()
        {
            _enablingArea.OnTriggerEnter2DAsObservable()
                .Where(collider => collider.CompareTag("Player"))
                .Subscribe(_ => _onPlayerInEnablingArea.OnNext(true))
                .AddTo(this);

            _enablingArea.OnTriggerExit2DAsObservable()
                .Where(collider => collider.CompareTag("Player"))
                .Subscribe(_ => _onPlayerInEnablingArea.OnNext(false))
                .AddTo(this);
        }
        
        IObservable<Unit> IClickerView.OnPlayerClick => ClickerBody.OnMouseUpAsButtonAsObservable();
        IObservable<bool> IClickerView.OnPlayerInEnablingArea => _onPlayerInEnablingArea;
        
        public void ChangeColorIfEnabled(bool isEnabled)
        {
            _renderer.color = isEnabled ? new Color(0.64f, 1f, 0.57f) : new Color(0.5f, 0.5f, 0.49f);
        }
    }

}