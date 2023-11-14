using Core;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Demo.Scripts.FactoryMVPDemo
{
	public class CirclePresenter : BaseFactoryPresenter<CircleModel, CircleView>
	{
		protected override void Start()
		{
			View.Text = Model.Data.Count.ToString();
		}

		public override void Dispose()
		{
			Debug.Log("Disposed presenter");
			Debug.Log("Destroying view...");
			Object.Destroy(View.gameObject);
		}
	}
}