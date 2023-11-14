using System;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Demo.Scripts.DemoCharacter.Character
{
    public interface ICharacterView
    { }
    
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [Inject] protected readonly HelloScreenData Data;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        

        private Vector2 _currentInput;

        private void Update()
        {
            _currentInput.x = Input.GetAxis("Horizontal");
            _currentInput.y = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            // Calculate the new position and move the character.
            Vector2 movement = _currentInput * Data.CharacterSpeed * Time.fixedDeltaTime;
            Vector2 newPosition = _rigidbody2D.position + movement;

            _rigidbody2D.MovePosition(newPosition);
        }
    }
}
