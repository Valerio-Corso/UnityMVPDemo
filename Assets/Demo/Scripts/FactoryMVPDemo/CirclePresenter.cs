using Core;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using Demo.Scripts.ViewFactoryDemo;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Demo.Scripts.FactoryMVPDemo
{
	public class CirclePresenter : IFactoryPresenter<CircleModel, CircleView>
	{
		public CircleView View { get; set; }
		public CircleModel Model { get; set; }
		public void Initialize(CircleModel model, CircleView view)
		{
			Model = model;
			View = view;

			View.Text = Model.Data.Count.ToString();
		}

		public void Dispose()
		{
			Debug.Log("Disposed presenter");
			Debug.Log("Destroying view...");
			Object.Destroy(View.gameObject);
		}
	}
}