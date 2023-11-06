using System;
using UniRx;
using VContainer;

namespace Core
{
	public interface IBasePresenter : IDisposable { }

	public abstract class BasePresenter<TModel, TView> : IBasePresenter
	{
		[Inject] protected readonly TModel Model;
		[Inject] protected readonly TView View;
        [Inject] protected readonly ILifetimeScopeDisposer Disposer;

        public void AddDisposable(IDisposable item)
        {
            Disposer.Add(item);
        }

        public void Dispose()
        {
	        
        }
	}
}