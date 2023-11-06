using System;
using UniRx;
using VContainer;

namespace Core
{
    public interface IBaseModel : IDisposable { }

	public abstract class BaseModel<TData> : IBaseModel {
		[Inject] protected readonly TData Data;
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