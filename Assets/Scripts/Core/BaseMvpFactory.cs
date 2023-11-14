using System;
using Demo.Scripts.FactoryMVPDemo;
using UnityEngine;
using VContainer;

namespace Core
{
	public interface IMvpFactory
	{
		void Spawn<TModel, TView, TPresenter, TData>(TData data, Transform transform, Vector3? position, IDisposer disposer)
				where TModel : IFactoryModel<TData>
				where TPresenter : IFactoryPresenter<TModel, TView>
				where TView : MonoBehaviour;
	}
	
	public class GenericMvpFactory : IMvpFactory
	{
		private readonly IObjectResolver _resolver;

		public GenericMvpFactory(IObjectResolver resolver)
		{
			_resolver = resolver;
		}

		public void Spawn<TModel, TView, TPresenter, TData>(TData data, Transform transform, Vector3? position, IDisposer disposer)
				where TModel : IFactoryModel<TData>
				where TPresenter : IFactoryPresenter<TModel, TView>
				where TView : MonoBehaviour
		{
			// Resolve factories using VContainer
			var modelFactory = _resolver.Resolve<Func<TData, TModel>>();
			var presenterFactory = _resolver.Resolve<Func<TModel, TView, TPresenter>>();
			var viewFactory = _resolver.Resolve<Func<Vector3, TView>>();

			TView view = position.HasValue ? viewFactory(position.Value) : viewFactory(Vector3.zero);
			view.transform.SetParent(transform);

			TModel model = modelFactory(data);
			model.Initialize(data);

			TPresenter presenter = presenterFactory(model, view);
			presenter.Initialize(model, view);

			disposer.Add(model);
			disposer.Add(presenter);
		}
	}
}