using System;
using Demo.Scripts.FactoryMVPDemo;
using UnityEngine;
using VContainer;

namespace Core
{
    public abstract class BaseMvpFactoryWithView<TModel, TView, TPresenter, TData>
        where TModel : IFactoryModel<TData> 
        where TPresenter : IFactoryPresenter<TModel, TView> 
        where TView : MonoBehaviour
    {
        [Inject] private readonly Func<TData, TModel> _modelFactory;
        [Inject] private readonly Func<TModel, TView, TPresenter> _presenterFactory;

        protected (TModel, TPresenter) SpawnInternal<TDisposable>(TData data, TView view, TDisposable disposable) where TDisposable : IDisposer
        {
            var model = _modelFactory.Invoke(data);
            model.Initialize(data);
			
            var presenter = _presenterFactory.Invoke(model, view);
            presenter.Initialize(model, view);
			
            disposable.Add(model);
            disposable.Add(presenter);
			
            return (model, presenter);
        }
    }
}