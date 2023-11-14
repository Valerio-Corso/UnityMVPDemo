using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts.VContainerDemo.LifetimeScopes
{
	public interface ISpawnerView {
		IObservable<Unit> SpawnButtonOnClick { get; }
		IObservable<Unit> DisposeButtonOnClick { get; }
		Transform CircleSpawnParent { get; }
	}
	public class SpawnerView : MonoBehaviour, ISpawnerView
	{
		[SerializeField] private Button _spawnButton;
		[SerializeField] private Button _disposeButton;
		[SerializeField] Transform _circleSpawnParent;
		public IObservable<Unit> SpawnButtonOnClick => _spawnButton.OnClickAsObservable();
		public IObservable<Unit> DisposeButtonOnClick => _disposeButton.OnClickAsObservable();
		public Transform CircleSpawnParent => _circleSpawnParent;
	}
}