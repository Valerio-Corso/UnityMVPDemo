using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using VContainer;

namespace Core
{
    /// <summary>
    /// In the case you want a model or presenter there is not really a great way to resolve dependenceis dynamically.
    /// I think the best solution is pull here your dependencies and then in the Create method of the inheriting class:
    /// var view = Spawn(parent);
    /// var model = new Model(data);
    /// var presenter = new Presenter(view, model, otherDependencies...);
    /// https://vcontainer.hadashikick.jp/registering/register-factory
    /// </summary>
    public abstract class BaseViewFactory<TView> where TView : MonoBehaviour
	{
		[Inject] protected readonly Func<Vector3, TView> ViewFactory;
        [Inject] protected readonly ILifetimeScopeDisposer Disposer;

        public void AddDisposable(IDisposable item)
        {
            Disposer.Add(item);
        }

        protected TView SpawnView()
        {
            var view = ViewFactory.Invoke(Vector3.zero);
            return view;
        }

        protected TView SpawnView(Transform parent)
        {
            return SpawnView(Vector3.zero, parent);
        }

        protected TView SpawnView(Vector3 position)
        {
            return ViewFactory.Invoke(position);
        }

        protected TView SpawnView(Vector3 position, Transform parent)
        {
            TView view = ViewFactory.Invoke(position);
            view.transform.SetParent(parent);
            return view;
        }
	}

}