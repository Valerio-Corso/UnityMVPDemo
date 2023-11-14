using Demo.Scripts.FactoryMVPDemo;

namespace Core
{
	public abstract class BaseFactoryModel<TData> : IFactoryModel<TData>
	{ 
		public TData Data { get; set; }
		public void Initialize(TData data)
		{
			Data = data;	
			Start();
		}

		protected abstract void Start();
		
		public virtual void Dispose() { }
	}
}