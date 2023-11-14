namespace Core
{
	public abstract class BaseFactoryPresenter<TModel, TView> : IFactoryPresenter<TModel, TView>
	{
		public TView View { get; set; }
		public TModel Model { get; set; }
		public void Initialize(TModel model, TView view)
		{
			Model = model;
			View = view;
			Start();
		}

		protected abstract void Start();
		
		public virtual void Dispose() { }
	}
}