using System;
using UniRx;

namespace Core
{
    
    public interface IDisposer : IDisposable
    {
        void Add(IDisposable disposable);
        void Reset();
    }
    
    public abstract class Disposer : IDisposer
    {
        private readonly CompositeDisposable _disposable = new();

        public void Add(IDisposable disposable)
        {
            _disposable.Add(disposable);
        }

        public void Reset()
        {
            _disposable.Clear();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }

    public interface ILifeCycleDisposer : IDisposer { }
    public interface ILifetimeScopeDisposer : IDisposer { }
    public class LifeCycleDisposer : Disposer, ILifeCycleDisposer { }
    public class LifetimeScopeDisposer : Disposer, ILifetimeScopeDisposer {}
}