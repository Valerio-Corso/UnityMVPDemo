using System;

namespace Core
{
    public interface IFactoryPresenter<TModel, TView> : IDisposable
    {
        public TView View { get; set; }
        public TModel Model { get; set; }
        public void Initialize(TModel model, TView view);
    }
}