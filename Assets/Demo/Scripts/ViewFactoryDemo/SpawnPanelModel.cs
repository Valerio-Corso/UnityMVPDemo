using Core;
using Core.Helpers;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Demo.Scripts.ViewFactoryDemo
{
    public class SpawnPanelModel : IStartable
	{
        private readonly ISpawnerView _spawnerView;
        private readonly ICircleFactory _circleFactory;
        private readonly ILifetimeScopeDisposer _disposer;

        public SpawnPanelModel(ISpawnerView spawnerView, ICircleFactory circleFactory, ILifetimeScopeDisposer disposer) {
            _spawnerView = spawnerView;
            _circleFactory = circleFactory;
            _disposer = disposer;
        }

        private int _spawnCount;
        public void Start()
        {
            _spawnerView.SpawnButtonOnClick.Subscribe(_ =>
            {
                _spawnCount++;
                var transformPosition = _spawnerView.CircleSpawnParent.position;
                var position = new Vector3(transformPosition.x + 2 * _spawnCount, transformPosition.y, 0);
                var view = _circleFactory.Create(_spawnerView.CircleSpawnParent, position);
            }).AddTo(_disposer);
        }
    }
}