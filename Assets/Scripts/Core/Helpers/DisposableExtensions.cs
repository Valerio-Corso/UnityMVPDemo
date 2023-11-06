using System;
using UnityEngine;

namespace Core.Helpers
{
	public static class DisposableExtensions
	{
		public static T AddToDisposer<T, TData, TView>(this T disposable, BasePresenter<TData, TView> presenter) where T: IDisposable
		{
			presenter.AddDisposable(disposable);
			return disposable;
		}
		
		public static T AddToDisposer<T, TView>(this T disposable, BaseViewFactory<TView> factory) where T: IDisposable where TView : MonoBehaviour
		{
			factory.AddDisposable(disposable);
			return disposable;
		}

        public static T AddTo<T>(this T disposable, ILifetimeScopeDisposer disposer) where T : IDisposable
        {
            disposer.Add(disposable);
            return disposable;
        }
    }
}